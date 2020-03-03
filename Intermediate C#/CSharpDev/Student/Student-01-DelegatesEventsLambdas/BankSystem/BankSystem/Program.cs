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
                acc1.Overdrawn += (sender, e) => Console.WriteLine($"Your account balance is {acc1.GetBalance()} as of {e.Timestamp}.  You are overdrawn.  Don't be.");

                acc1.ProtectionLimitExceeded += (sender, e) => Console.WriteLine($"Account balances over £50,000 are not protected. Your balance is {acc1.GetBalance()} as of {e.Timestamp}");
                
                // Do some stuff.
                acc1.Deposit(10000);
                acc1.Deposit(30000);
                acc1.Deposit(40000);
                acc1.Withdraw(1000000);
            }
        }
    }
}
