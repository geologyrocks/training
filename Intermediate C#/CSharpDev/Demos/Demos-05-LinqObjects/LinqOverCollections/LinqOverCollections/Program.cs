using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverCollections
{
    class Product
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DemoLinqGenericCollection();
            DemoLinqRawCollection();
            DemoFilter();
        }

        private static void DemoLinqGenericCollection()
        {
            // List<> of Product objects.
            List<Product> products = new List<Product>()
            {
                new Product { Description = "3D HD-TV",       Price = 1500, InStock = 3  },
                new Product { Description = "BluRay Player",  Price = 200,  InStock = 10 },
                new Product { Description = "iPad",           Price = 400,  InStock = 1  },
                new Product { Description = "Home Hub",       Price = 70,   InStock = 15 },
                new Product { Description = "Movie Centre",   Price = 600,  InStock = 12 },
                new Product { Description = "Music System",   Price = 900,  InStock = 10 },
            };

            Console.WriteLine("Expensive products:");
            var subset1 = from p in products where p.Price > 300 select p;
            foreach (var p in subset1)
            {
                Console.WriteLine($"\t{p.Description}");
            }

            Console.WriteLine("Scarce expensive products:");
            var subset2 = from p in products where p.Price > 300 && p.InStock < 5 select p;
            foreach (var p in subset2)
            {
                Console.WriteLine($"\t{p.Description}");
            }
        }

        private static void DemoLinqRawCollection()
        {
            // Raw ArrayList of Product objects.
            ArrayList products = new ArrayList()
            {
                new Product { Description = "3D HD-TV",       Price = 1500, InStock = 3  },
                new Product { Description = "BluRay Player",  Price = 200,  InStock = 10 },
                new Product { Description = "iPad",           Price = 400,  InStock = 1  },
                new Product { Description = "Home Hub",       Price = 70,   InStock = 15 },
                new Product { Description = "Movie Centre",   Price = 600,  InStock = 12 },
                new Product { Description = "Music System",   Price = 900,  InStock = 10 },
            };

            // Transform ArrayList into an IEnumerable<T> collection.
            var enumerable = products.Cast<Product>();

            Console.WriteLine("Expensive products (from raw collection originally):");
            var subset = from p in enumerable where p.Price > 300 select p;
            foreach (var p in subset)
            {
                Console.WriteLine($"\t{p.Description}");
            }
        }

        private static void DemoFilter()
        {
            // Raw ArrayList of various object types.
            ArrayList myStuff = new ArrayList()
            {
                3, 12, 1964, true, new Product(), "super swans"
            };

            // Transform ArrayList into an IEnumerable<int>, ignores the non-ints.
            IEnumerable<int> myInts = myStuff.OfType<int>();

            Console.WriteLine("Ints from the raw collection:");
            foreach (int i in myInts)
            {
                Console.WriteLine($"\t{i}");
            }
        }
    }
}
