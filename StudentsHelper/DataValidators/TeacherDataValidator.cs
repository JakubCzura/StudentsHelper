using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.DataValidators
{
    public static class TeacherDataValidator
    {
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brak danych o imieniu ", nameof(name));
            }
            if (!(name.Length >= 1 && name.Length <= 100))
            {
                throw new ArgumentException("Długość imienia spoza zakresu znaków 1-100 ", nameof(name));
            }
            if (!name.All(char.IsLetter))
            {
                throw new ArgumentException("Imie zawiera inne znaki niż litery ", nameof(name));
            }
            return true;
        }

        public static bool ValidateSecondName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brak danych o nazwisku ", nameof(name));
            }
            if (!(name.Length >= 1 && name.Length <= 100))
            {
                throw new ArgumentException("Długość nazwiska spoza zakresu znaków 1-100 ", nameof(name));
            }
            if (!name.All(char.IsLetter))
            {
                throw new ArgumentException("Nazwisko zawiera inne znaki niż litery ", nameof(name));
            }
            return true;
        }

        public static bool ValidateAge(int age)
        {
            if (!(age >= 1 && age <= 100))
            {
                throw new ArgumentException("Wiek spoza zakresu 1-100 ", nameof(age));
            }
            return true;
        }

        public static bool ValidateLesson(string lesson)
        {
            if (string.IsNullOrWhiteSpace(lesson))
            {
                throw new ArgumentException("Brak danych o nazwie przedmiotu ", nameof(lesson));
            }
            if (!(lesson.Length >= 1 && lesson.Length <= 100))
            {
                throw new ArgumentException("Długość nazwy przedmiotu spoza zakresu znaków 1-100 ", nameof(lesson));
            }
            if (!lesson.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Nazwa przedmiotu zawiera inne znaki niż litery i cyfry ", nameof(lesson));
            }
            return true;
        }

        public static bool ValidateDegree(string degree)
        {
            if (string.IsNullOrWhiteSpace(degree))
            {
                throw new ArgumentException("Brak danych o stopniu nałkowym ", nameof(degree));
            }
            if (!(degree.Length >= 1 && degree.Length <= 100))
            {
                throw new ArgumentException("Długość stopnia nałkowego spoza zakresu znaków 1-100 ", nameof(degree));
            }
            if (!degree.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Stopień naukowy zawiera inne znaki niż litery i cyfry ", nameof(degree));
            }
            return true;
        }

        public static bool ValidateRoomNumber(int roomNumber)
        {
            if (!(roomNumber >= 0 && roomNumber < int.MaxValue))
            {
                throw new ArgumentException($"Numer pokoju spoza zakresu 0-{int.MaxValue} ", nameof(roomNumber));
            }
            return true;
        }
        
        public static bool ValidateNote(string note)
        {
            if (string.IsNullOrWhiteSpace(note))
            {
                throw new ArgumentException("Brak danych do notatki o wykładowcy ", nameof(note));
            }
            if (!(note.Length >= 1 && note.Length <= 500))
            {
                throw new ArgumentException("Długość notatki do wykładowcy spoza zakresu znaków 1-500 ", nameof(note));
            }
            return true;
        }
    }
}
