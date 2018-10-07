using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.FactorizationTests
{
    public class FactorizationTest
    {
        [Fact]
        public void GetFactors_FactorizationOf825_ReturnCollection()
        {
            var expected = new List<int>{3, 5, 5, 11};
            
            var result  = Factorization.GetFactorsOf(825);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetFactors_FactorizationOf1386_ReturnCollection()
        {
            var expected = new List<int> { 2, 3, 3, 7, 11 };

            var result = Factorization.GetFactorsOf(1386);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetFactors_FactorizationOf0_ReturnCollectionWith0()
        {
            var result = Factorization.GetFactorsOf(0);

            result.Should().BeEquivalentTo(0);
        }

        [Fact]
        public void GetFactors_FactorizationOfNegative_ReturnCollectionWith0()
        {
            var result = Factorization.GetFactorsOf(-1);

            result.Should().BeEquivalentTo(0);
        }
    }
}
