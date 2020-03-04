using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DemoDotNetAPIs
{
    static class CollectionsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nCollectionsDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoArrays();
            DemoRawCollections();
            DemoGenericLists();
            DemoGenericDictionaries();
        }

        private static void DemoArrays()
        {
            Random rand = new Random();

            int[] lotteryNumbers = new int[6];

            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                int num = rand.Next(49);
                lotteryNumbers[i] = num;
            }

            Console.WriteLine("Array of random numbers:");
            foreach (int num in lotteryNumbers)
            {
                Console.WriteLine("  {0}", num);
            }
        }

        private static void DemoRawCollections()
        {
            ArrayList cruiseStops = new ArrayList();
            cruiseStops.Add("Gibraltar");
            cruiseStops.Add("Barcelona");
            cruiseStops.Add("Monaco");

            ArrayList italianStops = new ArrayList();
            italianStops.Add("Rome");
            italianStops.Add("Sorrento");
            italianStops.Add("Bari");
            
            cruiseStops.AddRange(italianStops);
            cruiseStops.Remove("Gibraltar");
            cruiseStops.RemoveAt(3);

            Console.WriteLine("\nRaw collection items:");
            foreach (object obj in cruiseStops)
            {
                Console.WriteLine("  {0}", obj);
            }

            // This statement might cause an exception later...
            //   cruiseStops[2] = new Employee("George", 100000);
            
            string s = (string)cruiseStops[2];
            Console.WriteLine("cruiseStops[2] in uppercase is {0}.", s.ToUpper());
        }

        private static void DemoGenericLists()
        {
            List<string> cruiseStops = new List<string>();
            cruiseStops.Add("Gibraltar");
            cruiseStops.Add("Barcelona");
            cruiseStops.Add("Monaco");

            List<string> italianStops = new List<string>();
            italianStops.Add("Rome");
            italianStops.Add("Sorrento");
            italianStops.Add("Bari");

            cruiseStops.AddRange(italianStops);
            cruiseStops.Remove("Gibraltar");
            cruiseStops.RemoveAt(3);

            Console.WriteLine("\nGeneric collection items:");
            foreach (string str in cruiseStops)
            {
                Console.WriteLine("  {0}", str);
            }

            // Note, no need to cast now.
            string s = cruiseStops[2];
            Console.WriteLine("cruiseStops[2] in uppercase is {0}.", s.ToUpper());
        }


        private static void DemoGenericDictionaries()
        {
            // Create a Dictionary with string keys are Employee object values
            Dictionary<string, Employee> employees = new Dictionary<string, Employee>();

            // One way to add items to a Dictionary is via the Add() method.
            employees.Add("1234", new Employee("Jack", 10000));
            employees.Add("5678", new Employee("Jill", 20000));

            // Another way to add an item (or reassign an item) is via the [] operator.
            employees["2222"] = new Employee("Tony", 22000);
            employees["3333"] = new Employee("Joan", 33000);

            // You can access items via the [] operator.
            Employee emp = employees["3333"];
            Console.WriteLine("\nEmployee 3333 : {0}", emp);

            // It's also common to test whether the dictionary contains a particular key.
            if (employees.ContainsKey("4444"))
                Console.WriteLine("Employee 4444 details: {0}", employees["4444"]);

            // Iteration is also common.
            Console.WriteLine("Here are all the employees:");
            foreach (string key in employees.Keys)
                Console.WriteLine("  {0} : {1}", key, employees[key]);
        }
    }

    class Employee
    {
        private string name;
        private double salary;

        private List<string> programmingLanguages = new List<string>();

        public Employee(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public override string ToString()
        {
            return string.Format("{0} earns {1:c}", name, salary);
        }

        public void LearnNewLanguage(string lang)
        {
            programmingLanguages.Add(lang);
        }
    }
}
