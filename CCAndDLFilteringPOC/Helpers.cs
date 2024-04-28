using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                || fileInfo.Extension == ".gif")
                return true;
            else
                return false;
        }
    }
}