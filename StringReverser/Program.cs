using System;

namespace StringReverser
{
    class Program
    {
        static void Main()
        {
            // Problem: Write a while loop that starts at the last character in the string and works its way backwards to the first character in the string, printing each letter on a separate line.
            var inputString = "A slightly long string";
            var i = inputString.Length-1;
            while (i >= 0)
            {
                Console.WriteLine(inputString[i]);
                i -= 1;
            }
        }
    }
}
