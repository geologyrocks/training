using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoRefactoring.Refactored
{
    public class Product
    {
        private const double SALES_TAX_RATE = 0.20;
        private String name;
        private double price;
        private List<int> ratings;

        public Product(String description, double price, params int[] ratings)
        {
            this.name = description;
            this.price = price;
            this.ratings = ratings.ToList();
        }

        public double TaxPayable 
        {
            get => price * SALES_TAX_RATE;
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
            const int targetRating = 1;
            int count = CountRating(targetRating);
            Console.WriteLine($"Number of low ratings: {count}");
        }

        private int CountRating(int targetRating)
        {
            int count = 0;
            foreach (var r in ratings)
            {
                if (r == targetRating)
                {
                    count++;
                }
            }
            return count;
        }

        public void DisplayCountHighRatings()
        {
            const int targetRating = 5;
            int count = CountRating(targetRating);
            Console.WriteLine($"Number of high ratings: {count}");
        }
    
        public override String ToString()
        {
            String ratingsStr = $"{Ratings.Count} ratings: ";
            foreach (var r in ratings)
            {
                ratingsStr += r + " ";
            }
            return $"{name}, £{price:F2}, {ratingsStr}";
        }
    }
}
