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
        public ImageFilterPage()
        {
            InitializeComponent();
        }

        public class EvaluationData
        {
            // The image moderation results.
            public Evaluate ImageModerationResults;
        }

        private void AdultOrRacy_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(fileDialog.FileName);

                if (!IsContentSafe(fileInfo))
                {
                    ResultLabel.Text = "Fail! NSFW content detected.";
                }
                else
                {
                    ResultLabel.Text = "Pass! This is a safe file.";
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

        public bool IsContentSafe(FileInfo fileInfo)
        {
            ResultLabel.Text = "Evaluating...";

            if (Helpers.IsPicture(fileInfo))
            {
                FileStream image = File.OpenRead(fileInfo.FullName);

                ContentModeratorClient client = Helpers.Authenticate(Globals.ContentModSubscriptionKey, Globals.ContentModEndPoint);

                var imageData = new EvaluationData
                {
                    ImageModerationResults = client.ImageModeration.EvaluateFileInput(image, true)
                };

                Thread.Sleep(1000);

                if ((bool)imageData.ImageModerationResults.IsImageRacyClassified)
                    return false;
                if ((bool)imageData.ImageModerationResults.IsImageAdultClassified)
                    return false;
            }

            return true;
        }

        private void DriversLicense_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(fileDialog.FileName);

                ResultLabel.Text = "Evaluating...";

                if (Helpers.IsPicture(fileInfo))
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

                if (Helpers.IsPicture(fileInfo))
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