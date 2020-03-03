using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonMethodsLambdas
{
    // This class illustrates C# 6 expression-bodied members. 
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        // Expression-bodied method.
        public void PayRaise(double amount) => Salary += amount;

        // Expression-bodied read-only property.
        public double TaxPayable => Salary * 0.25;

        // Normal members.
        public override string ToString()
        {
            if (Salary < 10000)
                return $"{Name} {Salary:C}";
            else
                return $"High-paid employee: {Name} {Salary:C}";
        }
    }

    // This class illustrates C# 7 expression-bodied members.
    class Contact
    {
        private string name;
            
        // Expression-bodied constructor.
        public Contact(string name) => this.name = name;

        // Expression-bodied finalizer.
        ~Contact() => Console.WriteLine($"Finalized {name}");

        // Expression-bodied get/set accessors.
        public string Name
        {
            get => name;
            set => name = value ?? "Anonymous";
        }

        // Normal members.
        public override string ToString()
        {
            if (name != null && name != "Anonymous")
                return name;
            else
                return "Unspecified or anonymous contact";
        }
    }

    static class ExpressionBodiedMembers
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nExpressionBodiedMembers");
            Console.WriteLine("------------------------------------------------------");

            Employee emp = new Employee();
            emp.Name = "Mary";
            emp.Salary = 12345;
            emp.PayRaise(1000);
            double tax = emp.TaxPayable;
            Console.WriteLine($"{emp}, tax payable: {tax:C}");

            Contact c = new Contact("Simon");
            c.Name = "Peter";
            Console.WriteLine($"Contact's name is {c.Name}");
        }
    }
}