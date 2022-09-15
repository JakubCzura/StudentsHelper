using StudentsHelper.UserControls;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Schedules
{
    public class ScheduleImporter : ScheduleDownloader
    {
        private static readonly string scheduleName = @"PlanZajec";
        private static readonly string fileNameExtension = @".pdf";

        private static string GetDownloadsDirectoryPath()
        {
            return KnownFolders.Downloads.Path;
        }

        private static List<string>? GetSchedulesSortedDescending()
        {
            List<string>? fileEntries = Directory.GetFiles(GetDownloadsDirectoryPath()).Where(file => file.Contains(scheduleName) && file.EndsWith(fileNameExtension)).ToList();
            List<string>? filesSortedByDateAscending = fileEntries.OrderByDescending(File.GetCreationTime).ToList();
            return filesSortedByDateAscending;
        }

        public static string GetSchedulePath()
        {
            var schedules = GetSchedulesSortedDescending();
            if (schedules != null && schedules.Count >= 1)
            {
                return schedules[0];
            }
            return string.Empty;
        }

        public static void SetSchedule()
        {
            if (ScheduleUserControl.Instance != null)
            {
                string schedulePath = GetSchedulePath();
                if (!string.IsNullOrEmpty(schedulePath))
                {
                    ScheduleUserControl.Instance.ScheduleWebBrowser.Navigate(schedulePath);
                }
            }
        }
    }
}
