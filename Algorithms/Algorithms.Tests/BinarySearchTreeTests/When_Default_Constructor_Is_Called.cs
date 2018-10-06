using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.BinarySearchTreeTests
{
    public class When_Default_Constructor_Is_Called
    {
        [Fact]
        public void Then_IsEmpty_Is_True()
        {
            new BinarySearchTree<int>().IsEmpty.Should().BeTrue();
        }

        [Fact]
        public void Then_Enumeration_Yields_No_Items()
        {
            new BinarySearchTree<int>().Should().BeEmpty();
        }
    }
}