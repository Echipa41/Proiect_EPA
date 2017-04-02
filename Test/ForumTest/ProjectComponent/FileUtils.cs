using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForumTest.ProjectComponent
{
    public class FileUtils
    {
        private static string mDirectoryProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        internal static string CreateInputPath(string file)
        {
            return mDirectoryProject + "\\" + Constants.DATA_INPUT_PATH + file;
        }        
    }
}
