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

        private void AdultOrRacy_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // todo: clear image box or set it to placeholder

                ResultLabel.Text = "Evaluating...";

                var fileInfo = new FileInfo(fileDialog.FileName);

                if (!Helpers.IsPicture(fileInfo.Extension))
                {
                    ResultLabel.Text = ResultLabel.Text = "Unable to assess this file type. Please try a different file.";
                }
                else
                {
                    FileStream image = File.OpenRead(fileInfo.FullName);
                    var imageData = GetAdultRacyResults(image);

                    if (imageData is not null)
                    {
                        if (!IsContentSafe(imageData))
                        {
                            ResultLabel.Text = "Fail! NSFW content detected.";
                        }
                        else
                        {
                            ResultLabel.Text = "Pass! This is a safe file.";
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

                        imageBox.Image = Image.FromFile(fileInfo.FullName);
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

        private EvaluationData? GetAdultRacyResults(FileStream image)
        {
            // todo: get and display the response/error

            var imageData = new EvaluationData();

            try
            {
                imageData.ImageModerationResults = Client.ImageModeration.EvaluateFileInput(image, true);
                return imageData;
            }
            catch
            {
                ResultLabel.Text = $"Unable to evaluate image.";
            }
            return null;
        }

        private void DriversLicense_Click(object sender, EventArgs e)
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

        private void CreditCard_Click(object sender, EventArgs e)
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