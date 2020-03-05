using System;
using System.Collections.Generic;
using System.Linq;

namespace UsingLinqCollections
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            int[] ints = { 2, 4, 5, 3, 6, 1 };
            var allQuery = from i in ints
                           select i;
            Output(allQuery);

            var ascQuery = from i in ints
                           orderby i
                           select i;
            Output(ascQuery);

            var descQuery = from i in ints
                            orderby i
                            descending
                            select i;
            Output(descQuery);

            var squaresQuery = from i in ints
                               orderby i
                               select i * i;
            Output(squaresQuery);

            var sqQuery = ints.Select(i => i * i);
            Output(sqQuery);

            var oddQuery = from i in ints
                           orderby i
                           where i % 2 != 0
                           select i;
            Output(oddQuery);

            var sumQuery = ints.Sum();
            Output(sumQuery);

            var averageQuery = ints.Average();
            Output(averageQuery);

            var maxQuery = ints.Max();
            Output(maxQuery);

            var minQuery = ints.Min();
            Output(minQuery);
        }

        public static void Output(IEnumerable<int> query)
        {
            Console.WriteLine("");
            foreach (var part in query)
            {
                Console.WriteLine(part);
            }
        }
        public static void Output(double query)
        {
            Console.WriteLine($"\n{query}");
        }
    }
}
