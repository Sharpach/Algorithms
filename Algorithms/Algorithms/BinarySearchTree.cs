using Algorithms.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class BinarySearchTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> _rootNode;

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(T data)
        {
            _rootNode = new BinaryTreeNode<T>
            {
                Data = data
            };
        }

        public BinarySearchTree(BinaryTreeNode<T> rootNode)
        {
            if (rootNode == null)
            {
                throw new ArgumentNullException(nameof(rootNode));
            }

            if (!IsSorted(rootNode))
            {
                throw new InvalidOperationException("Root node is unsorted.");
            }

            _rootNode = rootNode;
        }

        public bool IsEmpty => _rootNode == null;

        public bool Contains(T data)
        {
            throw new NotImplementedException();
        }

        public void Insert(T data)
        {
            if (_rootNode == null)
            {
                _rootNode = new BinaryTreeNode<T>
                {
                    Data = data
                };
                return;
            }

            throw new NotImplementedException();
        }

        public void Remove(T data)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_rootNode == null)
            {
                return Enumerable.Empty<T>().GetEnumerator();
            }

            return IterateNodes(_rootNode).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private static IEnumerable<T> IterateNodes(BinaryTreeNode<T> node)
        {
            if (node.LeftChild != null)
            {
                foreach (var i in IterateNodes(node.LeftChild))
                {
                    yield return i;
                }
            }

            yield return node.Data;

            if (node.RightChild != null)
            {
                foreach (var i in IterateNodes(node.RightChild))
                {
                    yield return i;
                }
            }
        }

        private static bool IsSorted(BinaryTreeNode<T> node)
        {
            if (node.IsLeafNode)
            {
                return true;
            }

            var isSorted = true;

            if (node.LeftChild != null)
            {
                isSorted &= node.LeftChild.Data.CompareTo(node.Data) < 0 &&
                       IsSorted(node.LeftChild);
            }

            if (node.RightChild != null)
            {
                isSorted &= node.RightChild.Data.CompareTo(node.Data) > 0 &&
                            IsSorted(node.RightChild);
            }

            return isSorted;
        }

        private static void Insert(T data, BinaryTreeNode<T> node)
        {
            var comparisonValue = data.CompareTo(node.Data);

            if (comparisonValue == 0)
            {
                throw new ArgumentNullException("The element already exists in the tree.");
            }

            if (comparisonValue < 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new BinaryTreeNode<T>
                    {
                        Data = data
                    };
                    return;
                }

                Insert(data, node.LeftChild);
                return;
            }

            if (comparisonValue > 0)
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new BinaryTreeNode<T>
                    {
                        Data = data
                    };
                    return;
                }

                Insert(data, node.RightChild);
                return;
            }
        }
    }
}