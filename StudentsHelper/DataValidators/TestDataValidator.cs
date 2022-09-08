using StudentsHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.DataValidators
{
    public class TestDataValidator
    {                  
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brak danych o nazwie przedmiotu do kolokwium", nameof(name));
            }
            if (!(name.Length >= 1 && name.Length <= 100))
            {
                throw new ArgumentException("Długość nazwy przedmiotu do kolokwium spoza zakresu znaków 1-100", nameof(name));
            }
            if (!name.All(Helper.IsLetterOrDigitOrSpace))
            {
                throw new ArgumentException("Nazwa przedmiotu do kolokwium zawiera inne znaki niż litery i cyfry", nameof(name));
            }
            return true;
        }

        public static bool ValidateDateOfTest(DateTime dateOfTest)
        {
            if (!(dateOfTest.Year >= DateTime.MinValue.Year && dateOfTest.Year <= DateTime.MaxValue.Year))
            {
                throw new ArgumentException("Niepoprawna wartość roku", nameof(dateOfTest));
            }
            if (!(dateOfTest.Month >= 1 && dateOfTest.Month <= 12))
            {
                throw new ArgumentException("Niepoprawna wartość miesiąca", nameof(dateOfTest));
            }
            if (!(dateOfTest.Day >= 1 && dateOfTest.Day <= DateTime.DaysInMonth(dateOfTest.Year, dateOfTest.Month)))
            {
                throw new ArgumentException("Niepoprawna wartość dnia", nameof(dateOfTest));
            }
            return true;
        }

        public static bool ValidateHourOfTest(int? hourOfTest)
        {
            if (!(hourOfTest >= 0 && hourOfTest <= 23))
            {
                throw new ArgumentException("Godzina kolokwium spoza zakresu 0-23", nameof(hourOfTest));
            }
            return true;
        }

        public static bool ValidateMinuteOfTest(int? minuteOfTest)
        {
            if (!(minuteOfTest >= 0 && minuteOfTest <= 59))
            {
                throw new ArgumentException("Minuta kolokwium spoza zakresu 0-59", nameof(minuteOfTest));
            }
            return true;
        }

        public static bool ValidateRoomNumber(int? roomNumber)
        {
            if (!(roomNumber >= 0 && roomNumber <= int.MaxValue))
            {
                throw new ArgumentException($"Numer sali do kolokwium spoza zakresu 0-{int.MaxValue}", nameof(roomNumber));
            }
            return true;
        }

        public static bool ValidateRoomLetter(string roomLetter)
        {
            if (!(roomLetter.Length >= 0 && roomLetter.Length <= 10))
            {
                throw new ArgumentException($"Długość oznaczenia litery sali do kolokwium spoza zakresu 0-10", nameof(roomLetter));
            }
            //if (roomLetter.All(char.IsLetter))
            //{
            //    throw new ArgumentException($"Inne znaki niż litera w oznaczeniu litery sali do kolokwium", nameof(roomLetter));
            //}
            return true;
        }

        public static bool ValidateNote(string note)
        {
            if (!(note.Length >= 1 && note.Length <= 500))
            {
                throw new ArgumentException("Długość notatki o kolokwium spoza zakresu znaków 1-500", nameof(note));
            }
            return true;
        }

        public static bool ValidateTestData(Test test)
        {
            if (ValidateName(test.Name) &&
                ValidateDateOfTest(test.DateOfTest) &&
                ValidateHourOfTest(test.HourOfTest) &&
                ValidateMinuteOfTest(test.MinuteOfTest) &&
                ValidateRoomNumber(test.RoomNumber) &&
                ValidateRoomLetter(test.RoomLetter) &&
                ValidateNote(test.Note))
            {
                return true;
            }
            return false;
        }
    }
}
