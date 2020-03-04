using System;


namespace DemoAdditionalLanguageFeatures
{
    // Note: In .NET prior to 4.7, you must install the System.ValueTuple NuGet package.

    static class TuplesDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("TuplesDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoSimpleTuples();
            DemoReturningTuplesFromFunctions();
            DemoDeconstruction();
        }

        private static void DemoSimpleTuples()
        {
            System.ValueTuple x;

            var personA = ("Matthew", 21);
            Console.WriteLine($"{personA.Item1} is {personA.Item2} years old");

            var personB = (Name: "Mark", Age: 22);
            Console.WriteLine($"{personB.Name} is {personB.Age} years old");

            (string name, int age) = ("Luke", 23);
            Console.WriteLine($"{name} is {age} years old");
        }

        private static void DemoReturningTuplesFromFunctions()
        {
            var stats = GetStats(10, 20, 30, 40);
            Console.WriteLine($"Average is {stats.avg}, count of items is {stats.count}");

            (double a, int n) = GetStats(50, 60, 70, 80);
            Console.WriteLine($"Average is {a}, count of items is {n}");            
        }

        private static void DemoDeconstruction()
        {
            Product productA = new Product("The Good Book", 12.99);
            (string desc, double price) = productA;
            Console.WriteLine($"{desc} costs {price:c}");
        }

        private static (double avg, int count) GetStats(params int[] nums)
        {
            double sum = 0;
            int i = 0;

            while (i < nums.Length)
            {
                sum += nums[i++];
            }
            return (sum/i, i);
        }
    }

    public class Product
    {
        public string Description { get; }
        public double UnitPrice { get; }

        public Product(string description, double unitPrice)
        {
            Description = description;
            UnitPrice = unitPrice;
        }

        public void Deconstruct(out string description, out double unitPrice)
        {
            description = this.Description;
            unitPrice = this.UnitPrice;
        }
    }
}
