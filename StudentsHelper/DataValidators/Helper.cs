using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.DataValidators
{
    internal static class Helper
    {
        internal static bool IsLetterOrDigitOrSpace(char c)
        {
            if (char.IsLetterOrDigit(c) || c == ' ')
            {
                return true;
            }
            return false;
        }

        internal static bool IsLetterOrSpace(char c)
        {
            if (char.IsLetter(c) || c == ' ')
            {
                return true;
            }
            return false;
        }
    }
}
