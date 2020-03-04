using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmailValidator
{
    class Program
    {
        static void Main()
        {
            // Step 1: create new Regex.
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$");
            var allRegexList = new List<string>()
            {
                new string("\n\n\n\n\nThese are all attempted entries:")
            };
            var isRegexList = new List<string>()
            {
                new string("\nThese are all valid email addresses:")
            };
            var notRegexList = new List<string>()
            {
                new string("\nThese email addresses are not valid:")

            };
            var input = "";
            while (input.ToLower() != "quit")
            {
                input = Console.ReadLine();
                // Step 2: call Match on Regex instance.
                Match match = regex.Match(input);

                // Step 3: test for Success.
                if (match.Success)
                {
                    isRegexList.Add(input);
                    Console.WriteLine($"{input} is a valid email address.");
                }
                else
                {
                    notRegexList.Add(input);
                    Console.WriteLine($"{input} is not a valid email address.");
                }
            }
            allRegexList.AddRange(isRegexList);
            allRegexList.AddRange(notRegexList);
            foreach (var entry in allRegexList)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
