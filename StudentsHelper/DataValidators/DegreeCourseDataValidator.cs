using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.DataValidators
{
    public static class DegreeCourseDataValidator
    {
        public static bool ValidateCourse(string course)
        {
            if (string.IsNullOrWhiteSpace(course))
            {
                throw new ArgumentException("Brak danych o kierunku studiów", nameof(course));
            }
            if (!(course.Length >= 1 && course.Length <= 100))
            {
                throw new ArgumentException("Długość kierunku studiów spoza zakresu znaków 1-100", nameof(course));
            }
            if (!course.All(Helper.IsLetterOrDigitOrSpace))
            {
                throw new ArgumentException("Nazwa kierunku studiów zawiera inne znaki niż litery i cyfry", nameof(course));
            }
            return true;
        }

        public static bool ValidateSemester(int semester)
        {
            if (!(semester >= 1 && semester <= 30))
            {
                throw new ArgumentException($"Semestr studiów spoza zakresu 1-30", nameof(semester));
            }
            return true;
        }

        public static bool ValidateSpeciality(string speciality)
        {
            if (!(speciality.Length >= 0 && speciality.Length <= 100))
            {
                throw new ArgumentException("Długość specjalizacji studiów spoza zakresu znaków 0-100", nameof(speciality));
            }
            if (!(speciality.All(Helper.IsLetterOrDigitOrSpace)))
            {
                throw new ArgumentException("Nazwa specjalizacji studiów zawiera inne znaki niż litery i cyfry", nameof(speciality));
            }
            return true;
        }

        public static bool ValidateFaculty(string faculty)
        {
            if(string.IsNullOrWhiteSpace(faculty))
            {
                throw new ArgumentException("Brak danych o wydziale", nameof(faculty));
            }
            if (!(faculty.Length >= 1 && faculty.Length <= 100))
            {
                throw new ArgumentException("Długość nazwy wydziału spoza zakresu znaków 1-100", nameof(faculty));
            }
            if (!(faculty.All(Helper.IsLetterOrDigitOrSpace)))
            {
                throw new ArgumentException("Nazwa wydziału zawiera inne znaki niż litery i cyfry", nameof(faculty));
            }
            return true;
        }
    }
}
