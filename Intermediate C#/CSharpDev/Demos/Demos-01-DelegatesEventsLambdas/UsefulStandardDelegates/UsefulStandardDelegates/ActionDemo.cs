using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulStandardDelegates
{
    public class ActionDemo
    {
        public static void DoDemo()
        {
            UseAction0(() => Console.WriteLine("Hello!"));
            UseAction1(n => Console.WriteLine($"The next number is {n + 1}"));
            UseAction2((s, n) => Console.WriteLine($"This example has been brought to you with the word {s} and the number {n}"));
        }

        static void UseAction0(Action action)
        {
            Console.WriteLine("\nAbout to invoke an Action");
            action();
        }

        static void UseAction1(Action<int> action)
        {
            Console.WriteLine("\nAbout to invoke an Action<int>");
            action(42);
        }

        static void UseAction2(Action<string, int> action)
        {
            Console.WriteLine("\nAbout to invoke an Action<string, int>");
            action("Wibble", 42);
        }
    }
}
