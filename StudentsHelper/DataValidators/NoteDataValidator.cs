using StudentsHelper.Model;
using System;
using System.Linq;

namespace StudentsHelper.DataValidators
{
    public static class NoteDataValidator
    {
        public static bool ValidateDate(DateTime date)
        {
            if (!(date.Year >= DateTime.MinValue.Year && date.Year <= DateTime.MaxValue.Year))
            {
                throw new ArgumentException("Niepoprawna wartość roku", nameof(date));
            }
            if (!(date.Month >= 1 && date.Month <= 12))
            {
                throw new ArgumentException("Niepoprawna wartość miesiąca", nameof(date));
            }
            if (!(date.Day >= 1 && date.Day <= DateTime.DaysInMonth(date.Year, date.Month)))
            {
                throw new ArgumentException("Niepoprawna wartość dnia", nameof(date));
            }
            return true;
        }

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brak danych o tytule notatki", nameof(name));
            }
            if (!(name.Length >= 1 && name.Length <= 100))
            {
                throw new ArgumentException("Długość tytułu notatki spoza zakresu znaków 1-100", nameof(name));
            }
            if (!name.All(Helper.IsLetterOrDigitOrSpace))
            {
                throw new ArgumentException("Tytuł notatki zawiera inne znaki niż litery i cyfry", nameof(name));
            }
            return true;
        }

        public static bool ValidateContent(string content)
        {
            if (!(content.Length <= 500))
            {
                throw new ArgumentException("Długość notatki spoza zakresu znaków 1-500", nameof(content));
            }
            if (!content.All(Helper.IsLetterOrDigitOrSpace))
            {
                throw new ArgumentException("Notatka zawiera inne znaki niż litery i cyfry", nameof(content));
            }
            return true;
        }

        public static bool ValidateNoteData(Note note)
        {
            if (ValidateDate(note.Date) &&
                ValidateName(note.Name) &&
                ValidateContent(note.Content))
            {
                return true;
            }
            return false;
        }
    }
}