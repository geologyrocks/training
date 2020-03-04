using System;
using System.Collections.Generic;
using System.Text;

namespace MiscLanguageFeatures
{
    interface IMyInterface
    {
        void Method1(int i);
        void Method2(double d);
        
        void Method3(String s)
        {
            Console.WriteLine($"IParentInterface.Method3 received {s}");
        }
    }

    class MyClassA : IMyInterface
    {
        public void Method1(int i) => Console.WriteLine($"MyClassA.Method1 received {i}");
        
        public void Method2(double d) => Console.WriteLine($"MyClassA.Method2 received {d}");
    }

    class MyClassB : IMyInterface
    {
        public void Method1(int i) => Console.WriteLine($"MyClassB.Method1 received {i}");

        public void Method2(double d) => Console.WriteLine($"MyClassB.Method2 received {d}");

        public void Method3(String s) => Console.WriteLine($"MyClassB.Method3 received {s}");
    }

    class DefaultInterfaceMethodsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nDefaultInterfaceMethodsDemo");
            Console.WriteLine("------------------------------------------------------");

            ProcessIMyInterface(new MyClassA());
            ProcessIMyInterface(new MyClassB());
        }

        private static void ProcessIMyInterface(IMyInterface obj)
        {
            obj.Method1(42);
            obj.Method2(3.14);
            obj.Method3("wibble");
        }
    }
}
