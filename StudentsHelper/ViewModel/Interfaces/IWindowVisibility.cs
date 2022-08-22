using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel.Interfaces
{
    public interface IWindowVisibility
    {
        //This interface refers to MainWindow.xaml, it is implemented by user controls to hide them and show them
        public void SetWindowHidden();
        public void SetWindowVisible();
    }
}
