using Xunit;
using System;
using System.Collections.Generic;
using HiLoGame2Library;
using HiLoGame2Library.Dependencies;

namespace HiLoGame2Tests
{
    public class HiLoGame2Tests
    {
        IMagicNumberGenerator magicNumberGenerator = new MagicNumberGeneratorStub();
        HiLoGame2 fixture;

        public HiLoGame2Tests()
        {
            fixture = new HiLoGame2(magicNumberGenerator, null);
        }

        [Fact]
        public void ExamineGuess_TooLow_ReturnsHigher()
        {
            Assert.Equal("Higher", fixture.ExamineGuess(10, 50));
        }

        [Fact]
        public void ExamineGuess_TooHigh_ReturnsLower()
        {
            Assert.Equal("Lower", fixture.ExamineGuess(60, 50));
        }

        [Fact]
        public void ExamineGuess_Correct_ReturnsCorrect()
        {
            Assert.Equal("Correct", fixture.ExamineGuess(50, 50));
        }

        [Fact]
        public void FormatResultMessage_SeveralGuesses_ReturnsStringOfGuesses()
        {
            List<int> guesses = new List<int> { 50, 25, 12, 18, 21 };

            String actual = fixture.FormatResultMessage(guesses);
            String expected = "You took 5 guesses: 50 25 12 18 21";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormatResultMessage_SingleGuess_ReturnsStringOfSingularGuess()
        {
            List<int> guesses = new List<int> { 50 };

            String actual = fixture.FormatResultMessage(guesses);
            String expected = "The number is 50, you got it right first time!";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayGame_SeveralGuesses_ReturnsStringOfGuesses()
        {
            // Arrange.
            IGuessProducer guessProducer = new GuessProducerStub(120, 60, 90, 105, 100);
            HiLoGame2 game = new HiLoGame2(magicNumberGenerator, guessProducer);

            // Act.
            String actual = game.PlayGame(100);
            String expected = "You took 5 guesses: 120 60 90 105 100";

            // Assert.
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayGame_SingleGuess_ReturnsStringOfSingularGuess()
        {
            // Arrange.
            IGuessProducer guessProducer = new GuessProducerStub(100);
            HiLoGame2 game = new HiLoGame2(magicNumberGenerator, guessProducer);

            // Act.
            String actual = game.PlayGame(100);
            String expected = "The number is 100, you got it right first time!";

            // Assert.
            Assert.Equal(expected, actual);
        }

        // Additional tests, to verify correct random number generation.
        [Fact]
        public void GenerateMagicNumber_NormalRange_NumberInRange()
        {
            IMagicNumberGenerator generator = new MagicNumberGeneratorRandom();
            int actual = generator.GenerateMagicNumber(100);
            Assert.True(actual >= 1);
            Assert.True(actual <= 100);
        }

        [Fact]
        public void GenerateMagicNumber_TinyRange_NumberInRange()
        {
            IMagicNumberGenerator generator = new MagicNumberGeneratorRandom();
            int actual = generator.GenerateMagicNumber(1);
            Assert.Equal(1, actual);
        }
    }
}
