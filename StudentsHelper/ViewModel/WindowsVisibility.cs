using StudentsHelper.View.UserControls;
using StudentsHelper.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    public class WindowsVisibility
    {
        /// <summary>
        /// Event for all user's duties that appear on MainWindow as user controls to show them
        /// </summary>
        public static Action? HideMainWindowDuties { get; set; }

        /// <summary>
        /// Event for all user's settings that appear on SettingsUserControl as user controls to show them
        /// </summary>
        public static Action? HideSettings { get; set; }

        /// <summary>
        /// Invoke event for all user controls that subscribe and need to be hidden
        /// </summary>
        public static void OnHideMainWindowDuties()
        {
            HideMainWindowDuties?.Invoke();
        }

        public static void OnHideSettings()
        {
            HideSettings?.Invoke();
        }
    }
}
