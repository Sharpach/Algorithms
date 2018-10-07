using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.CatalanNumbersTests
{
    public class CatalanNumbersTests
    {
        [Fact]
        public void GetNumbers_Generate3rdCatalanNumber_Return5()
        {
            var expected = 5;

            var number = CatalanNumberGenerator.GetNumberOn(3);

            number.Should().Be(expected);
        }

        [Fact]
        public void GetNumbers_Generate15rdCatalanNumber_Return9694845()
        {
            var expected = 9694845;

            var number = CatalanNumberGenerator.GetNumberOn(15);

            number.Should().Be(expected);
        }

        [Fact]
        public void GetNumbers_Generate0rdCatalanNumber_Return1()
        {
            var expected = 0;

            var number = CatalanNumberGenerator.GetNumberOn(0);

            number.Should().Be(expected);
        }

        [Fact]
        public void GetNumbers_GenerateNegativePos_Return0()
        {
            var expected = 0;

            var number = CatalanNumberGenerator.GetNumberOn(-1);

            number.Should().Be(expected);
        }
    }
}
