using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLinqCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise1Test();
            Exercise2Test();
        }

        #region Exercise 1 methods

        private static void Exercise1Test()
        {
            int[] lotteryNumbers = { 13, 45, 28, 57, 92, 31 };

            OutputAllNumbers(lotteryNumbers);
            OutputNumbersInOrder(lotteryNumbers);
            OutputSquares(lotteryNumbers);
            OutputOddNumbers(lotteryNumbers);
            OutputSumAvgMinMax(lotteryNumbers);
        }

        private static void OutputAllNumbers(int[] nums)
        {
            var query = (from i in nums select i);

            Console.WriteLine("All numbers:");
            foreach (var i in query)
            {
                Console.WriteLine(i);
            }
        }

        private static void OutputNumbersInOrder(int[] nums)
        {
            var ascQuery = (from i in nums orderby i ascending select i);
            var descQuery = (from i in nums orderby i descending select i);

            Console.WriteLine("\nNumbers in ascending order:");
            foreach (var i in ascQuery)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nNumbers in descending order:");
            foreach (var i in descQuery)
            {
                Console.WriteLine(i);
            }
        }

        private static void OutputSquares(int[] nums)
        {
            var sqQuery = (from i in nums select i * i);

            Console.WriteLine("\nSquares:");
            foreach (var i in sqQuery)
            {
                Console.WriteLine(i);
            }
        }

        private static void OutputOddNumbers(int[] nums)
        {
            var oddQuery = (from i in nums where i % 2 != 0 select i);

            Console.WriteLine("\nOdd numbers:");
            foreach (var i in oddQuery)
            {
                Console.WriteLine(i);
            }
        }

        private static void OutputSumAvgMinMax(int[] nums)
        {
            var sumQuery = (from i in nums select i).Sum();
            var avgQuery = (from i in nums select i).Average();
            var minQuery = (from i in nums select i).Min();
            var maxQuery = (from i in nums select i).Max();

            Console.WriteLine($"\nSum: {sumQuery}");
            Console.WriteLine($"Avg: {avgQuery}");
            Console.WriteLine($"Min: {minQuery}");
            Console.WriteLine($"Max: {maxQuery}");
        }

        #endregion

        #region Exercise 2 methods

        private static void Exercise2Test()
        {
            // Create a collection using collection initializer syntax.
            List<BankAccount> accounts = new List<BankAccount>
            {
                new BankAccount { AccountHolder = "Huey", Balance = 4000 },
                new BankAccount { AccountHolder = "Lewey", Balance = 5000 },
                new BankAccount { AccountHolder = "Dewey" } ,
                new BankAccount { AccountHolder = "Donald", Balance = 10000 }
            };

            // Do some transactions.
            for (int i = 0; i < 5; i++)
            {
                accounts[0].Deposit(i * 100);
            }
            for (int i = 0; i < 20; i++)
            {
                accounts[1].Deposit(i * 100);
            }
            accounts[2].Withdraw(10000);

            OutputFullDetailsForAllAccounts(accounts);
            OutputNameAndBalanceForAllAccounts(accounts);
            OutputInCreditFewTransactionsAccounts(accounts);
        }

        private static void OutputFullDetailsForAllAccounts(List<BankAccount> accounts)
        {
            Console.WriteLine("\nFull details for all accounts:");

            var query = (from a in accounts select a);

            foreach (var a in query)
            {
                Console.WriteLine("Account holder: {0}, balance: {1}, num transactions: {2}", a.AccountHolder, a.Balance, a.Transactions.Count);
            }
        }

        private static void OutputNameAndBalanceForAllAccounts(List<BankAccount> accounts)
        {
            Console.WriteLine("\nName and balance for all accounts:");

            var query = from a in accounts
                        select new { a.AccountHolder, a.Balance };

            foreach (var item in query)
            {
                Console.WriteLine("Account holder: {0}, balance: {1}", item.AccountHolder, item.Balance);
            }
        }

        private static void OutputInCreditFewTransactionsAccounts(List<BankAccount> accounts)
        {
            Console.WriteLine("\nAccounts in credit, with < 10 transactions:");

            var query = from a in accounts
                        where a.Balance >= 0 && a.Transactions.Count < 10
                        select a;

            foreach (var a in query)
            {
                Console.WriteLine("Account holder: {0}, balance: {1}, num transactions: {2}", a.AccountHolder, a.Balance, a.Transactions.Count);
            }
            Console.WriteLine();
        }

        #endregion
    }
}
