using System;
using System.Collections.Generic;

namespace DemoRefactoring.Refactored
{
    abstract public class ProductCollection
    {
        protected List<Product> products = new List<Product>();

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
    }
}
