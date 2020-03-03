using System;
using System.Collections.Generic;

namespace DemoRefactoring.Original
{
    public class Catalog
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DisplayProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public Product LuckyDip()
        {
            int index = new Random().Next(products.Count);
            return products[index];
        }
    }
}
