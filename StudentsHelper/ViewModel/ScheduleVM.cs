using CommunityToolkit.Mvvm.Input;
using StudentsHelper.Model;
using StudentsHelper.Schedules;
using StudentsHelper.View.UserControls;
using StudentsHelper.View.Windows;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class ScheduleVM : BaseViewModel
    {
        //This class refers to ScheduleUserControl.xaml
        public ScheduleVM()
        {
            Instance = this;
            Student = DataBase.ObjectsDataGetter.GetStudentData();
            ShowScheduleInstructionWindowCommand = new RelayCommand(ShowScheduleInstructionWindow);
            GetScheduleCommand = new AsyncRelayCommand(GetScheduleAsync);
            ScheduleImporter.SetSchedule();
        }

        private async Task GetScheduleAsync()
        {
            try
            {
                if (ScheduleUserControl.Instance != null)
                {
                    if (string.IsNullOrEmpty(ScheduleUserControl.Instance.UserPasswordPasswordBox.Password) == false)
                    {
                        IsGetScheduleButtonEnabled = false;
                        if (ScheduleUserControl.Instance != null)
                        {
                            ScheduleUserControl.Instance.UserPasswordPasswordBox.IsEnabled = false;
                            if (await ScheduleDownloader.DownloadScheduleAsync(Student.Email, ScheduleUserControl.Instance.UserPasswordPasswordBox.Password))
                            {
                                if (await ScheduleDownloader.IsScheduleDownloadedAsync() == true)
                                {
                                    ScheduleImporter.SetSchedule();
                                }
                                else
                                {
                                    MessageBox.Show("Jeśli plan zajęć nie załadował się automatycznie, proszę jeszcze raz kliknąć przycisk\n" +
                                        "Pobierz plan w celu pobrania planu zajęć lub\n" +
                                        "Plan zajęć w celu odświeżenia okna");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd pobrania planu zajęć");
            }
            finally
            {
                IsGetScheduleButtonEnabled = true;
                if (ScheduleUserControl.Instance != null)
                {
                    ScheduleUserControl.Instance.UserPasswordPasswordBox.IsEnabled = true;
                    ScheduleUserControl.Instance.UserPasswordPasswordBox.Password = String.Empty;
                }
            }
        }

        private void ShowScheduleInstructionWindow()
        {
            ScheduleInstructionWindow ScheduleInstructionWindow = new();
            ScheduleInstructionWindow.Show();
        }

        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(nameof(Student)); }
        }

        public static ScheduleVM? Instance { get; set; }
        public ICommand GetScheduleCommand { get; private set; }
        public ICommand ShowScheduleInstructionWindowCommand { get; private set; }

        private static bool isGetScheduleButtonEnabled = true;

        public bool IsGetScheduleButtonEnabled
        {
            get { return isGetScheduleButtonEnabled; }
            set { isGetScheduleButtonEnabled = value; OnPropertyChanged(nameof(IsGetScheduleButtonEnabled)); }
        }

        /// <summary>
        /// Dispose ScheduleWebBrowser in ScheduleUserControl
        /// </summary>
        public static void DisposeScheduleWebBrowser()
        {
            ScheduleUserControl.Instance?.ScheduleWebBrowser.Dispose();
        }

        /// <summary>
        /// Initialize ScheduleWebBrowser in ScheduleUserControl, this control needs to invoke Dispose() explicitly
        /// </summary>
        public static void InitializeScheduleWebBrowser()
        {
            if (ScheduleUserControl.Instance != null)
            {
                ScheduleUserControl.Instance.ScheduleWebBrowser = new System.Windows.Controls.WebBrowser();
            }
        }
    }
}