using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.DirectoriesHelper
{
    public class ApplicationDirectories
    {
        public static string BaseDirectoryFullPath
        {
            get { return Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory); }
        }     

        public static string DownloadsDirectoryFullPath
        {
            get { return KnownFolders.Downloads.Path; }
        }
    }
}
