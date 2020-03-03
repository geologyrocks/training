using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncDelegates
{
    class FactorFinder
    {
        /// Count the factors in a number. 
        /// This method does not know whether it's called synchronously or asynchronously.
        public int MyCountFactors(ref int number, out int largestFactor)
        {
            largestFactor = 0;
            int factorCount = 0;

            // Count the number of factors, and also find the largest factor
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    factorCount++;
                    largestFactor = i;
                }

                // Sleep for a millisecond, for illustrative purposes :-)
                System.Threading.Thread.Sleep(10);
            }

            // Return the number of factors
            return factorCount;
        }
    }
}
