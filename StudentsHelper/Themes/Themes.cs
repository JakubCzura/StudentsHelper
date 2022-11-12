using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private static readonly string DataPath = Path.Combine(Environment.CurrentDirectory, "ThemesData.txt");
        //private static readonly string DataPath = new Uri($"/Themes/ThemesData.txt", UriKind.Relative).ToString();

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
                if (File.Exists(DataPath))
                {
                    using (StreamReader StreamReader = new StreamReader(DataPath))
                    {
                        return StreamReader.ReadLine();
                    }
                }
                else
                {
                    return AppThemes.Standard.ToString();
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
                App.Current.Resources.MergedDictionaries.Clear();
                //App.Current.Resources.Source = new Uri($"/Themes/{ReadTheme()}.xaml", UriKind.Relative);

                App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri($"/Themes/CommonTheme.xaml", UriKind.Relative) });
                App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri($"/Themes/{ReadTheme()}.xaml", UriKind.Relative) });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}