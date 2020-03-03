using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAdditionalLanguageFeatures
{
    static class InitializationDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("InitializationDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoObjectInitialization();
            DemoCollectionInitialization();
            DemoDictionaryInitialization();
        }

        private static void DemoObjectInitialization()
        {
            Employee emp1 = new Employee { Name = "Smith", Salary = 20000, Grade = 5 };
            Employee emp2 = new Employee("Jones", 30000) { Grade = 6 };

            Console.WriteLine("Employee1: {0}", emp1);
            Console.WriteLine("Employee2: {0}", emp2);
        }

        private static void DemoCollectionInitialization()
        {
            List<int> examMarks = new List<int> { 10, 20, 30 };

            List<Employee> emps = new List<Employee>
            {
                new Employee { Name = "Smith", Salary = 20000, Grade = 5 },
                new Employee { Name = "Jones", Salary = 30000, Grade = 6 }
            };

            Console.WriteLine("Exam marks:");
            foreach (int mark in examMarks)
            {
                Console.WriteLine("  {0}", mark);
            }

            Console.WriteLine("\nEmployees:");
            foreach (Employee emp in emps)
            {
                Console.WriteLine("  {0}", emp);
            }
        }

        private static void DemoDictionaryInitialization()
        {
            Dictionary<string, string> capitals = new Dictionary<string, string>
            {
                ["Norway"] = "Oslo",
                ["Swenden"] = "Stockholm",
                ["Denmark"] = "Copenhagen"
            };

            Dictionary<string, Employee> emps = new Dictionary<string, Employee>
            {
                ["001"] = new Employee { Name = "Fabianski", Salary = 10000, Grade = 1 },
                ["008"] = new Employee { Name = "Shelvey", Salary = 20000, Grade = 2 },
                ["018"] = new Employee { Name = "Gomis", Salary = 30000, Grade = 3 }
            };

            Console.WriteLine("\nEmployees:");
            foreach (var entry in emps)
            {
                Console.WriteLine("  {0} - {1}", entry.Key, entry.Value);
            }
        }
    }

    public class Employee
    {
        // Auto-implemented properties.
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Grade { get; set; }

        // Constructors.
        public Employee() { }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return string.Format("{0} salary {1:c}, grade {2}.", Name, Salary, Grade);
        }
    }
}
