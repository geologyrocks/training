using System;
using System.Collections.Generic;

namespace DemoRefactoring.Original
{
    public class Basket
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

        public bool EligibleForFreeDelivery()
        {
            return products.Count >= 3;
        }
    }
}
