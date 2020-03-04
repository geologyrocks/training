using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExtensionLibrary
{
    public static class MyExtensions
    {
        public static bool InRange(this double number, double min, double max) => number >= min && number <= max;

        public static bool IsStrongPassword(this string str)
        {
            if (str.Length < 8)
                return false;

            bool digitFound = false;
            bool nonAlphanumericFound = false;
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                    digitFound = true;

                if (!char.IsLetterOrDigit(c))
                    nonAlphanumericFound = true;

                // Have we now found a digit and a non-alphanumeric?
                if (digitFound && nonAlphanumericFound)
                    return true;
            }

            // If we get this far, the string is weak password.
            return false;
        }
    }
}
