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
        private string AccountHolder;
        private double Balance;
        internal double GetBalance() => Balance;

        // Constructor.
        public BankAccount(string accountHolder, double balance = 0)
        {
            AccountHolder = accountHolder;
            Balance = balance;
        }

        // Methods.
        public void Deposit(double amount)
        {
            Balance += amount;
            if (Balance > 50000)
            {
                ProtectionLimitExceeded?.Invoke(this, new BankAccountEventArgs(amount));
            }
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            if (Balance < 0)
            {
                Overdrawn?.Invoke(this, new BankAccountEventArgs(amount));
            }
        }

        public override string ToString()
        {
            return $"Account {AccountHolder}, balance {Balance:C}";
        }
    }
}
