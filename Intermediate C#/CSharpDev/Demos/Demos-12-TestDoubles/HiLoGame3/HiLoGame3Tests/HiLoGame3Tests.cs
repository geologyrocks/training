using System;
using System.Collections.Generic;
using Xunit;
using Moq;

using HiLoGame3Library;
using HiLoGame3Library.Dependencies;

namespace HiLoGame3Tests
{
    public class HiLoGame3Tests
    {
        HiLoGame3 fixture;
        Mock<IMagicNumberGenerator> mockMagicNumberGenerator;
        Mock<IGuessProducer> mockGuessProducer;

        public HiLoGame3Tests()
        {
            // Create a mock for IMagicNumberGenerator.
            mockMagicNumberGenerator = new Mock<IMagicNumberGenerator>();

            // Create a mock for IMagicNumberGenerator.
            mockGuessProducer = new Mock<IGuessProducer>();

            // Inject mock objects into a HiLoGame3 instance.
            fixture = new HiLoGame3(mockMagicNumberGenerator.Object, 
                                    mockGuessProducer.Object);
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
        public void PlayGame_SingleGuess_ReturnsStringOfSingularGuess()
        {
            // Arrange - setup expectation for call to IMagicNumberGenerator.GenerateMagicNumber(anyInt).
            mockMagicNumberGenerator.Setup(m => m.GenerateMagicNumber(It.IsAny<int>())).Returns(42);

            // Arrange - setup expectation for call to IGuessProducer.GetGuess().
            mockGuessProducer.Setup(p => p.GetGuess())
                                .Returns(42);

            // Act.
            String actual = fixture.PlayGame(100);
            String expected = "The number is 42, you got it right first time!";

            // Assert.
            Assert.Equal(expected, actual);

            // Verify expected methods were invoked on the mock objects.
            mockMagicNumberGenerator.VerifyAll();
            mockGuessProducer.VerifyAll();
        }

        [Fact]
        public void PlayGame_SeveralGuesses_ReturnsStringOfGuesses()
        {
            // Arrange - setup expectation for call to IMagicNumberGenerator.GenerateMagicNumber(anyInt).
            mockMagicNumberGenerator.Setup(m => m.GenerateMagicNumber(It.IsAny<int>())).Returns(42);

            // Arrange - setup expectation for call to IGuessProducer.GetGuess().
            mockGuessProducer.SetupSequence(p => p.GetGuess())
                                .Returns(50)
                                .Returns(25)
                                .Returns(37)
                                .Returns(43)
                                .Returns(42);

            // Act.
            String actual = fixture.PlayGame(100);
            String expected = "You took 5 guesses: 50 25 37 43 42";

            // Assert.
            Assert.Equal(expected, actual);

            // Verify expected methods were invoked on the mock objects.
            mockMagicNumberGenerator.Verify(m => m.GenerateMagicNumber(It.IsAny<int>()), Times.Exactly(1));
            mockGuessProducer.Verify(m => m.GetGuess(), Times.Exactly(5));
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
