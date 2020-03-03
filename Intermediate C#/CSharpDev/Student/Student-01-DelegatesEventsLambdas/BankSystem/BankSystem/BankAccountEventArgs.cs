using System;

namespace BankSystem
{
    public class BankAccountEventArgs
    {
        public double TransactionAmount { get; }
        public DateTime Timestamp { get; } 
        public BankAccountEventArgs(double amount)
        {
            TransactionAmount = amount;
            Timestamp = DateTime.Now;
        }
    }
}
