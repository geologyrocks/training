using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAdditionalLanguageFeatures
{
    static class AnonymousTypesDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nAnonymousTypesDemo");
            Console.WriteLine("------------------------------------------------------");

            var city1 = new
            {
                Name = "Oslo",
                Country = "Norway",
                Longitude = -10.7,
                Latitude = 59.9
            };

            var city2 = new
            {
                Name = "Swansea",
                Country = "Wales",
                Longitude = 3.9,
                Latitude = 51.6
            };

            Console.WriteLine("city1 details: {0}", city1.ToString());
            Console.WriteLine("city2 details: {0}", city2.ToString());
            Console.WriteLine("city1 type:    {0}", city1.GetType());
            Console.WriteLine("city2 type:    {0}", city2.GetType());

            if (city1.Equals(city2))
            {
                Console.WriteLine("Cities are the same.");
            }
            else
            {
                Console.WriteLine("Cities are different.");
            }
        }
    }
}
