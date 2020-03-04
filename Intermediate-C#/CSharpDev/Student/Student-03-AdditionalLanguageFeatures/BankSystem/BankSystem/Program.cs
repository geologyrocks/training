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
            // Create a Bank and add some BankAccounts.
            Bank bank = new Bank();
            bank[123] = new BankAccount("John");
            bank[456] = new BankAccount("Mary");
            bank[789] = new BankAccount("Sara");

            // Create a list of BankAccounts.
            List<BankAccount> accountList = new List<BankAccount>();
            accountList.Add(new BankAccount("Huey"));
            accountList.Add(new BankAccount("Lewey"));
            accountList.Add(new BankAccount("Dewey"));

            Console.WriteLine("Entries in accountList:");
            foreach (BankAccount acc in accountList)
            {
                Console.WriteLine($"  {acc}");
            }

            // Create a dictionary of accountID-to-BankAccounts.
            Dictionary<int, BankAccount> accountDictionary = new Dictionary<int, BankAccount>();
            accountDictionary[111] = new BankAccount("Ole");
            accountDictionary[222] = new BankAccount("Dole");
            accountDictionary[333] = new BankAccount("Doffen"); 

            Console.WriteLine("\nEntries in accountDictionary:");
            foreach (var entry in accountDictionary)
            {
                Console.WriteLine($"  {entry.Key} {entry.Value}");
            }
        }
    }
}
