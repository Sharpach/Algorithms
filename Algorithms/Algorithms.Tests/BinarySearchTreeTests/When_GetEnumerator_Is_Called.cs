using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.Tests
{
    public class When_GetEnumerator_Is_Called
    {
        private readonly BinarySearchTree<int> _tree;

        public When_GetEnumerator_Is_Called()
        {
            _tree = new BinarySearchTree<int>();
        }

        [Fact]
        public void Then_Enumerator_Is_In_Order_Traversal()
        {
            _tree.Insert(4);
            _tree.Insert(3);
            _tree.Insert(1);
            _tree.Insert(2);
            _tree.Insert(6);
            _tree.Insert(5);

            var iterator = _tree.GetEnumerator();
            iterator.MoveNext();

            IteratorShouldBe(iterator, 1);
            IteratorShouldBe(iterator, 2);
            IteratorShouldBe(iterator, 3);
            IteratorShouldBe(iterator, 4);
            IteratorShouldBe(iterator, 5);
            IteratorShouldBe(iterator, 6);
        }

        private static void IteratorShouldBe(IEnumerator<int> iterator, int value)
        {
            iterator.Current.Should().Be(value);
            iterator.MoveNext();
        }
    }
}