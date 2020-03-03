using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonMethodsLambdas
{
    static class AnonMethodsDemo
    {
        // Declare a delegate type.
        public delegate void MyDelType(int i);

        public static void DoDemo()
        {
            Console.WriteLine("\nAnonMethodsDemo");
            Console.WriteLine("------------------------------------------------------");

            // OK.
            MyDelType del1 = delegate { };

            // This would give a Type mismatch error.
            //   MyDelType del2 = delegate() { };

            // This would give a Type mismatch error.
            //   MyDelType del3 = delegate(long l) { };            
            
            // OK.
            MyDelType del4 = delegate(int i) { };

            // This would give a return-type mismatch
            //   MyDelType del5 = delegate(int i) { return i; };

        }

    }
}
