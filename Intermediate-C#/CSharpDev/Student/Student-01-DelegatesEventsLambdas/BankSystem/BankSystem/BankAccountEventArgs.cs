using System;

namespace BankSystem
{
    public class BankAccountEventArgs
    {
        public double TransactionAmount { get; }
        public DateTime Timestamp { get; } 
        public BankAccountEventArgs(double transactionAmount)
        {
            TransactionAmount = transactionAmount;
            Timestamp = DateTime.Now;
        }
        public override string ToString() => $"Transaction amount {TransactionAmount} sent at {Timestamp}";
    }
}
