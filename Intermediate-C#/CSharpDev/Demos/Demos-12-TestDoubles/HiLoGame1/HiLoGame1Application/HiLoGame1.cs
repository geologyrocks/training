using System;
using System.Collections.Generic;

namespace HiLoGame1Application
{
    public class HiLoGame1
    {
        static void Main(string[] args)
        {
            int upperLimit = 100;
            int magicNumber = GenerateMagicNumber(upperLimit);
            List<int> guesses = new List<int>();

            Console.Write($"Guess a number between 1 and {upperLimit} inclusive: ");
            while (true)
            {
                int thisGuess = GetGuess();
                guesses.Add(thisGuess);

                String testOutcome = ExamineGuess(thisGuess, magicNumber);
                if (testOutcome == "Correct")
                {
                    break;
                }
            }

            String resultMessage = FormatResultMessage(guesses);
            Console.WriteLine(resultMessage);
        }

        public static int GenerateMagicNumber(int upperLimit)
        {
            return 1 + new Random().Next(upperLimit);
        }

        public static int GetGuess()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        public static String ExamineGuess(int thisGuess, int magicNumber)
        {
            String message;
            if (thisGuess > magicNumber)
            {
                message = "Lower";
            }
            else if (thisGuess < magicNumber)
            {
                message = "Higher";
            }
            else
            {
                message = "Correct";
            }
            Console.Write($"{message}! ");
            return message;
        }

        public static String FormatResultMessage(List<int> guesses)
        {
            if (guesses.Count == 1)
            {
                return $"The number is {guesses[0]}, you got it right first time!";
            }
            else
            {
                String str = $"You took {guesses.Count} guesses: ";

                foreach (int n in guesses)
                {
                    str += n + " ";
                }
                return str.Trim();
            }
        }
    }
}
