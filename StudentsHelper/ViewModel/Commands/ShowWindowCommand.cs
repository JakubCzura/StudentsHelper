using StudentsHelper.View.Windows;
using System;
using System.Windows;
using System.Windows.Input;

namespace StudentsHelper.ViewModel.Commands
{
    public class ShowWindowCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Window? Window { get; set; }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                try
                {
                    Window = parameter.ToString() switch
                    {
                        "AddExam" => new AddExamWindow(),
                        "AddHomework" => new AddHomeworkWindow(),
                        "AddNote" => new AddNoteWindow(),
                        "AddTeacher" => new AddTeacherWindow(),
                        "AddTest" => new AddTestWindow(),
                        "Authors" => new AuthorsWindow(),
                        "ScheduleInstruction" => new ScheduleInstructionWindow(),
                        _ => null,
                    };
                    if (Window != null)
                    {
                        Window.Show();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}