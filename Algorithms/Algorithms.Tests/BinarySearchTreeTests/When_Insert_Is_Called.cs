using Shouldly;
using Xunit;

namespace Algorithms.Tests.BinarySearchTreeTests
{
    public class When_Insert_Is_Called : BinarySearchTreeTest
    {
        [Fact]
        public void Then_Contains_Returns_True()
        {
            Tree.Insert(1);

            Tree.Contains(1).ShouldBeTrue();
        }

        [Theory]
        [InlineData(2, 3, 6, 5, 4, 1)]
        public void Then_Contains_Returns_True_For_All_Items(params int[] items)
        {
            foreach (var i in items)
            {
                Tree.Insert(i);
            }

            foreach (var i in items)
            {
                Tree.Contains(i).ShouldBeTrue();
            }
        }

        [Fact]
        public void Then_Tree_Is_Not_Empty()
        {
            Tree.IsEmpty.ShouldBeTrue();

            Tree.Insert(10);

            Tree.IsEmpty.ShouldBeFalse();
        }
    }
}