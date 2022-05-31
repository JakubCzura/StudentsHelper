using StudentsHelper.UserControls;
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
        public static Action? HideWindow { get; set; }

        public static Action? ShowWindow { get; set; }

        public static void OnHideWindow()
        {
            HideWindow?.Invoke();
        }

        public static void OnShowWindow()
        {
            ShowWindow?.Invoke();
        }

    }
}
