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
                acc1.Overdrawn += Overdrawn;
                acc1.ProtectionLimitExceeded += ProtectionLimitExceeded;

                // Do some stuff.
                acc1.Deposit(10000);
                acc1.Deposit(30000);
                acc1.Deposit(40000);
                acc1.Withdraw(1000000);
            }


            private static void Overdrawn(object sender, BankAccountEventArgs e)
            {
                Console.WriteLine($"You are overdrawn.  Don't be.");
                
            }
            private static void ProtectionLimitExceeded(object sender, BankAccountEventArgs e)
            {
                Console.WriteLine($"Account balances over £50,000 are not protected.");
            }
        }
    }
}
