using System.Collections.Generic;
using System;
using Xunit;

namespace Algorithms.Tests
{
    public class ReversePolishNotationTests
    {
        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("2+2*2", 6)]
        [InlineData("2^2", 4)]
        [InlineData("1--1", 2)]
        [InlineData("1 + 1 - 1", 1)]
        [InlineData("1+1-1", 1)]
        [InlineData("1+1+(-1)", 1)]
        [InlineData("2^2+2", 6)]
        [InlineData("(2/2)^2", 1)]
        [InlineData("2+(-2)* 2", -2)]
        public void Check(string input, double expected)
        {
            Assert.Equal(expected, ReversePolishNotation.Calculate(ReversePolishNotation.Parse(input)));
        }
    }

    public class ReversePolishNotationParserTests
    {
        [Fact]
        public void Check()
        {
            Assert.Equal(new List<string>() { "1", "1", "+", "1", "-" }, ReversePolishNotation.Parse("1+1-1"));
        }
    }
}
