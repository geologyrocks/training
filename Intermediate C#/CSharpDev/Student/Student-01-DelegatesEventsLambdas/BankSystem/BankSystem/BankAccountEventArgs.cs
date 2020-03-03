using System;

namespace BankSystem
{
    public class BankAccountEventArgs
    {
        public double AccountBalance { get; }
        public DateTime Timestamp { get; } 
        public BankAccountEventArgs(double balance)
        {
            AccountBalance = balance;
            Timestamp = DateTime.Now;
        }
    }
}
