using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUnderTheHood
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoOperators();
            DemoAnonymousMethods();
            DemoLambdaExpressions();
        }


        private static void DemoOperators()
        {
            string[] cities = { "Boston", "New York", "Dallas", "St. Paul", "Las Vegas" };

            // Create a LINQ query expression using C# query operators.
            var subset = from c in cities
                         where c.Contains(" ")
                         orderby c.Length
                         select c;

            Console.WriteLine("Cities with spaces (using C# query operators): ");
            foreach (var c in subset)
                Console.WriteLine($"City: {c}");
        }


        private static void DemoAnonymousMethods()
        {
            string[] cities = { "Boston", "New York", "Dallas", "St. Paul", "Las Vegas" };

            // Build Func<> delegates for Where(), OrderBy(), and Select() extension methods.
            Func<string, bool> whereFunc = delegate (string c) { return c.Contains(" "); };
            Func<string, int> orderbyFunc = delegate (string c) { return c.Length; };
            Func<string, string> selectFunc = delegate (string c) { return c; };

            // Pass the Func<> delegates into extension methods.
            var subset = cities.Where(whereFunc)
                               .OrderBy(orderbyFunc)
                               .Select(selectFunc);

            Console.WriteLine("\nCities with spaces (using anonymous methods): ");
            foreach (var c in subset)
                Console.WriteLine($"City: {c}");
        }


        private static void DemoLambdaExpressions()
        {
            string[] cities = { "Boston", "New York", "Dallas", "St. Paul", "Las Vegas" };

            // Pass lambda expressions into extension methods
            var subset = cities.Where(c => c.Contains(" "))
                                .OrderBy(c => c.Length)
                                .Select(c => c);

            Console.WriteLine("\nCities with spaces (using lambda expressions): ");
            foreach (var s in subset)
                Console.WriteLine($"City: {s}");
        }
    }
}
