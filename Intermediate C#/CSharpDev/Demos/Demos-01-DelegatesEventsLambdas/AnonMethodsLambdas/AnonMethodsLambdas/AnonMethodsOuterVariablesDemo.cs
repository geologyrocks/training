using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonMethodsLambdas
{
    public delegate int MyDelType();

    public class MyClass
    {
        public static MyDelType MyMethod()
        {
            int myLocalVar = 0;
            return delegate { return ++myLocalVar; };
        }
    }

    static class AnonMethodsOuterVariablesDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nAnonMethodsOuterVariablesDemo");
            Console.WriteLine("------------------------------------------------------");

            MyDelType d = MyClass.MyMethod();
            Console.WriteLine(d());
            Console.WriteLine(d());
        }
    }
}
