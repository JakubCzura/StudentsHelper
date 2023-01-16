using StudentsHelper.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StudentsHelper.DataValidators
{
    public static class StudentDataValidator
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

        public static bool ValidateSecondName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brak danych o nazwisku", nameof(name));
            }
            if (!(name.Length > 1 && name.Length <= 100))
            {
                throw new ArgumentException("Długość nazwiska spoza zakresu znaków 1-100", nameof(name));
            }
            if (!name.All(Helper.IsLetterOrSpaceOrHyphen))
            {
                throw new ArgumentException("Nazwisko zawiera inne znaki niż litery", nameof(name));
            }
            return true;
        }

        public static bool ValidateAge(int age)
        {
            if (!(age >= 1 && age <= 100))
            {
                throw new ArgumentException("Wiek spoza zakresu 1-100", nameof(age));
            }
            return true;
        }

        public static bool ValidateLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("Brak danych o loginie", nameof(login));
            }
            if (login.Length != 7)
            {
                throw new ArgumentException("Długość loginu jest inna niż 7, uwzględaniając literę 's'", nameof(login));
            }
            if (!login.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("LogIn zawiera inne znaki niż litery i cyfry", nameof(login));
            }
            if (!login.StartsWith('s'))
            {
                throw new ArgumentException("LogIn musi zaczynać się od litery 's' i zawierać 6 cyfr", nameof(login));
            }
            if (!login.Substring(1).All(char.IsDigit))
            {
                throw new ArgumentException("LogIn musi zaczynać się od litery 's' i zawierać 6 cyfr", nameof(login));
            }
            return true;
        }

        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Brak danych o haśle", nameof(password));
            }
            if (!(password.Length >= 5))
            {
                throw new ArgumentException("Długość hasła ma mniej niż 5 znaków", nameof(password));
            }
            if (!password.Any(char.IsDigit))
            {
                throw new ArgumentException("Hasło musi zawierać conajmniej jedną cyfrę", nameof(password));
            }
            if (!password.Any(char.IsLower))
            {
                throw new ArgumentException("Hasło musi zawierać conajmniej jedną małą literę", nameof(password));
            }
            if (!password.Any(char.IsUpper))
            {
                throw new ArgumentException("Hasło musi zawierać conajmniej jedną dużą literę", nameof(password));
            }
            return true;
        }

        public static bool ValidateEmail(string email)
        {
            EmailAddressAttribute EmailAddressAttribute = new EmailAddressAttribute();

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Brak danych o email-u", nameof(email));
            }
            if (EmailAddressAttribute.IsValid(email) == false)
            {
                throw new ArgumentException($"Nieprawidłowy adres email", nameof(email));
            }
            return true;
        }

        public static bool ValidateStudentData(Student student)
        {
            if (ValidateName(student.Name) &&
                ValidateSecondName(student.SecondName) &&
                ValidateAge(student.Age) &&
                ValidateLogin(student.Login) &&
                ValidatePassword(student.Password) &&
                ValidateEmail(student.Email))
            {
                return true;
            }
            return false;
        }
    }
}