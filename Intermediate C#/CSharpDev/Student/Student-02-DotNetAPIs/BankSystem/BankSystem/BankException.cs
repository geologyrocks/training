using System;

namespace BankSystem
{
    public class BankException : Exception
    {
        public DateTime Timestamp = DateTime.Now;
        public string AccountHolder;
        public double TransactionAmount;
        public BankException(string message) : base(message) { }
        public BankException(string message, string accountHolder, double transactionAmount) : base(message)
        {
            AccountHolder = accountHolder;
            TransactionAmount = transactionAmount;
        }
    }
}
