using Algorithms.SegmentTree;
using Xunit;

namespace Algorithms.Tests.SegmentTreeTests
{
    public class SegmentTreeTests
    {
        [Theory]
        [InlineData(0, 9, 1)]
        [InlineData(1, 1, 5)]
        [InlineData(0, 4, 3)]
        [InlineData(5, 9, 1)]
        [InlineData(7, 8, 2)]
        [InlineData(2, 5, 4)]
        public void Should_FindMinValue(int startIndex, int endIndex, int expectedValue)
        {
            var numbers = new[] { 3, 5, 10, 4, 7, 9, 1, 2, 6, 8 };
            var tree = new SegmentTree<int>(numbers);

            var min = tree.MinQuery(startIndex, endIndex);

            Assert.Equal(expectedValue, min);
        }
    }
}
