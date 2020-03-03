namespace DemoRefactoring.Refactored
{
    public class Basket : ProductCollection
    {
        public bool EligibleForFreeDelivery()
        {
            return products.Count >= 3;
        }
    }
}
