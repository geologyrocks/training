using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    namespace BankSystem
    {
        class Program
        {
            static void Main(string[] args)
            {
                BankAccount acc1 = new BankAccount("Peter");

                // Handle events using verbose (or shorthand) syntax.
                acc1.ProtectionLimitExceeded += new EventHandler<BankAccountEventArgs>(My_ProtectionLimitExceeded_Handler);
                acc1.Overdrawn += My_Overdrawn_Handler;

                // Handle events using anonymous methods.
                acc1.ProtectionLimitExceeded += delegate (object sender, BankAccountEventArgs e)
                {
                    Console.WriteLine($"ProtectionLimitExceeded anon method, eventargs {e}.");
                };

                acc1.Overdrawn += delegate (object sender, BankAccountEventArgs e)
                {
                    Console.WriteLine($"Overdrawn anon method, eventargs {e}.");
                };

                // Handle events using lambda expressions.
                acc1.ProtectionLimitExceeded += (sender, e) => Console.WriteLine($"ProtectionLimitExceeded lambda, eventargs {e}.");
                acc1.Overdrawn += (sender, e) => Console.WriteLine($"Overdrawn lambda, eventargs {e}.");

                // Do some stuff.
                acc1.Deposit(10000);
                acc1.Deposit(30000);
                acc1.Deposit(40000);
                acc1.Withdraw(1000000);
            }

            static void My_ProtectionLimitExceeded_Handler(object sender, BankAccountEventArgs e)
            {
                Console.WriteLine($"ProtectionLimitExceeded handler method, eventargs {e}.");
            }

            static void My_Overdrawn_Handler(object sender, BankAccountEventArgs e)
            {
                Console.WriteLine($"Overdrawn handler method, eventargs {e}.");
            }
        }
    }
}
