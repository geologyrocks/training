using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DemoDotNetAPIs
{
    static class RegularExpressionsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("RegularExpressionsDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoPatternMatching();
            DemoMultipleMatches();
            DemoReplaceSubstrings();
            DemoGroups();

        }


        private static void DemoPatternMatching()
        {
            Console.WriteLine("\nDemoPatternMatching");
            Console.WriteLine("-------------------------");

            string pattern = @"^[a-z]{1,2}\d{1,2}\s\d[a-z]{2}$";

            string[] postcodes = { "N1 5BR", "NW1 5BR", "NWW1 5BR", "N23 5BR", "N234 5BR", "N23 55BR", "M23 5BRR" };

            foreach (string postcode in postcodes)
            {
                Console.WriteLine("{0} valid?\t{1}", postcode, Regex.IsMatch(postcode, pattern, RegexOptions.IgnoreCase));
            }
        }


        private static void DemoMultipleMatches()
        {
            Console.WriteLine("\nDemoMultipleMatches");
            Console.WriteLine("-------------------------");

            string pattern = @",?\w+\scity";

            string teams = "Swansea city, Bradford City, Arsenal, Spurs";

            foreach (Match match in Regex.Matches(teams, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
            }
        }
        
        
        private static void DemoReplaceSubstrings()
        {
            Console.WriteLine("\nDemoReplaceSubstrings");
            Console.WriteLine("-------------------------");

            string pattern = @"(Mr\.? |Mrs\.? |Miss |Ms\.? |Dr\.? )";

            string[] names = { "Mr James Bond", "Ms. Moneypenny", "mrs Smith", "Q", "Dr. No" };

            foreach (string name in names)
            {
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty, RegexOptions.IgnoreCase));
            }            
        }

        private static void DemoGroups()
        {
            Console.WriteLine("\nDemoGroups");
            Console.WriteLine("-------------------------");

            string pattern = @"\b(\w+)\s\1\b";

            string input = "Gwlad Gwlad Pleidiol wyf i'm wlad! Wales Wales Wales";

            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("{0} (duplicates '{1}') at position {2}",
                                  match.Value,
                                  match.Groups[1].Value,
                                  match.Index);
            }
        }
    }
}
