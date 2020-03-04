using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonMethodsLambdas
{
    delegate void MyHandlerNoParams();
    delegate void MyHandlerOneParam(int i);
    delegate void MyHandlerMultiParams(object sender, EventArgs args);

    static class LambdaDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nLambdaDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoNoParams();
            DemoOneParam();
            DemoMultiParams();
        }
        
        static void DemoNoParams()
        {
            MyHandlerNoParams del1 = () => Console.WriteLine("Hello single-line lambda!");

            MyHandlerNoParams del2 = () =>
            {
                Console.WriteLine("Hello multi-line lambda!");
                Console.WriteLine("Goodbye multi-line lambda!");
            };

            del1();
            del2();
        }

        static void DemoOneParam()
        {
            MyHandlerOneParam del1 = i => Console.WriteLine("Via del1, value is {0}.", i);

            MyHandlerOneParam del2 = (i) => Console.WriteLine("Via del2, value is {0}.", i);

            MyHandlerOneParam del3 = (int i) => Console.WriteLine("Via del3, value is {0}.", i);

            del1(100);
            del2(200);
            del3(300);
        }

        static void DemoMultiParams()
        {
            MyHandlerMultiParams del1 = (sender, args) => Console.WriteLine("Do something1...");

            MyHandlerMultiParams del2 = (object sender, EventArgs args) =>
                                   Console.WriteLine("Do something2...");

            del1(null, new EventArgs());
            del2(null, new EventArgs());
        }
    }
}
