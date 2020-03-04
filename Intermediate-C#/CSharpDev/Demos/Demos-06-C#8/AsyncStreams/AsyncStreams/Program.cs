using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Enumeration_SimpleData();

            await Enumeration_SlowData1();

            await Enumeration_SlowData2();

            Console.WriteLine("All Done");
        }

        private static void Enumeration_SimpleData()
        {
            IEnumerable<int> numbers = DataSrc.FetchFastData();

            Console.WriteLine("\nLooping through enumerable, using foreach");
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("Looping through enumerable, using explicit syntax"); 
            IEnumerator<int> enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                int item = enumerator.Current;
                Console.WriteLine(item);
            }
        }

        private static async Task Enumeration_SlowData1()
        {
            Console.WriteLine("\nFetching slow data v1");
            foreach (var item in await DataSrc.FetchSlowData1())
            {
                Console.WriteLine(item);
            }
        }

        private static async Task Enumeration_SlowData2()
        {
            Console.WriteLine("\nLooping through async enumerable, using foreach");
            await foreach (var item in DataSrc.FetchSlowData2())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nLooping through async enumerable, using explicit syntax");
            IAsyncEnumerator<int> asyncEnum = DataSrc.FetchSlowData2().GetAsyncEnumerator();
            try
            {
                while (await asyncEnum.MoveNextAsync())
                {
                    int item = asyncEnum.Current;
                    Console.WriteLine(item);
                }
            }
            finally
            {
                await asyncEnum.DisposeAsync();
            }
        }
    }
}
