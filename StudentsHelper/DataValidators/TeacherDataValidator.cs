using StudentsHelper.Model;
using System;
using System.Linq;

namespace StudentsHelper.DataValidators
{
    public static class TeacherDataValidator
    {
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brak danych o imieniu", nameof(name));
            }
            if (!(name.Length >= 1 && name.Length <= 100))
            {
                throw new ArgumentException("Długość imienia spoza zakresu znaków 1-100", nameof(name));
            }
            if (!name.All(Helper.IsLetterOrSpaceOrHyphen))
            {
                throw new ArgumentException("Imie zawiera inne znaki niż litery", nameof(name));
            }
            return true;
        }

        public static bool ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Brak danych o nazwisku", nameof(lastName));
            }
            if (!(lastName.Length >= 1 && lastName.Length <= 100))
            {
                throw new ArgumentException("Długość nazwiska spoza zakresu znaków 1-100", nameof(lastName));
            }
            if (!lastName.All(Helper.IsLetterOrSpaceOrHyphen))
            {
                throw new ArgumentException("Nazwisko zawiera inne znaki niż litery", nameof(lastName));
            }
            return true;
        }

        public static bool ValidateLesson(string lesson)
        {
            if (string.IsNullOrWhiteSpace(lesson))
            {
                throw new ArgumentException("Brak danych o nazwie przedmiotu", nameof(lesson));
            }
            if (!(lesson.Length >= 1 && lesson.Length <= 100))
            {
                throw new ArgumentException("Długość nazwy przedmiotu spoza zakresu znaków 1-100", nameof(lesson));
            }
            if (!lesson.All(Helper.IsLetterOrDigitOrSpace))
            {
                throw new ArgumentException("Nazwa przedmiotu zawiera inne znaki niż litery i cyfry", nameof(lesson));
            }
            return true;
        }

        public static bool ValidateDegree(string degree)
        {
            if (string.IsNullOrWhiteSpace(degree))
            {
                throw new ArgumentException("Brak danych o stopniu nałkowym", nameof(degree));
            }
            if (!(degree.Length >= 1 && degree.Length <= 100))
            {
                throw new ArgumentException("Długość stopnia nałkowego spoza zakresu znaków 1-100", nameof(degree));
            }
            if (!degree.All(Helper.IsLetterOrSpace))
            {
                throw new ArgumentException("Stopień naukowy zawiera inne znaki niż litery i cyfry", nameof(degree));
            }
            return true;
        }

        public static bool ValidateRoomNumber(int roomNumber)
        {
            if (!(roomNumber >= 0 && roomNumber < int.MaxValue))
            {
                throw new ArgumentException($"Numer pokoju spoza zakresu 0-{int.MaxValue}", nameof(roomNumber));
            }
            return true;
        }

        public static bool ValidateNote(string note)
        {
            if (!(note.Length <= 500))
            {
                throw new ArgumentException("Długość notatki do wykładowcy spoza zakresu znaków 0-500", nameof(note));
            }
            return true;
        }

        public static bool ValidateTeacherData(Teacher teacher)
        {
            if (ValidateName(teacher.Name) &&
                ValidateLastName(teacher.LastName) &&
                ValidateDegree(teacher.Degree) &&
                ValidateLesson(teacher.Lesson) &&
                ValidateNote(teacher.Note) &&
                ValidateRoomNumber(teacher.RoomNumber))
            {
                return true;
            }
            return false;
        }
    }
}