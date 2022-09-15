using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.Geckodriver
{
    public class Geckodriver
    {
        private static string geckodriverName = @"geckodriver.exe";
     
        public static void CopyGeckodriverToDebugDirectory()
        { 
            try
            {
                string geckodriverDebugFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, geckodriverName);
                string geckodriverFullPath = Path.Combine(Directory.GetParent(geckodriverDebugFullPath).Parent.Parent.Parent.FullName, "Geckodriver", geckodriverName);
                
                if (File.Exists(geckodriverFullPath))
                {
                    File.Copy(geckodriverFullPath, geckodriverDebugFullPath, true);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
