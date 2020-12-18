using System.Collections.Generic;
using FluentAssertions;
using System.IO;
using Xunit;

namespace Day3Tests
{
    public class Day3Tests
    {
        [Fact]
        public void GetPassports_ReturnsPassportsAsAList()
        {
            // Arrange
            var text = File.ReadAllText(@"..\..\..\..\Day3\RawInput.txt");

            // Act
            var result = GetPassports(text);

            // Assert
            result.Should().BeOfType(typeof(List<string>));
        }

        private List<string> GetPassports(string text)
        {
            var textSplit = new List<string> (text.Split("\r\n\r\n"));
            foreach (var passport in textSplit)
            {
                passport.Split(':');
            }

            return textSplit;
        }
    }
}
