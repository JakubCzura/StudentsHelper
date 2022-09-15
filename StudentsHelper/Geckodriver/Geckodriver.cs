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
        //Geckodriver makes a problem while debugging. It goes back to a previous version and the application can't use it.
        //I created a directory with a copy of geckodriver.exe and this file is always copied to the StudentsHelper\StudentsHelper\bin\Debug\net6.0-windows
        //It makes the application doesn't use old version of geckodriver and there is no exception

        private static readonly string geckodriverName = @"geckodriver.exe";
     
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
