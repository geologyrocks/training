using System;

namespace HiLoGame3Library.Dependencies
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
}
