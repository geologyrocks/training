using System;
using System.Collections.Generic;
using System.Text;

namespace MiscLanguageFeatures
{
    public class RangesIndicesDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nRangesIndicesDemo");
            Console.WriteLine("------------------------------------------------------");

            var deers = new string[] { "Rudolph", "Dasher", "Dancer", "Donner", "Prancer", "Vixen", "Comet", "Cupid", "Blitzen" };

            DisplayArray("deers       ", deers);

            var deers2to5 = deers[2..5];
            DisplayArray("deers[2..5] ", deers2to5);

            var deersUpto5 = deers[..5];
            DisplayArray("deers[..5]  ", deersUpto5);

            var deersFrom5 = deers[5..];
            DisplayArray("deers[5..]  ", deersFrom5);

            var last = deers[^1];
            Console.WriteLine($"deers[^1]   {last}");

            var penultimate = deers[^2];
            Console.WriteLine($"deers[^2]   {penultimate}");

            var last5 = deers[^5..];
            DisplayArray("deers[^5..] ", last5);

            var notLast5 = deers[..^5];
            DisplayArray("deers[..^5] ", notLast5);
        }

        private static void DisplayArray(string message, string[] array)
        {
            Console.Write(message);
            
            foreach (string s in array)
                Console.Write($"{s} ");

            Console.WriteLine();
        }
    }
}
