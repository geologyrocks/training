using System;
using System.Collections.Generic;

namespace HiLoGame0Application
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimit = 100;
            int magicNumber = 1 + new Random().Next(upperLimit);
            List<int> guesses = new List<int>();

            Console.Write($"Guess a number between 1 and {upperLimit} inclusive: ");
            while (true)
            {
                string input = Console.ReadLine();
                int thisGuess = int.Parse(input);
                guesses.Add(thisGuess);

                if (thisGuess > magicNumber)
                {
                    Console.Write("Lower! ");
                }
                else if (thisGuess < magicNumber)
                {
                    Console.Write("Higher! ");
                }
                else
                {
                    Console.Write("Correct! ");
                    break;
                }
            }

            Console.Write($"You took {guesses.Count} guesses: ");
            foreach (int n in guesses)
            {
                Console.Write($"{n} ");
            }
            Console.WriteLine();
        }
    }
}
