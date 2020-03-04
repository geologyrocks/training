using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoRefactoring.Original
{
    public class Product
    {
        private String description;
        private double price;
        private List<int> ratings;

        public Product(String description, double price, params int[] ratings)
        {
            this.description = description;
            this.price = price;
            this.ratings = ratings.ToList();
        }

        public double TaxPayable 
        {
            get => price * 0.20;
        }

        public List<int> Ratings
        {
            get => ratings;
        }

        public double Price
        {
            get => price;
        }

        public void DisplayCountLowRatings()
        {
            int count = 0;
            foreach (var r in ratings)
            {
                if (r == 1)
                {
                    count++;
                }
            }
            Console.WriteLine($"Number of low ratings: {count}");
        }

        public void DisplayCountHighRatings()
        {
            int count = 0;
            foreach (var r in ratings)
            {
                if (r == 5)
                {
                    count++;
                }
            }
            Console.WriteLine($"Number of high ratings: {count}");
        }
    
        public override String ToString()
        {
            String ratingsStr = $"{Ratings.Count} ratings: ";
            foreach (var r in ratings)
            {
                ratingsStr += r + " ";
            }
            return $"{description}, £{price:F2}, {ratingsStr}";
        }
    }
}
