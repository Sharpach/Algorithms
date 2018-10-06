namespace Algorithms.BinarySearchTree
{
    /// <summary>
    /// A node in a binary tree.
    /// </summary>
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public bool IsLeafNode => LeftChild == null && RightChild == null;
    }
}