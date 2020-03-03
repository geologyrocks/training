using System;

namespace AccountLibrary
{
    public class Account
    {
        public Account(float amount)
        {
            if (amount == 0)
                throw new ArgumentException("Gimme some dosh!");

            Balance = amount;
        }

        public float Balance { get; private set; }

        public void Deposit(float amount)
        {
            Balance += amount;
        }
    }
}
