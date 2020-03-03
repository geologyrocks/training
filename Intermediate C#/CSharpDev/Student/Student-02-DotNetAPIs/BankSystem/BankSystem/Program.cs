using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Program
    {
        static void Main()
        {
            BankAccount acc1 = new BankAccount("Brendan");
            BankAccount acc2 = new BankAccount("Peter");
            BankAccount acc3 = new BankAccount("Jacintha");

            Bank bigBank = new Bank
            {
                { acc1.AccountId, acc1 },
                { acc2.AccountId, acc2 },
                { acc3.AccountId, acc3 }
            };

            // Do some stuff.
            acc1.AddTransaction(10000);
            acc1.AddTransaction(30000);
            acc1.AddTransaction(100000);
            acc1.AddTransaction(-1000000);
            foreach (var transaction in acc1.GetTransactions())
            {
                try
                {
                    acc1.BalanceChange(transaction);
                }
                catch (BankException ex)
                {
                    Console.WriteLine($"Custom exception at: {ex.Timestamp}, message: {ex.Message}.");
                    Console.WriteLine($"Account holder: {ex.AccountHolder}");
                    Console.WriteLine($"Transaction amount: {ex.TransactionAmount}");
                }
            }

            bigBank.Remove(acc1.AccountId);
            bigBank.ContainsKey(acc1.AccountId);
        }
    }
}

