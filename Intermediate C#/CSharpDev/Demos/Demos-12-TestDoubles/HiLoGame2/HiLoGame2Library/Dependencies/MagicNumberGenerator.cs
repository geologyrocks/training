using System;

namespace HiLoGame2Library.Dependencies
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

    public class MagicNumberGeneratorStub : IMagicNumberGenerator
    {
        public int GenerateMagicNumber(int upperLimit)
        {
            return upperLimit;
        }
    }
}
