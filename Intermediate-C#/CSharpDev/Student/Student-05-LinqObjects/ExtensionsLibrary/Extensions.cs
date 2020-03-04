using System;
using System.Collections.Generic;

namespace ExtensionsLibrary
{
    public static class Extensions
    {
        //double
        public static bool IsWithinRange(this double dub, double minNumber, double maxNumber) => dub >= minNumber && dub < maxNumber ? true : false;
        //string
        public static string IsStrongPassword(this string pwd)
        {
            bool result = false;
            bool puncCheck = false;
            bool numCheck = false;
            bool lowCheck = false;
            bool upCheck = false;
            if (pwd.Length < 8)
            {
                return $"Password {pwd} is not strong";
            }
            foreach (var substring in pwd)
            {
                puncCheck = char.IsPunctuation(substring) ? true : puncCheck;
                numCheck = char.IsNumber(substring) ? true : numCheck;
                lowCheck = char.IsLower(substring) ? true : lowCheck;
                upCheck = char.IsUpper(substring) ? true : upCheck;
            }
            result = puncCheck && numCheck && lowCheck && upCheck;
            return result ? $"Password {pwd} is strong" : $"Password {pwd} is not strong";
        }

    }
}
