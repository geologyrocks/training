using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var text = File.ReadAllText(@"..\..\..\Input.txt");
            Console.WriteLine(text);
            var passportsList = text.Split(';');
            var totalPassportsCount = passportsList.Count();
            int validPassportsCount = 0;
            int invalidPassportsCount = 0;
            var permittedList = new List<string>()
            {
                "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid"
            };
            foreach (var passportAsString in passportsList)
            {
                var passportFields = passportAsString.Split(',');
                if (passportFields.Count() > 6)
                {
                    var intersection = permittedList.Intersect(passportFields);
                    if (intersection.Count() > 6 )
                    {
                        validPassportsCount++;
                    }
                    else
                    {
                        invalidPassportsCount++;
                    }
                }
                else
                {
                    invalidPassportsCount++;
                }
            }
            Console.WriteLine($"Out of {totalPassportsCount} passports, {validPassportsCount} are valid, and {invalidPassportsCount} are invalid");
        }
    }
}
