using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class BankAccount
    {
        // Fields.
        private readonly string AccountHolder;
        private double Balance;
        private List<double> Transactions = new List<double>();

        // Constructor.
        public BankAccount(string accountHolder, double balance = 0)
        {
            AccountHolder = accountHolder;
            Balance = balance;
        }
        public double GetBalance() => Balance;
        public List<double> GetTransactions() => Transactions;


        public void AddTransaction(double transaction) => Transactions.Add(transaction);
        public void BalanceChange(double amount)
        {
            if (amount > 0)
            {
                Deposit(amount);
            }
            else
            {
                Withdraw(-amount);
            }
            //amount > 0 ? Deposit(amount) : Withdraw(amount);
        }
        
        // Methods.
        private void Deposit(double amount)
        {
            Console.WriteLine($"Trying to deposit {amount}.");
            if (amount >= 100000 )
            {
                throw new BankException("You cannot deposit this amount online. Please visit a representative in-branch; they will be happy to assist you.");
}
            else
            {
                Balance += amount;
                Console.WriteLine($"{amount} deposited in account. Account balance is {GetBalance()}.");
            }
        }

        private void Withdraw(double amount)
        {
            Console.WriteLine($"Trying to withdraw {amount}.");
            if (Balance < 0 || Balance - amount < 0)
            {
                throw new BankException("Insufficient funds in the account");
            }
            else
            {
            
                Balance -= amount;
                Console.WriteLine($"{amount} withdrawn from account. Account balance is {GetBalance()}.");
            }
        }

        public override string ToString() => $"Account {AccountHolder}, balance {Balance:C}";
    }
}
