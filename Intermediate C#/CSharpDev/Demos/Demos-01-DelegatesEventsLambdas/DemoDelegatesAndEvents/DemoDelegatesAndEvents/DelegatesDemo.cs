using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting.Messaging;

namespace DemoDelegatesAndEvents
{
    // Define a delegate type.
    public delegate double BinaryOp(double x, double y);


    // Define a class with mathematical operations. All the ops match the delegate signature :-)
    public static class MathOps
    {
        public static double Add(double a, double b)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        public static double Abs(double a)
        {
            if (a < 0)
                a = -a;
            return a;
        }
    }

    // Client code.
    static class DelegatesDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nDelegatesDemo");
            Console.WriteLine("------------------------------------------------------");

            // Create a delegate instance.
            BinaryOp selectedOp;

            Console.Write("Which op do you want to do [a|s|m|d] ");
            string input = Console.ReadLine();

            // Set the delegate instance to refer to a suitable method.
            if (input[0] == 'a')
            {
                // This is the full-blown syntax for making a delegate instance point to a method.
                selectedOp = new BinaryOp(MathOps.Add);
            }
            else if (input[0] == 's')
            {
                // This is the short-cut syntax (preferred) for making a delegate instance point to a method.
                selectedOp = MathOps.Subtract;
            }
            else if (input[0] == 'm')
            {
                selectedOp = MathOps.Multiply;
            }
            else if (input[0] == 'd')
            {
                selectedOp = MathOps.Divide;
            }
            else
            {
                throw new InvalidOperationException("Invalid operation specified. I quit!");
            }


            // DO SOME OTHER STUFF..


            // When we're ready, call method via delegate....


            // Option 1: Call method synchronously.
            Console.WriteLine("\nCalling the operation synchronously...");
            double result = selectedOp(10, 20);
            Console.WriteLine($"Result of synchronous call: {result}.");


            // Option 2: Call method asynchronously, using polling.
            Console.WriteLine("\nCalling the operation asynchronously, using polling...");
            IAsyncResult ar = selectedOp.BeginInvoke(30, 40, null, 1234);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"I called the operation asynchronously, using polling. It is now {DateTime.Now}");
                System.Threading.Thread.Sleep(1000);

                if (ar.IsCompleted)
                {
                    Console.WriteLine($"Binary op finished with result {selectedOp.EndInvoke(ar)}, and the async state is {ar.AsyncState}");
                    break;
                }
            }


            // Option 3: Call method asynchronously, using a callback.
            Console.WriteLine("\nCalling the operation asynchronously, using a callback...");
            selectedOp.BeginInvoke(50, 60, MyCallBack, 5678);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"I called the operation asynchronously, using a callback. It is now {DateTime.Now}.");
                System.Threading.Thread.Sleep(1000);
            }
        }

        private static void MyCallBack(IAsyncResult ar)
        {
            // Get the delegate through which the method was called asynchronously.
            AsyncResult asyncresult = (AsyncResult)ar;
            BinaryOp del = (BinaryOp)asyncresult.AsyncDelegate;

            Console.WriteLine($"Binary op finished with result {del.EndInvoke(ar)}, and the async state is {ar.AsyncState}.");
        }
    }
}
