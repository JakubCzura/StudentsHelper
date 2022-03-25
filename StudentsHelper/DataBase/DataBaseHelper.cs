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
        
        //private static string FolderPath { get; set; } = Environment.CurrentDirectory;
        private static string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.Create);

        protected static string DataBasePath { get; set; } = System.IO.Path.Combine(FolderPath, DataBaseName);

        public static int StudentId { get; set; } = -1;

        public static string StudentLogin { get; set; } = string.Empty;
        
    }
}
