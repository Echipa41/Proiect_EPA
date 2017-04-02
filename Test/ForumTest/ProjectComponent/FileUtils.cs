using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForumTest.Test
{
    internal class FileUtils
    {
        private static string mDirectoryProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        internal static string CreateInputPath(string xmlFile)
        {
            return mDirectoryProject + "\\" + Constants.DATA_INPUT_PATH + xmlFile;
        }        
    }
}
