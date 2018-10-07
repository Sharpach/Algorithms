using System;
using Algorithms.NTree;
using Xunit;

namespace Algorithms.Tests.NTreeTests
{
    public class NTreeTests
    {
        NTree<int> BuildTree()
        {
            var tree = new NTree<int>(0);
            tree.Add(1).Add(2).Add(3);
                tree.Children[0].Add(4).Add(5);
                    tree.Children[0].Children[0].Add(6);
                tree.Children[1].Add(7);
                tree.Children[2].Add(8);
                    tree.Children[2].Children[0].Add(9);
            return tree;
        }

        [Fact]
        public void ElementsAreInsertedInCorrectOrder()
        {
            var tree = BuildTree();

            var result = tree.ToString();

            Assert.Equal("0146527389", result);
        }

        [Fact]
        public void ParentReturnsCorrectNode()
        {
            var tree = BuildTree();
            var child = tree.Children[1].Children[0];
            var parent = tree.Children[1];

            var result = child.Parent;

            Assert.Equal(parent.Value, result.Value);
        }

        [Fact]
        public void ParentOfRootIsNull()
        {
            var tree = BuildTree();

            Assert.Null(tree.Parent);
        }

        [Fact]
        public void FindReturnsCorrectNode()
        {
            var tree = BuildTree();
            var expected = tree.Children[0].Children[0];

            var result = tree.Find(4);

            Assert.Same(expected, result);
        }

        [Fact]
        public void FindReturnsNullWhenValueDoesNotExist()
        {
            var tree = BuildTree();

            var result = tree.Find(-14);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(1, "027389")]
        [InlineData(2, "01465389")]
        [InlineData(9, "014652738")]
        public void RemoveWorks(int node, string expected)
        {
            var tree = BuildTree();
            var nodeToRemove = tree.Find(node);

            nodeToRemove.Remove();

            Assert.Equal(expected, tree.ToString());
        }

        [Fact]
        public void ThrowsExceptionWhenRemovingRoot()
        {
            var tree = BuildTree();
            Action removeRoot = () => tree.Remove();

            Assert.Throws<ArgumentException>(removeRoot);
        }
    }
}
