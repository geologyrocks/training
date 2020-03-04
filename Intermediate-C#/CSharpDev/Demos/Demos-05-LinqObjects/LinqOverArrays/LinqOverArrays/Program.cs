using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment the following statements to run different parts of the demo,

            DemoNonLinq();

            // DemoLinq();

            // DemoDeferredExecution();

            // DemoImmediateExecution();

            // DemoReturnTypes();
        }

        private static void DemoNonLinq()
        {
            // Here's an array of strings.
            string[] cities = { "Boston", "New York", "Dallas", "St. Paul", "Las Vegas" };

            // Get the cities that contain a space character.
            string[] citiesWithSpaces = new string[cities.Length];
            for (int i = 0; i < cities.Length; i++)
            {
                if (cities[i].Contains(" "))
                    citiesWithSpaces[i] = cities[i];
            }

            Console.WriteLine("Cities with spaces (without using LINQ): ");
            foreach (string s in citiesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine($"City: {s}");
            }
        }

        private static void DemoLinq()
        {
            // Here's an array of strings.
            string[] cities = { "Boston", "New York", "Dallas", "St. Paul", "Las Vegas" };

            // Use a LINQ query expression to get the cities that contain a space character.
            var subset = from c in cities
                         where c.Contains(" ")
                         orderby c.Length
                         ascending
                         select c;

            Console.WriteLine("\nCities with spaces (using LINQ): ");
            foreach (var s in subset)
                Console.WriteLine($"City: {s}");
        }


        private static void DemoDeferredExecution()
        {
            int[] examMarks = { 62, 75, 85, 59, 96, 80 };

            // Get the "A" grades, i.e. >= 70.
            var subset = from m in examMarks where m >= 70 select m;

            Console.WriteLine("\nA-grade exams (LINQ query is executed here):");
            foreach (var m in subset)
                Console.WriteLine("Mark: {0}", m);

            // Change some data in the array.
            examMarks[0] = 99;

            Console.WriteLine("\nA-grade exams (LINQ query is executed AGAIN here):");
            foreach (var m in subset)
                Console.WriteLine($"Mark: {m}");
        }


        private static void DemoImmediateExecution()
        {
            int[] examMarks = { 62, 75, 85, 59, 96, 80 };

            // Execute query immediately, and get result as int[].
            int[] arrayOfGradeAs =
                (from m in examMarks where m >= 70 select m).ToArray<int>();

            // Get data RIGHT NOW as List<int>.
            List<int> listOfGradeAs =
                (from m in examMarks where m >= 70 select m).ToList<int>();
        }


        private static void DemoReturnTypes()
        {
            IEnumerable<int> query = DemoReturningQuery();
            Console.WriteLine("\nExam marks after executing query returned from DemoReturningQuery(): ");
            foreach (var m in query)
                Console.WriteLine($"Mark: {m}");

            int[] result = DemoReturningResult();
            Console.WriteLine("\nExam marks returned from DemoReturningResult(): ");
            foreach (var m in result)
                Console.WriteLine($"Mark: {m}");
        }


        private static IEnumerable<int> DemoReturningQuery()
        {
            int[] examMarks = { 62, 75, 85, 59, 96, 80 };

            // Create query.
            IEnumerable<int> query = from m in examMarks where m >= 70 select m;

            // Return query (the query hasn't been executed yet!)
            return query;
        }


        private static int[] DemoReturningResult()
        {
            int[] examMarks = { 62, 75, 85, 59, 96, 80 };

            // Create query.
            IEnumerable<int> query = from m in examMarks where m >= 70 select m;

            // Execute query now, and return result.
            return query.ToArray<int>();
        }
    }
}
