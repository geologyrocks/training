using System;

namespace HiLoGame3Library.Dependencies
{
    public interface IMagicNumberGenerator
    {
        int GenerateMagicNumber(int upperLimit);
    }

    public class MagicNumberGeneratorRandom : IMagicNumberGenerator
    {
        public int GenerateMagicNumber(int upperLimit)
        {
            return 1 + new Random().Next(upperLimit);
        }
    }
}
