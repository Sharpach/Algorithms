using Algorithms.Models;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.BinarySearchTreeTests
{
    public class When_Node_Constructor_Is_Called
    {
        private const int DefaultData = 3;
        private const int LeftChildData = DefaultData - 3;
        private const int RightChildData = DefaultData + 3;

        private readonly BinarySearchTree<int> _tree;

        public When_Node_Constructor_Is_Called()
        {
            _tree = new BinarySearchTree<int>(new BinaryTreeNode<int>
            {
                Data = DefaultData
            });
        }

        [Fact]
        public void If_Node_Is_Null_Then_ArgumentNullException_Is_Thrown()
        {
            Action badConstructor = () => new BinarySearchTree<int>(null);

            badConstructor.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Then_IsEmpty_Is_False()
        {
            _tree.IsEmpty.Should().BeFalse();
        }

        [Fact]
        public void Then_Contains_Returns_True()
        {
            _tree.Contains(DefaultData).Should().BeTrue();
        }

        [Fact]
        public void Then_Enumeration_Yields_Exactly_One_Item()
        {
            _tree.Count().Should().Be(1);
        }

        [Theory]
        [InlineData(DefaultData, RightChildData)] // Left child is equal
        [InlineData(LeftChildData, DefaultData)] // Right child is equal
        [InlineData(DefaultData, DefaultData)] // Both children are equal
        [InlineData(RightChildData, RightChildData)] // Left child is greater
        [InlineData(LeftChildData, LeftChildData)] // Right child is lesser
        [InlineData(RightChildData, LeftChildData)] // Left child is greater, right child is lesser
        public void If_Root_Node_Is_Unsorted_Then_InvalidOperationException_Is_Thrown(int leftChild, int rightChild)
        {
            var unsortedNode = new BinaryTreeNode<int>
            {
                Data = DefaultData,
                LeftChild = new BinaryTreeNode<int>
                {
                    Data = leftChild
                },
                RightChild = new BinaryTreeNode<int>
                {
                    Data = rightChild
                }
            };

            Action badConstruction = () => new BinarySearchTree<int>(unsortedNode);

            badConstruction.Should().Throw<InvalidOperationException>("Root node is unsorted.");
        }

        [Theory]
        [InlineData(LeftChildData, LeftChildData + 1)] // Left child is equal
        [InlineData(LeftChildData - 1, LeftChildData)] // Right child is equal
        [InlineData(LeftChildData, LeftChildData)] // Both children are equal
        [InlineData(LeftChildData + 1, LeftChildData + 1)] // Left child is greater
        [InlineData(LeftChildData - 1, LeftChildData - 1)] // Right child is lesser
        [InlineData(LeftChildData + 1, LeftChildData - 1)] // Left child is greater, right child is lesser
        public void If_Left_Subtree_Is_Unsorted_Then_InvalidOperationException_Is_Thrown(int leftChildOfLeftChild, int rightChildOfLeftChild)
        {
            var unsortedNode = new BinaryTreeNode<int>
            {
                Data = DefaultData,
                LeftChild = new BinaryTreeNode<int>
                {
                    Data = LeftChildData,
                    LeftChild = new BinaryTreeNode<int>
                    {
                        Data = leftChildOfLeftChild
                    },
                    RightChild = new BinaryTreeNode<int>
                    {
                        Data = rightChildOfLeftChild
                    }
                }
            };

            Action badConstruction = () => new BinarySearchTree<int>(unsortedNode);

            badConstruction.Should().Throw<InvalidOperationException>("Root node is unsorted.");
        }

        [Theory]
        [InlineData(RightChildData, RightChildData + 1)] // Left child is equal
        [InlineData(RightChildData - 1, RightChildData)] // Right child is equal
        [InlineData(RightChildData, RightChildData)] // Both children are equal
        [InlineData(RightChildData + 1, RightChildData + 1)] // Left child is greater
        [InlineData(RightChildData - 1, RightChildData - 1)] // Right child is lesser
        [InlineData(RightChildData + 1, RightChildData - 1)] // Left child is greater, right child is lesser
        public void If_Right_Subtree_Is_Unsorted_Then_InvalidOperationException_Is_Thrown(int leftChildOfRightChild, int rightChildOfRightChild)
        {
            var unsortedNode = new BinaryTreeNode<int>
            {
                Data = DefaultData,
                RightChild = new BinaryTreeNode<int>
                {
                    Data = RightChildData,
                    LeftChild = new BinaryTreeNode<int>
                    {
                        Data = leftChildOfRightChild
                    },
                    RightChild = new BinaryTreeNode<int>
                    {
                        Data = rightChildOfRightChild
                    }
                }
            };

            Action badConstruction = () => new BinarySearchTree<int>(unsortedNode);

            badConstruction.Should().Throw<InvalidOperationException>("Root node is unsorted.");
        }
    }
}
