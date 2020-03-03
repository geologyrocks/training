using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoDelegatesAndEvents
{
    // Define a delegate type that can "represent" any method that takes a string and returns void.
    public delegate void AccountEventHandler(string message);

    // Define an "event args" class that contains contextual info for account-related events.
    public class AccountEventArgs : EventArgs
    {
        public double TransactionAmount { get; set; }
    }

    // Define the Account class.
    public class Account
    {
        private string name;
        private double balance;

        // Define some events that match our custom delegate type.
        public event AccountEventHandler Overdrawn;
        public event AccountEventHandler IntoCredit;

        // Define an event using the .NET convention, using the standard EventHandler<T> delegate type:
        //   delegate void EventHandler<T>(object sender, T eventargs);
        public event EventHandler<AccountEventArgs> AboveSafetyLimit;

        // This is the maximum recommended balance (assured by government in case of economic meltdown).
        private static double SAFETY_LIMIT = 50000;

        public Account(string name)
        {
            this.name = name;
        }

        public void Deposit(double amount)
        {
            double oldBalance = balance;
            balance += amount;

            if (oldBalance < 0 && balance >= 0)
            {
                IntoCredit?.Invoke("Account is now in credit");
            }

            if (balance >= SAFETY_LIMIT)
            {
                if (AboveSafetyLimit != null)
                {
                    AccountEventArgs arg = new AccountEventArgs();
                    AboveSafetyLimit(this, arg);
                }
            }
        }

        public void Withdraw(double amount)
        {
            double oldBalance = balance;
            balance -= amount;

            if (oldBalance >= 0 && balance < 0)
            {
                Overdrawn?.Invoke("Account is now overdrawn");
            }
        }

        public override string ToString()
        {
            return $"{name} [balance {balance:c}]";
        }
    }

    // Client code.
    static class EventsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nEventsDemo");
            Console.WriteLine("------------------------------------------------------");

            Account acc1 = new Account("John");

            // Create delegate objects representing methods to handle the Overdrawn event.
            AccountEventHandler mydelegate1 = new AccountEventHandler(overdrawnHandler1);
            AccountEventHandler mydelegate2 = new AccountEventHandler(overdrawnHandler2);

            // Show how to combine multi-cast delegates.
            AccountEventHandler mydelegate3 = mydelegate1 + mydelegate2;

            // Handle the Overdrawn event via a multi-cast delegate.
            acc1.Overdrawn += mydelegate3;

            // Handle the Overdrawn event via a method name.
            acc1.Overdrawn += overdrawnHandler3;


            // Handle the IntoCredit event via an anonymous method.
            acc1.IntoCredit += delegate(String message)
            {
                Console.WriteLine($"In the IntoCredit event handler (anon method): {message}.");
            };

            // Handle the IntoCredit event via a lambda expression.
            acc1.IntoCredit += message =>
            {
                Console.WriteLine($"In the IntoCredit event handler (lambda): {message}.");
            };


            // Handle the AboveSafetyLimit event via a method name.
            acc1.AboveSafetyLimit += aboveSafetyLimitHandler;

            // Handle the AboveSafetyLimit event via an anonymous method.
            acc1.AboveSafetyLimit += delegate(object sender, AccountEventArgs args)
            {
                Console.WriteLine($"In the AboveSafetyLimit event handler (anon method) for: {sender}.");
            };

            // Handle the AboveSafetyLimit event via a lambda expression.
            acc1.AboveSafetyLimit += (sender, args) =>
                Console.WriteLine($"In the AboveSafetyLimit event handler (lambda) for: {sender}.");

            acc1.Deposit(1000);
            acc1.Deposit(50000);
            acc1.Withdraw(100000);
            acc1.Deposit(125000);

            Console.WriteLine(acc1);
        }

        static void overdrawnHandler1(string message)
        {
            Console.WriteLine($"In overdrawnHandler1 method: {message}.");
        }

        static void overdrawnHandler2(string message)
        {
            Console.WriteLine($"In overdrawnHandler2 method: {message}.");
        }

        static void overdrawnHandler3(string message)
        {
            Console.WriteLine($"In overdrawnHandler3 method: {message}.");
        }

        static void aboveSafetyLimitHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"In aboveSafetyLimitHandler method for: {sender}.");
        }
    }
}
