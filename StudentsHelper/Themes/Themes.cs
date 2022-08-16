using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.Themes
{
    public class Themes
    {
        public enum AppThemes
        {
            Standard = 0,
            Green = 1,
            Pink = 2,
            Blue = 3,
            Yellow = 4
        }


        public static List<string> GetThemes()
        {
            return Enum.GetValues(typeof(AppThemes))
                       .Cast<AppThemes>()
                       .Select(v => v.ToString())
                       .ToList();
        }

        private static string DataPath = Path.Combine(Environment.CurrentDirectory, "ThemesData.txt");

        public static void SaveTheme(string theme)
        {
            try
            {
                using (StreamWriter StreamWriter = new StreamWriter(DataPath, false))
                {
                    StreamWriter.WriteLine(theme.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public static string ReadTheme()
        {
            try
            {
                using (StreamReader StreamReader = new StreamReader(DataPath))
                {
                    return StreamReader.ReadLine();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return AppThemes.Standard.ToString();
            }
        }

        public static void SetTheme()
        {
            try
            {
                App.Current.Resources.Clear();
                App.Current.Resources.Source = new Uri($"/Themes/{ReadTheme()}.xaml", UriKind.Relative);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

    }
}
