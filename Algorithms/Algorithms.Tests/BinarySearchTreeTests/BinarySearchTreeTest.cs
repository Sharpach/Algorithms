using Xunit;

namespace Algorithms.Tests.BinarySearchTreeTests
{
    public abstract class BinarySearchTreeTest
    {
        protected BinarySearchTree<int> Tree { get; private set; }

        public BinarySearchTreeTest()
        {
            Tree = new BinarySearchTree<int>();
        }
    }
}