using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTechniques
{
    class Product
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }

        public override string ToString()
        {
            return $"{Description}, {Price:c}, {InStock} in stock";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of products, for use in all our methods.
            Product[] products = new Product[]
            {
                new Product { Description = "3D HD-TV",       Price = 1500, InStock = 3  },
                new Product { Description = "BlueRay Player", Price = 200,  InStock = 10 },
                new Product { Description = "iPad",           Price = 400,  InStock = 1  },
                new Product { Description = "Home Hub",       Price = 70,   InStock = 15 },
                new Product { Description = "Movie Centre",   Price = 600,  InStock = 12 },
                new Product { Description = "Music System",   Price = 900,  InStock = 10 },
            };

            
            // Uncomment statements to run different parts of the demo...

            // DemoFullObjectQueries(products);            
            // DemoSpecificFieldQueries(products);            
            // DemoTransformedDataQueries(products);           
            // DemoProjectionQueries(products);           
            DemoSets();            
            // DemoAggregates();
        }


        private static void DemoFullObjectQueries(Product[] products)
        {
            Console.WriteLine("Low-stock product details:");

            var prods = from p in products
                        where p.InStock < 5
                        select p;

            foreach (var p in prods)
                Console.WriteLine($"\t{p}");
        }


        private static void DemoSpecificFieldQueries(Product[] products)
        {
            Console.WriteLine("\nLow-stock product prices:");

            var prices = from p in products
                         where p.InStock < 5
                         select p.Price;

            foreach (var p in prices)
                Console.WriteLine($"\t{p:c}");
        }


        private static void DemoTransformedDataQueries(Product[] products)
        {
            Console.WriteLine("\nProducts summaries:");

            var summaries = from p in products
                            select String.Format("{0}: {1} stock level",
                                                  p.Description,
                                                  p.InStock < 5 ? "low" : "normal");

            foreach (var summary in summaries)
                Console.WriteLine($"\t{summary}");
        }


        private static void DemoProjectionQueries(Product[] products)
        {
            Console.WriteLine("\nLow-stock products and prices:");

            var projs = from p in products
                        where p.InStock < 5
                        select new { p.Description, p.Price };

            foreach (var p in projs)
                Console.WriteLine($"\t{p.Description}, {p.Price:c}");
        }


        private static void DemoSets()
        {
            List<string> myTeams = new List<String> { "Swansea", "Arsenal", "Liverpool", "Blackpool" };
            List<string> yourTeams = new List<String> { "Swansea", "Man Utd", "West Brom", "Liverpool" };

            Console.WriteLine("\nTeams I like but you don't:");
            var diff = (from t in myTeams select t).Except(from t2 in yourTeams select t2);
            foreach (var t in diff)
                Console.WriteLine($"\t{t}");

            Console.WriteLine("\nTeams we both like:");
            var intersect = (from t in myTeams select t).Intersect(from t2 in yourTeams select t2);
            foreach (var t in intersect)
                Console.WriteLine($"\t{t}");

            Console.WriteLine("\nTeams either of us likes:");
            var union = (from t in myTeams select t).Union(from t2 in yourTeams select t2);
            foreach (var t in union)
                Console.WriteLine($"\t{t}");

            Console.WriteLine("\nConcatenation of my teams and your teams:");
            var concat = (from t in myTeams select t).Concat(from t2 in yourTeams select t2);
            foreach (var t in concat)
                Console.WriteLine($"\t{t}");

            Console.WriteLine("\nDistinct concatenation of my teams and your teams:");
            var distinct = (from t in myTeams select t).Concat(from t2 in yourTeams select t2).Distinct();
            foreach (var t in distinct)
                Console.WriteLine($"\t{t}");
        }


        private static void DemoAggregates()
        {
            double[] winterTemps = { 2.0, -3.3, 8, -4, 0, 8.2 };

            Console.WriteLine("\nAggregate query results:");
            Console.WriteLine("Max:  {0:f2}", (from t in winterTemps select t).Max());
            Console.WriteLine("Min:  {0:f2}", (from t in winterTemps select t).Min());
            Console.WriteLine("Avg:  {0:f2}", (from t in winterTemps select t).Average());
            Console.WriteLine("Sums: {0:f2}", (from t in winterTemps select t).Sum());
        }
    }
}
