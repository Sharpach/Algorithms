using Xunit;

namespace Algorithms.Tests
{
    public class BracketsBalanceTests
    {
        [Theory]
        [InlineData("(()){()", false)]
        [InlineData("(()){()}", true)]
        [InlineData("[[[(()){}]{}]]", true)]
        [InlineData("(((())()", false)]
        public void Check(string input, bool expected)
        {
            Assert.Equal(expected, BracketsBalance.IsValidBracketString(input));
        }
    }
}