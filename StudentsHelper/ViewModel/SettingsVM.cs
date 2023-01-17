using StudentsHelper.ViewModel.Commands;
using System.Windows.Input;

namespace StudentsHelper.ViewModel
{
    public class SettingsVM : BaseViewModel
    {
        //This class refers to SettingsUserControl.xaml
        public SettingsVM()
        {
            Instance = this;
            SelectSettingsContentCommand = new SelectSettingsContentCommand(this);
            SelectedSettingsContent = new PasswordChangeVM();
        }

        public ICommand SelectSettingsContentCommand { get; private set; }

        private BaseViewModel selectedSettingsContent;

        public BaseViewModel SelectedSettingsContent
        {
            get { return selectedSettingsContent; }
            set { selectedSettingsContent = value; OnPropertyChanged(nameof(SelectedSettingsContent)); }
        }

        public static SettingsVM? Instance { get; set; }
    }
}