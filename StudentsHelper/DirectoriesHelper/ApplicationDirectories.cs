using Syroot.Windows.IO;
using System;
using System.IO;

namespace StudentsHelper.DirectoriesHelper
{
    public class ApplicationDirectories
    {
        public static string BaseDirectoryFullPath
        {
            get { return Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory); }
        }

        public static string StudentsHelperDirectoryFullPath
        {
            get { return Path.Combine(Directory.GetParent(BaseDirectoryFullPath).Parent.Parent.Parent.FullName); }
        }

        public static string DownloadsDirectoryFullPath
        {
            get { return KnownFolders.Downloads.Path; }
        }
    }
}