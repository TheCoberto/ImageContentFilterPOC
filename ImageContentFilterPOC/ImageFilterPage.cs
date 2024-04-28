using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Image = System.Drawing.Image;
using System.Text.RegularExpressions;

namespace ImageContentFilterPOC
{
    public partial class ImageFilterPage : Form
    {
        public ContentModeratorClient Client = Helpers.Authenticate(Globals.ContentModSubscriptionKey, Globals.ContentModEndPoint);

        public ImageFilterPage()
        {
            InitializeComponent();
        }

        public class EvaluationData
        {
            public Evaluate? ImageModerationResults;
        }

        private void AdultOrRacyButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // todo: clear image box or set it to placeholder

                this.ResultLabel.Text = "Evaluating...";

                FileInfo? fileInfo = new FileInfo(fileDialog.FileName);

                if (!Helpers.IsPicture(fileInfo.Extension))
                {
                    this.ResultLabel.Text = this.ResultLabel.Text = "Unable to assess this file type. Please try a different file.";
                }
                else
                {
                    Stream file = File.OpenRead(fileInfo.FullName);
                    EvaluationData? imageData = GetAdultRacyResults(file);

                    if (imageData is not null)
                    {
                        if (!IsContentSafe(imageData))
                        {
                            this.ResultLabel.Text = "Fail! NSFW content detected.";
                        }
                        else
                        {
                            this.ResultLabel.Text = "Pass! This is a safe file.";
                        }

                        decimal adultScore = Math.Round((decimal)imageData.ImageModerationResults.AdultClassificationScore, 2);
                        decimal racyScore = Math.Round((decimal)imageData.ImageModerationResults.RacyClassificationScore, 2);
                        decimal adultScoreRounded = adultScore * 100;
                        decimal racyScoreRounded = racyScore * 100;
                        int adultScorePercentage = (int)Math.Round((decimal)adultScoreRounded);
                        int racyScorePercentage = (int)Math.Round((decimal)racyScoreRounded);

                        AdultScoreTextBox.Text = $"{adultScore} - {adultScorePercentage}%";
                        RacyScoreTextBox.Text = $"{racyScore} - {racyScorePercentage}%";

                        IsAdultTextBox.Text = (bool)imageData?.ImageModerationResults?.IsImageAdultClassified ? "Yes" : "No";
                        IsRacyTextBox.Text = (bool)imageData?.ImageModerationResults?.IsImageRacyClassified ? "Yes" : "No";

                        // todo: handle problematic images that fail to display for unknown reasons
                        using (var image = Image.FromFile(fileInfo.FullName))
                        {
                            foreach (var prop in image.PropertyItems)
                            {
                                if (prop.Id == 0x0112) // value of EXIF rotation property
                                {
                                    int orientationValue = image.GetPropertyItem(prop.Id).Value[0];
                                    RotateFlipType rotateFlipType = GetRotateFlipType(orientationValue);
                                    image.RotateFlip(rotateFlipType);
                                    break;
                                }
                            }
                            imageBox.Image = (Image)image.Clone();
                            imageBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
            }
            else
            {
                ResultLabel.Text = "Select an image file (.jpg, .jpeg, .png, .gif)";
            }
        }

        public bool IsContentSafe(EvaluationData imageData)
        {
            if ((bool)imageData.ImageModerationResults.IsImageRacyClassified ||
                ((bool)imageData.ImageModerationResults.IsImageAdultClassified))
                return false;

            return true;
        }

        private EvaluationData? GetAdultRacyResults(Stream image)
        {
            var imageData = new EvaluationData();

            try
            {
                if (image.Length > 4000000) // If larger than 4MB
                {
                    var imageObj = Image.FromStream(image);
                    var scaleFactor = (double)800 / (double)Math.Max(imageObj.Width, imageObj.Height);
                    var newWidth = (int)(imageObj.Width * scaleFactor);
                    var newHeight = (int)(imageObj.Height * scaleFactor);

                    using var newImage = new Bitmap(newWidth, newHeight);
                    using var graphics = Graphics.FromImage(newImage);
                    graphics.DrawImage(imageObj, 0, 0, newWidth, newHeight);

                    using (var memoryStream = new MemoryStream())
                    {
                        newImage.Save(memoryStream, imageObj.RawFormat);
                        image = new MemoryStream(memoryStream.ToArray());
                    }
                }

                imageData.ImageModerationResults = Client.ImageModeration.EvaluateFileInput(image, true);
                return imageData;
            }
            catch (Exception ex)
            {
                ResultLabel.Text = $"Unable to evaluate image. {ex.Message}";
            }
            return null;
        }

        private static RotateFlipType GetRotateFlipType(int orientationValue)
        {
            RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;

            switch (orientationValue)
            {
                case 1:
                    rotateFlipType = RotateFlipType.RotateNoneFlipNone;
                    break;
                case 2:
                    rotateFlipType = RotateFlipType.RotateNoneFlipX;
                    break;
                case 3:
                    rotateFlipType = RotateFlipType.Rotate180FlipNone;
                    break;
                case 4:
                    rotateFlipType = RotateFlipType.Rotate180FlipX;
                    break;
                case 5:
                    rotateFlipType = RotateFlipType.Rotate90FlipX;
                    break;
                case 6:
                    rotateFlipType = RotateFlipType.Rotate90FlipNone;
                    break;
                case 7:
                    rotateFlipType = RotateFlipType.Rotate270FlipX;
                    break;
                case 8:
                    rotateFlipType = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    rotateFlipType = RotateFlipType.RotateNoneFlipNone;
                    break;
            }

            return rotateFlipType;
        }


        private void DriversLicenseButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(fileDialog.FileName);

                ResultLabel.Text = "Evaluating...";

                if (Helpers.IsPicture(fileInfo.Extension))
                {
                    FileStream image = File.OpenRead(fileInfo.FullName);

                    RecognizeDriverLicense(image);
                }

                try
                {
                    imageBox.Image = Image.FromFile(fileInfo.FullName);
                }
                catch
                {
                    ResultLabel.Text = "Unable to display. Please try a different image.";
                }
            }
            else
            {
                ResultLabel.Text = "Select an image file (.jpg, .jpeg, .png, .gif)";
            }
        }

