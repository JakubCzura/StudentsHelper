using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StudentsHelper.DataValidators
{
    public static class HomeworkDataValidator
    {
        public static bool ValidateLessonName(string lessonName)
        {
            if (string.IsNullOrWhiteSpace(lessonName))
            {
                throw new ArgumentException("Brak danych o nazwie przedmiotu", nameof(lessonName));
            }
            if (!(lessonName.Length >=1 && lessonName.Length <= 100))
            {
                throw new ArgumentException("Długość nazwy przedmiotu spoza zakresu znaków 1-100", nameof(lessonName));
            }
            if (!lessonName.All(Helper.IsLetterOrDigitOrSpace))
            {
                throw new ArgumentException("Nazwa przedmiotu zawiera inne znaki niż litery i cyfry", nameof(lessonName));
            }
            return true;
        }

        public static bool ValidateDateOfEnd(DateTime dateOfEnd)
        {
            if (!(dateOfEnd.Year >= DateTime.MinValue.Year && dateOfEnd.Year <= DateTime.MaxValue.Year))
            {
                throw new ArgumentException("Niepoprawna wartość roku", nameof(dateOfEnd));
            }
            if (!(dateOfEnd.Month >= 1 && dateOfEnd.Month <= 12))
            {
                throw new ArgumentException("Niepoprawna wartość miesiąca", nameof(dateOfEnd));
            }
            if (!(dateOfEnd.Day >= 1 && dateOfEnd.Day <= DateTime.DaysInMonth(dateOfEnd.Year, dateOfEnd.Month)))
            {
                throw new ArgumentException("Niepoprawna wartość dnia", nameof(dateOfEnd));
            }
            return true;
        }

        public static bool ValidateExercise(string exercise)
        {
            if (string.IsNullOrWhiteSpace(exercise))
            {
                throw new ArgumentException("Brak danych o zadaniu domowym", nameof(exercise));
            }
            if (!(exercise.Length >= 1 && exercise.Length <= 100))
            {
                throw new ArgumentException("Długość zadania domowego spoza zakresu znaków 1-100", nameof(exercise));
            }
            return true;
        }

        public static bool ValidateNote(string note)
        {
            if (!(note.Length <= 500))
            {
                throw new ArgumentException("Długość notatki do zadania domowego spoza zakresu znaków 0-500", nameof(note));
            }
            return true;
        }

        public static bool ValidateHomeworkData(Homework homework)
        {
            if (ValidateLessonName(homework.LessonName) &&
                ValidateDateOfEnd(homework.DateOfEnd) &&
                ValidateExercise(homework.Exercise) &&
                ValidateNote(homework.Note))
            {
                return true;
            }
            return false;
        }
    }
}
