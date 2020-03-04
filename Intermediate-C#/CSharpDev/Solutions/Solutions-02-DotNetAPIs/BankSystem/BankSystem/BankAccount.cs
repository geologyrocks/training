using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class BankAccountEventArgs : EventArgs
    {
        private double transactionAmount;
        private DateTime timestamp = DateTime.Now;

        public BankAccountEventArgs(double transactionAmount) => this.transactionAmount = transactionAmount;

        public override string ToString() => $"Transaction amount {transactionAmount}, timestamp {timestamp}";
    }

    public class BankAccount
    {
        // Fields.
        private string accountHolder;
        private double balance = 0;
        private List<double> transactions = new List<double>();

        // Events.
        public event EventHandler<BankAccountEventArgs> ProtectionLimitExceeded;
        public event EventHandler<BankAccountEventArgs> Overdrawn;

        // Constructor.
        public BankAccount(string accountHolder) => this.accountHolder = accountHolder;

        // Methods.
        public void Deposit(double amount)
        {
            // If attempt to deposit more than 100000, disallow this deposit!
            if (amount > 100000)
            {
                throw new BankException("Cannot deposit more than 100000.", accountHolder, amount);
            }

            // Deposit money, and store transaction amount.
            balance += amount;
            transactions.Add(amount);

            // If balance has exceeded the government's protection limit, raise a ProtectionLimitExceeded event.
            if (balance >= 50000 && ProtectionLimitExceeded != null)
            {
                ProtectionLimitExceeded(this, new BankAccountEventArgs(amount));
            }
        }

        public void Withdraw(double amount)
        {
            // If account is already overdrawn, disallow this withdrawal!
            if (balance < 0)
            {
                throw new BankException("Cannot withdraw from an overdrawn account.", accountHolder, amount);
            }

            // Withdraw money, and store transaction amount as a negative amount (to denote a withdrawal). 
            balance -= amount;
            transactions.Add(-amount);

            // If account is now negative, raise an Overdrawn event.
            if (balance < 0 && Overdrawn != null)
            {
                Overdrawn(this, new BankAccountEventArgs(amount));
            }
        }

        // Return a read-only wrapper for the transaction list. Prevents client app from meddling...
        public ReadOnlyCollection<double> Transactions => transactions.AsReadOnly(); 

        public override string ToString() => $"Account {accountHolder}, balance {balance:C}";
    }
}
