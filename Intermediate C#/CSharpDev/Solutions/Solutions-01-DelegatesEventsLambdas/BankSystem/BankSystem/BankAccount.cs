using System;
using System.Collections.Generic;
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

        // Events.
        public event EventHandler<BankAccountEventArgs> ProtectionLimitExceeded;
        public event EventHandler<BankAccountEventArgs> Overdrawn;

        // Constructor.
        public BankAccount(string accountHolder) => this.accountHolder = accountHolder;

        // Methods.
        public void Deposit(double amount)
        {
            balance += amount;

            // If balance has exceeded the government's protection limit, raise a ProtectionLimitExceeded event.
            if (balance >= 50000 && ProtectionLimitExceeded != null)
            {
                ProtectionLimitExceeded(this, new BankAccountEventArgs(amount));
            }
        }

        public void Withdraw(double amount)
        {
            balance -= amount;

            // If account is now negative, raise an Overdrawn event.
            if (balance < 0 && Overdrawn != null)
            {
                Overdrawn(this, new BankAccountEventArgs(amount));
            }
        }

        public override string ToString() => $"Account {accountHolder}, balance {balance:C}";
    }
}
