using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionsLibrary;

namespace BankSystem
{
    class Program
    {
        static void Main()
        {
            // Create a Bank and add some BankAccounts.
            Bank bank = new Bank()
            {
                [123] = new BankAccount { AccountHolder = "John", Balance = 20000 },
                [456] = new BankAccount { AccountHolder = "Mary", Balance = 10},
                [789] = new BankAccount { AccountHolder = "Sara" }
            };
            // Create a list of BankAccounts.
            List<BankAccount> accountList = new List<BankAccount>()
            {
                new BankAccount { AccountHolder = "Huey" },
                new BankAccount { AccountHolder = "Lewey" },
                new BankAccount { AccountHolder = "Dewey" }
            };

            Console.WriteLine("Entries in accountList:");
            foreach (BankAccount acc in accountList)
            {
                Console.WriteLine($"  {acc}");
            }

            // Create a dictionary of accountID-to-BankAccounts.
            Dictionary<int, BankAccount> accountDictionary = new Dictionary<int, BankAccount>()
            {
                [111] = new BankAccount { AccountHolder = "Ole" },
                [222] = new BankAccount { AccountHolder = "Dole" },
                [333] = new BankAccount { AccountHolder = "Doffen" },
            };

            Console.WriteLine("\nEntries in accountDictionary:");
            foreach (var entry in accountDictionary)
            {
                Console.WriteLine($"  {entry.Key} {entry.Value}");
            }
            var obj = new
            {
                numAccounts = bank.Count(),
                lastAccountBalance = accountList[accountList.Count - 1].GetBalance(),
                dateNow = DateTime.Now
            };

            Console.WriteLine(obj);
            Console.WriteLine($"\nNumber of bank accounts: {obj.numAccounts}");
            Console.WriteLine($"\nBalance of last account: {obj.lastAccountBalance}");
            Console.WriteLine($"\nCurrent time: {obj.dateNow}");

            double dub = 1.0;
            Console.WriteLine(dub.IsWithinRange(2,2).ToString());

            string pwd1 = "hihihihihi";
            Console.WriteLine(pwd1.IsStrongPassword());
            string pwd2 = "hiHihihihi";
            Console.WriteLine(pwd2.IsStrongPassword());
            string pwd3 = "hiHihih1hi";
            Console.WriteLine(pwd3.IsStrongPassword());
            string pwd4 = "hiHihih1h!";
            Console.WriteLine(pwd4.IsStrongPassword());
        }
    }
}
