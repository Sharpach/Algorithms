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
    }
}
