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
            Exercise1Test();
            Exercise2Test();
            Exercise3Test();
        }

        private static void Exercise1Test()
        {
            Console.WriteLine("Exercise 1 test");
            Console.WriteLine("--------------------------------------------");

            BankAccount acc1 = new BankAccount("Peter");

            // Do some stuff that will cause exceptions.
            try
            {
                acc1.Deposit(10000);
                acc1.Deposit(30000);
                acc1.Deposit(1140000);
                acc1.Withdraw(1000000);
                acc1.Withdraw(10);
            }
            catch (BankException ex)
            {
                Console.WriteLine("Bank exception at {0}", ex.Timestamp);
                Console.WriteLine("  Message: {0}", ex.Message);
                Console.WriteLine("  Account holder: {0}", ex.accountHolder);
                Console.WriteLine("  Transaction amount: {0}", ex.transactionAmount);
            }
        }

        private static void Exercise2Test()
        {
            Console.WriteLine("\nExercise 2 test");
            Console.WriteLine("--------------------------------------------");

            BankAccount acc1 = new BankAccount("Paul");

            // Do some stuff that won't exceptions.
            acc1.Deposit(10000);
            acc1.Deposit(20000);
            acc1.Deposit(30000);
            acc1.Withdraw(40000);

            Console.WriteLine("Transactions on account:");
            foreach (double transaction in acc1.Transactions)
            {
                Console.WriteLine("{0:c}", transaction);
            }
        }

        private static void Exercise3Test()
        {
            Console.WriteLine("\nExercise 3 test");
            Console.WriteLine("--------------------------------------------");

            // Create a Bank object.
            Bank theBank = new Bank();

            // Create some BankAccount objects and add to Bank, via Bank's indexer (i.e. "this" method).
            theBank[123] = new BankAccount("Matthew");
            theBank[456] = new BankAccount("Mark");
            theBank[789] = new BankAccount("Luke");

            // Find a BankAccount object by its accountID, and so some stuff with it.
            if (theBank.ContainsAccountID(123))
            {
                BankAccount acc = theBank[123];
                acc.Deposit(10000);
                acc.Deposit(30000);
                acc.Withdraw(20000);
            }
            Console.WriteLine("Details for account with ID 123: {0}", theBank[123]);
        }
    }
}
