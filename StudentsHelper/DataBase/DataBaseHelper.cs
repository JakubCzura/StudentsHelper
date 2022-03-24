using SQLite;
using StudentsHelper.Model;
using StudentsHelper.View.Windows;
using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class DataBaseHelper
    {
        private static string DataBaseName { get; set; } = "StudentsHelperDataBase.db";
        private static string FolderPath { get; set; } = Environment.CurrentDirectory;
    
        protected static string DataBasePath { get; set; } = System.IO.Path.Combine(FolderPath, DataBaseName);

        
    }
}
