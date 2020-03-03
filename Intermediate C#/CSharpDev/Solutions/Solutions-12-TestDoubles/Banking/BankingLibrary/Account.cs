using System;

namespace BankingLibrary
{
    public class Account
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Balance { get; private set; } = 0;

        public int Deposit(int amount)
        {
            Balance += amount;
            return Balance;
        }

        public int Withdraw(int amount)
        {
            if (amount > Balance)
                throw new ArgumentException("Insufficient funds");
            Balance -= amount;
            return Balance;
        }

        public override String ToString()
        {
            return $"{Name}, balance {Balance:F2}";
        }
    }
}
