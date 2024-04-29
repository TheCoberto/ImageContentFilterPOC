using Microsoft.Azure.CognitiveServices.ContentModerator;
using static ImageContentFilterPOC.ImageFilterPage;

namespace ImageContentFilterPOC
{
    public class Helpers
    {
        public static bool IsPicture(string fileExtension)
        {
            fileExtension = fileExtension.ToLower();

            if (fileExtension == ".jpeg" 
                || fileExtension == ".jpg" 
                || fileExtension == ".png"
                || fileExtension == ".gif"
                || fileExtension == ".jfif")
                return true;
            else
                return false;
        }

        public static ContentModeratorClient Authenticate(string key, string endpoint)
        {
            ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(key));
            client.Endpoint = endpoint;

            return client;
        }

        public static bool IsContentSafe(EvaluationData imageData)
        {
            if ((bool)imageData.ImageModerationResults.IsImageRacyClassified ||
                ((bool)imageData.ImageModerationResults.IsImageAdultClassified))
                return false;

            return true;
        }
    }
}