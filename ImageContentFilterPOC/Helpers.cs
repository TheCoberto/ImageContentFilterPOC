using Microsoft.Azure.CognitiveServices.ContentModerator;

namespace ImageContentFilterPOC
{
    class Helpers
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
    }
}