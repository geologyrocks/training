using System;
using System.Collections.Generic;
using System.Linq;

namespace CyclicListApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            var cyclicList = new CyclicList<object>(7)
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10
            };
            cyclicList.GetAllElements();
            Console.WriteLine("");
            var stringList = new CyclicList<object>(3)
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
                "h",
                "i",
                "j"
            };
            stringList.GetAllElements();
            Console.WriteLine("");
            var mixList = new CyclicList<object>(5)
            {
                "a",
                "b",
                1,
                "d",
                4,
                new DateTime(),
                "h",
                ("this",4),
                new List<int> {2,3,5,6},
                "j"
            };
            mixList.GetAllElements(); Console.WriteLine("");
        }
    }
}
