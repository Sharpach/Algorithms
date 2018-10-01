using System;
using Algorithms.Models;
using Shouldly;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.BinarySearchTreeTests
{
    public class When_Node_Constructor_Is_Called
    {
        private const int DefaultData = 2;

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

            badConstructor.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Then_IsEmpty_Is_False()
        {
            _tree.IsEmpty.ShouldBeFalse();
        }

        [Fact]
        public void Then_Contains_Returns_True()
        {
            _tree.Contains(DefaultData).ShouldBeTrue();
        }

        [Fact]
        public void Then_Enumeration_Yields_Exactly_One_Item()
        {
            _tree.Count().ShouldBe(1);
        }

        [Fact]
        public void If_Left_Child_Of_Node_Is_Greater_Than_Root_Then_InvalidOperationException_Is_Thrown()
        {
            var unsortedNode = new BinaryTreeNode<int>
            {
                Data = DefaultData,
                LeftChild = new BinaryTreeNode<int>
                {
                    Data = DefaultData + 1
                }
            };

            Action badConstruction = () => new BinarySearchTree<int>(unsortedNode);

            badConstruction.ShouldThrow<InvalidOperationException>("Root node is unsorted.");
        }

        [Fact]
        public void If_Right_Child_Of_Node_Is_Less_Than_Root_Then_InvalidOperationException_Is_Thrown()
        {
            var unsortedNode = new BinaryTreeNode<int>
            {
                Data = DefaultData,
                RightChild = new BinaryTreeNode<int>
                {
                    Data = DefaultData - 1
                }
            };

            Action badConstruction = () => new BinarySearchTree<int>(unsortedNode);

            badConstruction.ShouldThrow<InvalidOperationException>("Root node is unsorted.");
        }
    }
}
