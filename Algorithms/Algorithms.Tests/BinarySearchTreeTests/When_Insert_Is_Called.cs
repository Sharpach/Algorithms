using Algorithms.Models;
using FluentAssertions;
using System;
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

            _tree.Contains(1).Should().BeTrue();
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
                _tree.Contains(i).Should().BeTrue();
            }
        }

        [Fact]
        public void Then_Tree_Is_Not_Empty()
        {
            _tree.IsEmpty.Should().BeTrue();

            _tree.Insert(10);

            _tree.IsEmpty.Should().BeFalse();
        }

        [Fact]
        public void If_Element_To_Insert_Is_A_Duplicate_Then_ArgumentException_Is_Thrown()
        {
            const int duplicateToInsert = 12;

            _tree.Insert(duplicateToInsert);

            Action badInsert = () => _tree.Insert(duplicateToInsert);

            badInsert.Should().Throw<ArgumentException>("The element already exists in the tree.");
        }

        [Fact]
        public void If_Element_Is_Less_Than_Root_Then_Element_Is_Inserted_Into_Left_Subtree()
        {
            const int rootNodeValue = 10;
            const int valueToInsert = rootNodeValue - 1;

            var rootNode = new BinaryTreeNode<int>
            {
                Data = rootNodeValue
            };
            var tree = new BinarySearchTree<int>(rootNode);

            tree.Insert(valueToInsert);

            rootNode.LeftChild.Should().NotBeNull();
            rootNode.LeftChild.Data.Should().Be(valueToInsert);
        }

        [Fact]
        public void If_Element_Is_Greater_Than_Root_Then_Element_Is_Inserted_Into_Right_Subtree()
        {
            const int rootNodeValue = 10;
            const int valueToInsert = rootNodeValue + 1;

            var rootNode = new BinaryTreeNode<int>
            {
                Data = rootNodeValue
            };
            var tree = new BinarySearchTree<int>(rootNode);

            tree.Insert(valueToInsert);

            rootNode.RightChild.Should().NotBeNull();
            rootNode.RightChild.Data.Should().Be(valueToInsert);
        }
    }
}