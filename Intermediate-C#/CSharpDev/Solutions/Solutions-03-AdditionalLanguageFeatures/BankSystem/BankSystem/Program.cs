using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyExtensionLibrary;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise1Test();
            Exercise2Test();
            Exercise3Test();
            Exercise4Test();
        }

        private static void Exercise1Test()
        {
            Console.WriteLine("Exercise 1 test");
            Console.WriteLine("--------------------------------------------");

            // Create a Bank and add some BankAccounts.
            Bank bank = new Bank();
            bank[123] = new BankAccount { AccountHolder = "John", Balance = 1000 };
            bank[456] = new BankAccount { AccountHolder = "Mary", Balance = 2000 };
            bank[789] = new BankAccount { AccountHolder = "Sara", Balance = 3000 };

            // Create a list of BankAccounts.
            List<BankAccount> accountList = new List<BankAccount>
            {
                new BankAccount { AccountHolder = "Huey", Balance = 4000 },
                new BankAccount { AccountHolder = "Lewey", Balance = 5000 },
                new BankAccount { AccountHolder = "Dewey" } // Deliberately haven't set balance, defaults to 0.
            };

            Console.WriteLine("Entries in accountList:");
            foreach (BankAccount acc in accountList)
            {
                Console.WriteLine($"  {acc}");
            }

            // Create a dictionary of accountID-to-BankAccounts.
            Dictionary<int, BankAccount> accountDictionary = new Dictionary<int,BankAccount>
            {
                [111] = new BankAccount { AccountHolder = "Ole", Balance = 6000 },
                [222] = new BankAccount { AccountHolder = "Dole", Balance = 7000 },
                [333] = new BankAccount { AccountHolder = "Doffen" } // Deliberately haven't set balance, defaults to 0.
            };

            Console.WriteLine("\nEntries in accountDictionary:");
            foreach (var entry in accountDictionary)
            {
                Console.WriteLine($"  {entry.Key} {entry.Value}");
            }
        }

        private static void Exercise2Test()
        {
            Console.WriteLine("\nExercise 2 test");
            Console.WriteLine("--------------------------------------------");

            // Create a Bank and add some BankAccounts.
            Bank bank = new Bank();
            bank[123] = new BankAccount { AccountHolder = "John", Balance = 1000 };
            bank[456] = new BankAccount { AccountHolder = "Mary", Balance = 2000 };
            bank[789] = new BankAccount { AccountHolder = "Sara", Balance = 3000 };

            // Create an object of anonymous type.
            var info = new { NumAccs = bank.NumberOfAccounts, LastAccBalance = bank[789].Balance, Timestamp = DateTime.Now };

            // Display values of object of anonymous type.
            Console.WriteLine("Number of accounts: {0}", info.NumAccs);
            Console.WriteLine("Balance of last account: {0}", info.LastAccBalance);
            Console.WriteLine("Timestamp: {0}", info.Timestamp);
            Console.WriteLine("Anonymous type info: {0}", info.GetType());
        }

        private static void Exercise3Test()
        {
            Console.WriteLine("\nExercise 3 test");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Enter a number: ");
            double num = double.Parse(Console.ReadLine());

            if (num.InRange(10, 30))
                Console.WriteLine("{0} is in the range [10,30].", num);
            else
                Console.WriteLine("{0} is not in the range [10,30].", num);

            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            if (str.IsStrongPassword())
                Console.WriteLine("{0} is a strong password.", str);
            else
                Console.WriteLine("{0} is a weak password.", str);
        }

        private static void Exercise4Test()
        {
            Console.WriteLine("\nExercise 4 test");
            Console.WriteLine("--------------------------------------------");

            var f = Fibonacci();

            for (int i = 1; i <= 10; i++)
            {
                int term = f();
                Console.WriteLine("Term {0,2} in the Fibonacci series is {1}", i, term);
            }
        }

        private static Func<int> Fibonacci()
        {
            var t = (1, -1);

            return () =>
            {
                t = (t.Item1 + t.Item2, t.Item1);
                return t.Item1;
            };
        }
    }
}
