using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulStandardDelegates
{
    public class PredicateDemo
    {
        public static void DoDemo()
        {
            UsePredicate(n => n % 2 == 0);
        }

        static void UsePredicate(Predicate<int> predicate)
        {
            bool result = predicate(42);
            Console.WriteLine($"\nInvoked a Predicate<int>, result is {result}");
        }
    }
}
