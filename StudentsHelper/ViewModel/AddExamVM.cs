using StudentsHelper.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.ViewModel
{
    internal class AddExamVM
    {
        public AddExamVM()
        {
            CloseWindowCommand = new CloseWindowCommand(this);
        }

        public CloseWindowCommand CloseWindowCommand { get; set; }

    }
}
