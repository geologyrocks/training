using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclicListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoCyclicListOfInts();
            DemoCyclicListOfStrings();

            Console.WriteLine("\n");
        }

        private static void DemoCyclicListOfInts()
        {
            Console.WriteLine("Create and use a CyclicList<int>");

            CyclicList<int> lotteryNumbers = new CyclicList<int>(6);

            lotteryNumbers.Add(19);
            lotteryNumbers.Add(1);
            lotteryNumbers.Add(2);
            lotteryNumbers.Add(7);

            int lotteryNumber0 = lotteryNumbers[0];
            Console.WriteLine($"Lottery number 0 is: {lotteryNumber0}");

            Console.Write("Collection: ");
            lotteryNumbers.Display();
        }

        private static void DemoCyclicListOfStrings()
        {
            Console.WriteLine("\n\nCreate and use a CyclicList<string>");

            // Note in this example, there are 7 dwarfs (as you know)
            // But we've deliberately created a CyclicList of only 5 elements.
            // This is to test the cyclic behaviour of CyclicList, 
            // i.e. Doc and Sneezy should wrap around to elements [0] and [1].
            CyclicList<string> dwarfs = new CyclicList<string>(5);

            dwarfs.Add("Happy");
            dwarfs.Add("Sleepy");
            dwarfs.Add("Grumpy");
            dwarfs.Add("Bashful");
            dwarfs.Add("Dopey");
            dwarfs.Add("Doc");
            dwarfs.Add("Sneezy");

            string dwarf3 = dwarfs[3];
            Console.WriteLine("Dwarf 3 is: " + dwarf3);

            Console.Write("Collection: ");
            dwarfs.Display();
        }
    }
}
