﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.DataValidators
{
    public static class ExamDataValidator
    {
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brak danych o nazwie przedmiotu do egzaminu", nameof(name));
            }
            if (!(name.Length >= 1 && name.Length <= 100))
            {
                throw new ArgumentException("Długość nazwy przedmiotu do egzaminu spoza zakresu znaków 1-100", nameof(name));
            }
            if (!name.All(Helper.IsLetterOrDigitOrSpace))
            {
                throw new ArgumentException("Nazwa przedmiotu do egzaminu zawiera inne znaki niż litery i cyfry", nameof(name));
            }
            return true;
        }

        public static bool ValidateDateOfExam(DateTime dateOfExam)
        {
            if (!(dateOfExam.Year >= DateTime.MinValue.Year && dateOfExam.Year <= DateTime.MaxValue.Year))
            {
                throw new ArgumentException("Niepoprawna wartość roku", nameof(dateOfExam));
            }
            if (!(dateOfExam.Month >= 1 && dateOfExam.Month <= 12))
            {
                throw new ArgumentException("Niepoprawna wartość miesiąca", nameof(dateOfExam));
            }
            if (!(dateOfExam.Day >= 1 && dateOfExam.Day <= DateTime.DaysInMonth(dateOfExam.Year, dateOfExam.Month)))
            {
                throw new ArgumentException("Niepoprawna wartość dnia", nameof(dateOfExam));
            }
            return true;
        }

        public static bool ValidateHourOfExam(int? hourOfExam)
        {
            if (!(hourOfExam >= 0 && hourOfExam <= 12))
            {
                throw new ArgumentException("Godzina egzaminu spoza zakresu 0-12", nameof(hourOfExam));
            }           
            return true;
        }

        public static bool ValidateMinuteOfExam(int? minuteOfExam)
        {
            if (!(minuteOfExam >= 0 && minuteOfExam <= 59))
            {
                throw new ArgumentException("Minuta egzaminu spoza zakresu 0-59", nameof(minuteOfExam));
            }
            return true;
        }

        public static bool ValidateRoomNumber(int? roomNumber)
        {
            if(!(roomNumber >= 0 && roomNumber <= int.MaxValue))
            {
                throw new ArgumentException($"Numer sali egzaminacyjnej spoza zakresu 0-{int.MaxValue}", nameof(roomNumber));
            }
            return true;
        }

        public static bool ValidateRoomLetter(string roomLetter)
        {
            if (!(roomLetter.Length >= 0 && roomLetter.Length <= 10))
            {
                throw new ArgumentException($"Długość oznaczenia litery sali egzaminacyjnej spoza zakresu 0-10", nameof(roomLetter));
            }
            if (roomLetter.All(char.IsLetter))
            {
                throw new ArgumentException($"Inne znaki niż litera w oznaczeniu litery sali egzaminacyjnej", nameof(roomLetter));
            }
            return true;
        }

        public static bool ValidateNote(string note)
        {
            if (!(note.Length >= 1 && note.Length <= 500))
            {
                throw new ArgumentException("Długość notatki o egzaminie spoza zakresu znaków 1-500", nameof(note));
            }
            return true;
        }
    }
}