        private async void RecognizeDriverLicense(Stream image)
        {
            AzureKeyCredential credential = new AzureKeyCredential(Globals.FormRecognizerSubscriptionKey);
            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(Globals.FormRecognizerEndPoint), credential);

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-idDocument", image);

            AnalyzeResult identityDocuments = operation.Value;

            if (identityDocuments.Documents.Count > 0)
            {
                AnalyzedDocument identityDocument = identityDocuments.Documents.Single();

                if (identityDocument.Fields.TryGetValue("Address", out DocumentField addressField) && identityDocument.DocumentType == "idDocument.driverLicense")
                {
                    var state = addressField.Value.AsAddress().State;

                    if (state != null)
                    {
                        ResultLabel.Text = $"This is a/an '{state}' license!";
                        return;
                    }
                }

                ResultLabel.Text = "This is not a driver's license!";
                return;
            }

            ResultLabel.Text = "Cannot identify. Please try again.";
        }

        private void CreditCardButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(fileDialog.FileName);

                ResultLabel.Text = "Evaluating...";

                if (Helpers.IsPicture(fileInfo.Extension))
                {
                    FileStream image = File.OpenRead(fileInfo.FullName);

                    RecognizeCreditCard(image);
                }

                try
                {
                    imageBox.Image = Image.FromFile(fileInfo.FullName);
                }
                catch
                {
                    ResultLabel.Text = "Unable to display. Please try a different image.";
                }
            }
            else
            {
                ResultLabel.Text = "Select an image file (.jpg, .jpeg, .png, .gif)";
            }
        }

        private async void RecognizeCreditCard(FileStream image)
        {
            AzureKeyCredential credential = new AzureKeyCredential(Globals.FormRecognizerSubscriptionKey);
            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(Globals.FormRecognizerEndPoint), credential);

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-idDocument", image);

            AnalyzeResult identityDocuments = operation.Value;

            var paragraphs = identityDocuments.Paragraphs;

            foreach (var paragraph in paragraphs)
            {
                FindType(paragraph.Content);
            }

            if (ResultLabel.Text == "Evaluating...")
                ResultLabel.Text = "Cannot identify. Please try again.";
        }

        private void FindType(string cardNumber)
        {
            if (cardNumber.Contains(" "))
                cardNumber = cardNumber.Replace(" ", "");

            //https://www.regular-expressions.info/creditcard.html
            if (Regex.Match(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
            {
                ResultLabel.Text = "This is a Visa Credit Card.";
                return;
            }

            if (Regex.Match(cardNumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
            {
                ResultLabel.Text = "This is a MasterCard Credit Card.";
                return;
            }

            if (Regex.Match(cardNumber, @"^3[47][0-9]{13}$").Success)
            {
                ResultLabel.Text = "This is an American Express Credit Card.";
                return;
            }

            if (Regex.Match(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$").Success)
            {
                ResultLabel.Text = "This is a Discover Credit Card.";
                return;
            }

            if (Regex.Match(cardNumber, @"^(?:2131|1800|35\d{3})\d{11}$").Success)
            {
                ResultLabel.Text = "This is a JCB Credit Card.";
                return;
            }
        }
    }
}