using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class DataSrc
    {
        public static IEnumerable<int> FetchFastData() => new List<int> { 1, 2, 3, 4, 5 };

        public static async Task<IEnumerable<int>> FetchSlowData1()
        {
            List<int> items = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                await Task.Delay(1000);  // Simulate waiting for data to come through. 
                items.Add(i);
            }
            return items;
        }

        public static async IAsyncEnumerable<int> FetchSlowData2()
        {
            for (int i = 1; i <= 5; i++)
            {
                await Task.Delay(1000);  // Simulate waiting for data to come through. 
                yield return i;
            }
        }
    }
}
