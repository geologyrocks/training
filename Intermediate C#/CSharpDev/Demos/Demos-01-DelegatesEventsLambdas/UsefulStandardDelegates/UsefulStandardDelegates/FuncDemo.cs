using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulStandardDelegates
{
    public class FuncDemo
    {
        public static void DoDemo()
        {
            UseFunc0(() => DateTime.Today.ToLongDateString());
            
            UseFunc1(n => DateTime.Today.AddDays(n).ToLongDateString());

            UseFunc2((n, b) =>
            {
                string dateStr = DateTime.Today.AddDays(n).ToLongDateString();

                if (b)
                    dateStr = dateStr.ToUpper();

                return dateStr;
            });
        }

        static void UseFunc0(Func<string> func)
        {
            string result = func();
            Console.WriteLine($"\nInvoked a Func<string>, result is {result}");
        }

        static void UseFunc1(Func<int, string> func)
        {
            string result = func(42);
            Console.WriteLine($"\nInvoked a Func<int, string>, result is {result}");
        }

        static void UseFunc2(Func<int, bool, string> func)
        {
            string result = func(42, true);
            Console.WriteLine($"\nInvoked a Func<int, bool, string>, result is {result}");
        }
    }
}
