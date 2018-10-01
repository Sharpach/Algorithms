namespace Algorithms.Models
{
    /// <summary>
    /// A node in a binar tree.
    /// </summary>
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public bool IsLeafNode => LeftChild == null && RightChild == null;
    }
}