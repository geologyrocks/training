using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    namespace BankSystem
    {
        partial class Program
        {
            static void Main(string[] args)
            {
                BankAccount acc1 = new BankAccount("Peter");
                acc1.Overdrawn += delegate (object sender, BankAccountEventArgs e)
                {
                    Console.WriteLine($"You are overdrawn as of {e.Timestamp}.  Don't be.");
                };

                acc1.ProtectionLimitExceeded += delegate (object sender, BankAccountEventArgs e)
                {
                    Console.WriteLine($"Account balances over £50,000 are not protected. Your balance is {e.AccountBalance} as of {e.Timestamp}");
                };
                // Do some stuff.
                acc1.Deposit(10000);
                acc1.Deposit(30000);
                acc1.Deposit(40000);
                acc1.Withdraw(1000000);
            }
        }
    }
}
