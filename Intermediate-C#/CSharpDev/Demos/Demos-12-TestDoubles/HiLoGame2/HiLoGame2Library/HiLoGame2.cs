using HiLoGame2Library.Dependencies;
using System;
using System.Collections.Generic;

namespace HiLoGame2Library
{
    public class HiLoGame2
    {
        private IMagicNumberGenerator magicNumberGenerator;
        private IGuessProducer guessProducer;

        public HiLoGame2(IMagicNumberGenerator g, IGuessProducer p)
        {
            this.magicNumberGenerator = g;
            this.guessProducer = p;
        }

        public String PlayGame(int upperLimit)
        {
            int magicNumber = magicNumberGenerator.GenerateMagicNumber(upperLimit);
            List<int> guesses = new List<int>();

            Console.Write($"Guess a number between 1 and {upperLimit} inclusive: ");
            while (true)
            {
                int thisGuess = guessProducer.GetGuess();
                guesses.Add(thisGuess);

                String testOutcome = ExamineGuess(thisGuess, magicNumber);
                if (testOutcome == "Correct")
                {
                    break;
                }
            }
            return FormatResultMessage(guesses);
        }

        public String ExamineGuess(int thisGuess, int magicNumber)
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

        public String FormatResultMessage(List<int> guesses)
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
