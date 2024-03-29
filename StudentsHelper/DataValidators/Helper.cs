﻿namespace StudentsHelper.DataValidators
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

        internal static bool IsLetterOrSpaceOrHyphen(char c)
        {
            if (char.IsLetter(c) || c == ' ' || c == '-')
            {
                return true;
            }
            return false;
        }
    }
}