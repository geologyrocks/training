using System;

namespace DemoRefactoring.Refactored
{
    public class Catalog : ProductCollection
    {
        public Product LuckyDip()
        {
            int index = new Random().Next(products.Count);
            return products[index];
        }
    }
}
