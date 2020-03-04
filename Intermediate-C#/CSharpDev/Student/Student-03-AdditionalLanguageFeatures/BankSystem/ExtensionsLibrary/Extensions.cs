using System;

namespace ExtensionsLibrary
{
    public static class Extensions
    {
        //double
        public static bool IsWithinRange(this double dub, double minNumber, double maxNumber)
        {
            return dub >= minNumber && dub < maxNumber ? true : false;
        }
        //string
        public static bool IsStrongPassword(this string pwd)
        {
            bool result = false;
            bool puncCheck = false;
            bool numCheck = false;
            bool lowCheck = false;
            bool upCheck = false;
            if (pwd.Length < 8)
            {
                return result;
            }
            foreach (var substring in pwd)
            {
                puncCheck = char.IsPunctuation(substring) ? true : puncCheck;
                numCheck = char.IsNumber(substring) ? true : numCheck;
                lowCheck = char.IsLower(substring) ? true : lowCheck;
                upCheck = char.IsUpper(substring) ? true : upCheck;
            }
            result = puncCheck && numCheck && lowCheck && upCheck;
            return result;
        }
    }
}
