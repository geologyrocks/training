using System;
using System.Collections.Generic;
using Xunit;
using HiLoGame1Application;

namespace HiLoGame1Tests
{
    public class HiLoGame1Tests
    {
        [Fact]
        public void GenerateMagicNumber_NormalRange_NumberInRange()
        {
            int actual = HiLoGame1.GenerateMagicNumber(100);
            Assert.True(actual >= 1);
            Assert.True(actual <= 100);
        }

        [Fact]
        public void GenerateMagicNumber_TinyRange_NumberInRange()
        {
            int actual = HiLoGame1.GenerateMagicNumber(1);
            Assert.Equal(1, actual);
        }

        [Fact]
        public void ExamineGuess_TooLow_ReturnsHigher()
        {
            Assert.Equal("Higher", HiLoGame1.ExamineGuess(10, 50));
        }

        [Fact]
        public void ExamineGuess_TooHigh_ReturnsLower()
        {
            Assert.Equal("Lower", HiLoGame1.ExamineGuess(60, 50));
        }

        [Fact]
        public void ExamineGuess_Correct_ReturnsCorrect()
        {
            Assert.Equal("Correct", HiLoGame1.ExamineGuess(50, 50));
        }

        [Fact]
        public void FormatResultMessage_SeveralGuesses_ReturnsStringOfGuesses()
        {
            List<int> guesses = new List<int> { 50, 25, 12, 18, 21 };

            String actual = HiLoGame1.FormatResultMessage(guesses);
            String expected = "You took 5 guesses: 50 25 12 18 21";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormatResultMessage_SingleGuess_ReturnsStringOfSingularGuess()
        {
            List<int> guesses = new List<int> { 50 };

            String actual = HiLoGame1.FormatResultMessage(guesses);
            String expected = "The number is 50, you got it right first time!";

            Assert.Equal(expected, actual);
        }
    }
}
