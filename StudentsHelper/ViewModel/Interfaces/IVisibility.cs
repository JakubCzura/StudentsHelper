using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel.Interfaces
{
    public interface IVisibility
    {
        //This interface is implemented by user controls to hide them and show them

        /// <summary>
        /// This method is implemented by user control to hide it
        /// </summary>
        public void SetHidden();

        /// <summary>
        /// This method is implemented by user control to show it
        /// </summary>
        public void SetVisible();
    }
}
