using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForumTest.Common
{
    public static class ImageUtils
    {     
        private static bool IsValidPath(string path)
        {
            if (!File.Exists(path))
                return false;
            return true;
        }

        public static bool IsValidImage(string path )
        {
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
            if(! IsValidPath(path))
            {
                return false;
            }

            if (ImageExtensions.Contains(Path.GetExtension(path).ToUpperInvariant()))
                return true;

            return false;
        }
    }
}
