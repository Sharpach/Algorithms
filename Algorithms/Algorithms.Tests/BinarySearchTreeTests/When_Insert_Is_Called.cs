using Shouldly;
using Xunit;

namespace Algorithms.Tests.BinarySearchTreeTests
{
    public class When_Insert_Is_Called
    {
        private readonly BinarySearchTree<int> _tree;

        public When_Insert_Is_Called()
        {
            _tree = new BinarySearchTree<int>();
        }

        [Fact]
        public void Then_Contains_Returns_True()
        {
            _tree.Insert(1);

            _tree.Contains(1).ShouldBeTrue();
        }

        [Theory]
        [InlineData(2, 3, 6, 5, 4, 1)]
        public void Then_Contains_Returns_True_For_All_Items(params int[] items)
        {
            foreach (var i in items)
            {
                _tree.Insert(i);
            }

            foreach (var i in items)
            {
                _tree.Contains(i).ShouldBeTrue();
            }
        }

        [Fact]
        public void Then_Tree_Is_Not_Empty()
        {
            _tree.IsEmpty.ShouldBeTrue();

            _tree.Insert(10);

            _tree.IsEmpty.ShouldBeFalse();
        }
    }
}