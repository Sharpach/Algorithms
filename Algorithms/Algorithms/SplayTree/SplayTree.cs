using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.SplayTree
{
    /// <summary>
    /// A generic implementation of the Splay Tree algorithm.
    /// For more information and examples for this algorithm, 
    /// see https://www.geeksforgeeks.org/splay-tree-set-1-insert/
    /// </summary>
    /// <typeparam name="T">A type that implements IComparable</typeparam>
    public class SplayTree<T> where T : IComparable
    {
        /// <summary>
        /// Create a Tree from the given list of values.
        /// </summary>
        /// <param name="list">The list of values to insert into the tree</param>
        /// <param name="parent">The parent node</param>
        /// <returns>The newly created Node</returns>
        public static Node BuildTree(IReadOnlyCollection<T> list, Node parent = null)
        {
            if (list.Count == 0) return null;

            var node = new Node
            {
                Value = list.First()
            };

            var leftList = list.Skip(1).Where(w => w.CompareTo(node.Value) < 0).ToList();
            var rightList = list.Skip(1).Where(w => w.CompareTo(node.Value) > 0).ToList();

            node.Left = BuildTree(leftList, node);
            node.Right = BuildTree(rightList, node);

            return node;
        }

        /// <summary>
        /// Search the given tree for the provided search value.
        /// </summary>
        /// <param name="root">The root Node of the tree to search</param>
        /// <param name="searchValue">The value for which to search</param>
        /// <returns>If present, the Node containing the search value, otherwise, the last Node searched</returns>
        public static Node Splay(Node root, T searchValue)
        {
            if (root == null || root.Value.CompareTo(searchValue) == 0)
            {
                return root;
            }

            return root.Value.CompareTo(searchValue) > 0
                ? TraverseLeftSubTree(root, searchValue)
                : TraverseRightSubTree(root, searchValue);
        }

        #region Private Methods

        /// <summary>
        /// Traverse through the right sub-tree of the given tree, looking for the search value.
        /// </summary>
        /// <param name="root">The root Node of the sub-tree to search</param>
        /// <param name="searchValue">The value for which to search</param>
        /// <returns>If no right Node exists, return the root. Otherwise, the root of the possibly rotated sub-tree</returns>
        private static Node TraverseRightSubTree(Node root, T searchValue)
        {
            if (root.Right == null) return root;

            if (root.Right.Value.CompareTo(searchValue) > 0)
            {
                root.Right.Left = Splay(root.Right.Left, searchValue);

                if (root.Right.Left != null)
                {
                    root.Right = RightRotate(root.Right);
                }
            }
            else if (root.Right.Value.CompareTo(searchValue) < 0)
            {
                root.Right.Right = Splay(root.Right.Right, searchValue);
                root = LeftRotate(root);
            }

            return root.Right == null ? root : LeftRotate(root);
        }

        /// <summary>
        /// Traverse through the left sub-tree of the given tree, looking for the search value.
        /// </summary>
        /// <param name="root">The root Node of the sub-tree to search</param>
        /// <param name="searchValue">The value for which to search</param>
        /// <returns>If no left Node exists, return the root. Otherwise, the root of the possibly rotated sub-tree</returns>
        private static Node TraverseLeftSubTree(Node root, T searchValue)
        {
            if (root.Left == null) return root;

            if (root.Left.Value.CompareTo(searchValue) > 0)
            {
                root.Left.Left = Splay(root.Left.Left, searchValue);
                root = RightRotate(root);
            }
            else if (root.Left.Value.CompareTo(searchValue) < 0)
            {
                root.Left.Right = Splay(root.Left.Right, searchValue);

                if (root.Left.Right != null)
                {
                    root.Left = LeftRotate(root.Left);
                }
            }

            return root.Left == null ? root : RightRotate(root);
        }

        /// <summary>
        /// Left rotate sub-tree rooted with x.
        /// </summary>
        /// <param name="x">Node around which to rotate</param>
        /// <returns>The new root of the tree</returns>
        private static Node LeftRotate(Node x)
        {
            var y = x.Right;
            x.Right = y.Left;
            y.Left = x;
            return y;
        }

        /// <summary>
        /// Right rotate sub-tree rooted with x.
        /// </summary>
        /// <param name="x">Node around which to rotate</param>
        /// <returns>The new root of the tree</returns>
        private static Node RightRotate(Node x)
        {
            var y = x.Left;
            x.Left = y.Right;
            y.Right = x;
            return y;
        }

        #endregion

        #region Classes

        public class Node
        {
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        #endregion
    }
}
