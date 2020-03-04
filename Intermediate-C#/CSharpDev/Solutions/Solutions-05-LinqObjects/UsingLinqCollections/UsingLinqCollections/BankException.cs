using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLinqCollections
{
    class BankException : ApplicationException
    {
        public DateTime Timestamp = DateTime.Now;
        public string accountHolder;
        public double transactionAmount;

        public BankException(string message)
            : base(message)
        { }

        public BankException(string message, string holder, double amount, Exception innerException = null)
            : base(message, innerException)
        {
            accountHolder = holder;
            transactionAmount = amount;
        }
    }
}
