using System;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.FenwikTree
{
    public class FenwickTreeTests
    {
        [Fact]
        public void FenwickTree_GetSumOnTree_ReturnCorrectSum()
        {
            var expected = 16;
            var massive = new int[] { 1, 3, 5, 7, 9, 11 };
            var tree = new FenwickTree<int>(massive, new Func<int, int, int>((x, y) => x + y));

            var result = tree.GetPrefixSum(3);

            result.Should().Be(expected);
        }
    }
}
