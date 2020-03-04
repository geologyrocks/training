using System;
using System.Collections.Generic;
using System.Text;

namespace MiscLanguageFeatures
{
    class NullCoalescingAssignmentOperatorDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nNullCoalescingAssignmentOperatorDemo");
            Console.WriteLine("------------------------------------------------------");

            List<int> numbers = MaybeGetList();   // This may be null          
            (numbers ??= new List<int>()).Add(42);

            Console.WriteLine(string.Join(" ", numbers));  
        }

        private static List<int> MaybeGetList()
        {
            double r = new Random().NextDouble();
            if (r < 0.5)
                return null;
            else
                return new List<int> { 3, 12, 19, 1, 2, 7 };
        }
    }
}
