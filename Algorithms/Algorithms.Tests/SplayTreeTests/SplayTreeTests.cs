using Algorithms.SplayTree;
using Xunit;

namespace Algorithms.Tests.SplayTreeTests
{
    public class SplayTreeTests
    {
        private readonly int[] _treeValues = {50, 20, 80, 10, 30, 70, 90};
        
        [Fact]
        public void GivenNumberList_ThenCorrectTreeBuild()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Assert
            Assert.Equal(50, tree.Value);
            Assert.Equal(20, tree.Left.Value);
            Assert.Equal(10, tree.Left.Left.Value);
            Assert.Equal(30, tree.Left.Right.Value);
            Assert.Equal(10, tree.Left.Left.Value);
            Assert.Equal(80, tree.Right.Value);
            Assert.Equal(70, tree.Right.Left.Value);
            Assert.Equal(90, tree.Right.Right.Value);
        }

        [Fact]
        public void GivenSearch_WhenValueIsAtRoot_ThenRootIsUnchanged()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 50);

            // Assert
            Assert.Equal(50, tree.Value);
        }

        [Fact]
        public void GivenSearch_WhenValueIsLeftChildOfRoot_ThenTreeRotated()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 20);

            // Assert
            Assert.Equal(20, tree.Value);
            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(50, tree.Right.Value);
        }

        [Fact]
        public void GivenSearch_WhenValueIsRightChildOfRoot_ThenTreeRotated()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 80);

            // Assert
            Assert.Equal(80, tree.Value);
            Assert.Equal(50, tree.Left.Value);
            Assert.Equal(90, tree.Right.Value);
        }

        [Fact]
        public void GivenSearch_WhenZigZig_ThenTreeRotated()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 10);

            // Assert
            Assert.Equal(10, tree.Value);
        }

        [Fact]
        public void GivenSearch_WhenZagZag_ThenTreeRotated()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 90);

            // Assert
            Assert.Equal(90, tree.Value);
        }

        [Fact]
        public void GivenSearch_WhenZigZag_ThenTreeRotated()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 20);

            // Assert
            Assert.Equal(20, tree.Value);
        }

        [Fact]
        public void GivenSearch_WhenZagZig_ThenTreeRotated()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 70);

            // Assert
            Assert.Equal(70, tree.Value);
        }

        [Fact]
        public void GivenSearch_WhenValueNotInTree_ThenClosestNodeReturned()
        {
            // Arrange
            var tree = SplayTree<int>.BuildTree(_treeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 100);

            // Assert
            Assert.Equal(90, tree.Value);
        }

        [Fact]
        public void GivenSearch_WhenValueInTree_ThenNodeReturned()
        {
            // Arrange
            var nodeValues = new[] {100, 50, 40, 30, 20, 200};
            var tree = SplayTree<int>.BuildTree(nodeValues);

            // Act
            tree = SplayTree<int>.Splay(tree, 20);

            // Assert
            Assert.Equal(20, tree.Value);
        }
    }
}
