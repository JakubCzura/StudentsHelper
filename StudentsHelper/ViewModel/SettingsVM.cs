using StudentsHelper.ViewModel.Commands;

namespace StudentsHelper.ViewModel
{
    public class SettingsVM : BaseViewModel
    {
        //This class refers to SettingsUserControl.xaml
        public SettingsVM()
        {
            Instance = this;

        }

        public static SettingsVM? Instance { get; set; }


        
            
    }
}
