using Microsoft.Azure.CognitiveServices.ContentModerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ImageContentFilterPOC
{
    class Helpers
    {
        public static bool IsPicture(FileInfo fileInfo)
        {
            if (fileInfo.Extension == ".jpeg" 
                || fileInfo.Extension == ".jpg" 
                || fileInfo.Extension == ".png"
                || fileInfo.Extension == ".gif"
                || fileInfo.Extension == ".jfif")
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