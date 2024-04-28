using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ImageContentFilterPOC.CCAndDLFilterPage;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using System.Threading;
using ImageList = Microsoft.Azure.CognitiveServices.ContentModerator.Models.ImageList;

namespace ImageContentFilterPOC
{
    public partial class CCAndDLFilterPage : Form
    {
        /// <summary>
        /// A copy of the list details.
        /// </summary>
        /// <remarks>Used to initially create the list, and later to update the
        /// list details.</remarks>
        public static Body ListDetails;

        public CCAndDLFilterPage()
        {
            InitializeComponent();
        }

        private void BrowseFiles_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(fileDialog.FileName);

                if (!IsCreditCardOrDriverLicense(fileInfo))
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

        public bool IsCreditCardOrDriverLicense(FileInfo fileInfo)
        {
            ResultLabel.Text = "Evaluating...";

            if (Helpers.IsPicture(fileInfo))
            {
                FileStream image = File.OpenRead(fileInfo.FullName);

                ContentModeratorClient client = Authenticate(Globals.SubscriptionKey, Globals.Endpoint);

                var creationResult = CreateCustomList(client);

                int listId = creationResult.Id.Value;

                RefreshSearchIndex(client, listId);

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

        public static ContentModeratorClient Authenticate(string key, string endpoint)
        {
            ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(key));
            client.Endpoint = endpoint;

            return client;
        }



        
    }
}