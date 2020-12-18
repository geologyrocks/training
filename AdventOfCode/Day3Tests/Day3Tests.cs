using System.Collections.Generic;
using FluentAssertions;
using System.IO;
using System.Linq;
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

        [Fact]
        public void FieldCheck_ReturnsCountOfFieldsInPassport()
        {
            // Arrange
            var text = File.ReadAllText(@"..\..\..\..\Day3\RawInput.txt");
            var passports = GetPassports(text);

            // Act
            var (validCount, invalidCount) = FieldCheck(passports);

            // Assert
            validCount.Should().Be(242);
            invalidCount.Should().Be(44);
        }

        private (int, int) FieldCheck(List<string> passports)
        {
            var validCount = 0;
            var invalidCount = 0;
            foreach (var passportString in passports)
            {
                var permittedFields = new List<string>()
                {
                    "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
                };
                var passportFields = new List<string>(passportString.Split(':'));
                var cleanPassportFields = new List<string>();
                passportFields.RemoveAt(passportFields.Count - 1);
                foreach (var field in passportFields)
                {
                    cleanPassportFields.Add(field.Substring(field.Length -3));
                }
                if (cleanPassportFields.Intersect(permittedFields).Count() >= 7)
                {
                    validCount++;
                }
                else
                {
                    invalidCount++;
                }
            }

            return (validCount, invalidCount);
        }

        private List<string> GetPassports(string text)
        {
            return new List<string> (text.Split("\r\n\r\n"));
        }
    }
}
