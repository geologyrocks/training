using System;

namespace CyclicListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var cyclicList = new CyclicList<object>(7);
            cyclicList.Add(1);
            cyclicList.Add(2);
            cyclicList.Add(3);
            cyclicList.Add(4);
            cyclicList.Add(5);
            cyclicList.Add(6);
            cyclicList.Add(7);
            cyclicList.Add(8);
            cyclicList.Add(9);
            cyclicList.Add(10);
            //Console.WriteLine(test.GetElement(0));
            //Console.WriteLine(test.GetElement(5));
            //Console.WriteLine(test.GetElement(6));
            cyclicList.GetAllElements();
        }
    }
}
