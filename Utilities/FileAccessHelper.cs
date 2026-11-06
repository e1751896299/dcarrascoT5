using System;
using System.Collections.Generic;
using System.Text;

namespace dcarrascoT5.Utilities
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }   

            
    }
}
