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
                [456] = new BankAccount { AccountHolder = "Mary", Balance = 10 },
                [789] = new BankAccount { AccountHolder = "Sara" }
            };
            // Create a list of BankAccounts.
            List<BankAccount> accountList = new List<BankAccount>()
            {
                new BankAccount { AccountHolder = "Huey", Balance = -100 },
                new BankAccount { AccountHolder = "Lewey", Balance = 346 },
                new BankAccount { AccountHolder = "Dewey", Balance = 7000 }
            };

            // Change balances for accounts in accountList
            accountList[0].Deposit(100);

            accountList[1].Deposit(100);
            accountList[1].Deposit(100);
            accountList[1].Deposit(100);
            accountList[1].Deposit(100);
            accountList[1].Deposit(100);
            accountList[1].Deposit(100);
            accountList[1].Deposit(100);
            accountList[1].Deposit(100);

            accountList[2].Deposit(100);
            accountList[2].Deposit(100);
            accountList[2].Deposit(100);
            accountList[2].Deposit(100); 
            accountList[2].Deposit(100);
            accountList[2].Deposit(100);
            accountList[2].Deposit(100);
            accountList[2].Deposit(100);
            accountList[2].Deposit(100);
            accountList[2].Deposit(100);
            accountList[2].Deposit(100);

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
                lastAccountBalance = accountList[accountList.Count - 1].Balance,
                dateNow = DateTime.Now
            };

            Console.WriteLine(obj);
            Console.WriteLine($"\nNumber of bank accounts: {obj.numAccounts}");
            Console.WriteLine($"\nBalance of last account: {obj.lastAccountBalance}");
            Console.WriteLine($"\nCurrent time: {obj.dateNow}");

            double dub = 1.0;
            Console.WriteLine(dub.IsWithinRange(2, 2).ToString());

            string pwd1 = "hihihihihi";
            Console.WriteLine(pwd1.IsStrongPassword());
            string pwd2 = "hiHihihihi";
            Console.WriteLine(pwd2.IsStrongPassword());
            string pwd3 = "hiHihih1hi";
            Console.WriteLine(pwd3.IsStrongPassword());
            string pwd4 = "hiHihih1h!";
            Console.WriteLine(pwd4.IsStrongPassword());

            Console.WriteLine("----------------------------------------------------------");
            var allAccounts = from accs in accountList
                        select accs;
            Output(allAccounts.ToList());

            var justDetailsTuple = from accs in accountList
                              select (accs.AccountHolder, accs.Balance);
            foreach (var part in justDetailsTuple)
            {
                Console.WriteLine(part);
            }

            var justDetailsAnon = from accs in accountList
                              select new { accs.AccountHolder, accs.Balance };
            Output(justDetailsAnon.ToList());

            var balanceGreaterThan0TransacationsLessThan10 = from accs in accountList
                                                             where accs.Balance >= 0
                                                             & accs.Transactions.Count < 10
                                                             select new { accs.AccountHolder, accs.Balance };
            Output(balanceGreaterThan0TransacationsLessThan10.ToList());
        }
        private static void Output(IEnumerable<object> query)
        {
            Console.WriteLine("");
            foreach (var part in query)
            {
                Console.WriteLine(part);
            }
        }
        public static void Output(object query)
        {
            Console.WriteLine($"\n{query}");
        }
        
    }
}
