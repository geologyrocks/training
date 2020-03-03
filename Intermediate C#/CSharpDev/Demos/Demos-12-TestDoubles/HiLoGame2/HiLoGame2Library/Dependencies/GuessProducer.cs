using System;

namespace HiLoGame2Library.Dependencies
{
    public interface IGuessProducer
    {
        int GetGuess();
    }

    public class GuessProducerConsole : IGuessProducer
    {
        public int GetGuess()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }
    }

    public class GuessProducerStub : IGuessProducer
    {
        private int[] guesses;
        private int index = 0;

        public GuessProducerStub(params int[] guesses)
        {
            this.guesses = guesses;
        }

        public int GetGuess()
        {
            return guesses[index++];
        }
    }
}
