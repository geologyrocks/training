using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public delegate void BankingAccountEventHandler(object sender, BankAccountEventArgs args);
    public class BankAccount
    {
        // Fields.
        public event BankingAccountEventHandler Overdrawn;
        public event BankingAccountEventHandler ProtectionLimitExceeded;
        private string accountHolder;
        private double balance;

        // Constructor.
        public BankAccount(string accountHolder)
        {
            this.accountHolder = accountHolder;
            this.balance = 0;
        }

        // Methods.
        public void Deposit(double amount)
        {
            balance += amount;
            if (balance > 50000)
            {
                ProtectionLimitExceeded?.Invoke(this, new BankAccountEventArgs(amount));
            }
        }

        public void Withdraw(double amount)
        {
            balance -= amount;
            if (balance < 0)
            {
                Overdrawn?.Invoke(this, new BankAccountEventArgs(amount));
            }
        }

        public override string ToString()
        {
            return $"Account {accountHolder}, balance {balance:C}";
        }
    }
}
