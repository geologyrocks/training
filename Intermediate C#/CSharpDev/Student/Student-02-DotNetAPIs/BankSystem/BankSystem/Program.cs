using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount("Brendan");

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
                    Console.WriteLine($"Custom exception at {ex.Timestamp}, message: {ex.Message}.");
                }
            }
        }
    }
}

