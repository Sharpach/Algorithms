using Shouldly;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.BinarySearchTreeTests
{
    public class When_Data_Constructor_Is_Called
    {
        private const int DefaultData = 10;

        private readonly BinarySearchTree<int> _tree;

        public When_Data_Constructor_Is_Called()
        {
            _tree = new BinarySearchTree<int>(DefaultData);
        }

        [Fact]
        public void Then_IsEmpty_Is_False()
        {
            _tree.IsEmpty.ShouldBeFalse();
        }

        [Fact]
        public void Then_Enumeration_Yields_Exactly_One_Item()
        {
            _tree.Count().ShouldBe(1);
        }

        [Fact]
        public void Then_Contains_Returns_True_For_Data_Used_At_Construction()
        {
            _tree.Contains(DefaultData).ShouldBeTrue();
        }
    }
}