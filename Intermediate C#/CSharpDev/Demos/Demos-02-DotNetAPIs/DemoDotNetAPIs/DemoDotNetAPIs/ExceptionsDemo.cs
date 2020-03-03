using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DemoDotNetAPIs
{
    static class ExceptionsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("ExceptionsDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoFileException();
            DemoCustomException(false);
            DemoCustomException(true);
        }

        private static void DemoFileException()
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("Myfile.txt", true);
                sw.WriteLine("Hello world.");
                sw.WriteLine("Thank you, and goodnight.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }


        private static void DemoCustomException(bool failDeliberately)
        {
            try
            {
                Console.WriteLine("Start of try block.");
                if (failDeliberately)
                    throw new MyCustomException("Failing deliberately!");
                Console.WriteLine("End of try block.");
            }
            catch (MyCustomException ex)
            {
                Console.WriteLine("Custom exception at {0}, message: {1}.", ex.Timestamp, ex.Message);
            }
        }
    }

    class MyCustomException : Exception
    {
        public DateTime Timestamp = DateTime.Now;
    
        public MyCustomException()
        {}

        public MyCustomException(string message) : base(message)
        {}

        public MyCustomException(string message, Exception innerException) 
            : base(message, innerException)
        {}
    }
}
