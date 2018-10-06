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
            return !IsEmpty && Contains(data, _rootNode);
        }

        public void Insert(T data)
        {
            _rootNode = Insert(data, _rootNode);
        }

        public void Remove(T data)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            if (!Contains(data))
            {
                throw new InvalidOperationException("The element does not exist.");
            }

            _rootNode = Remove(data, _rootNode);
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
            return GetEnumerator();
        }

        private static IEnumerable<T> IterateNodes(BinaryTreeNode<T> node)
        {
            yield return node.Data;

            if (node.LeftChild != null)
            {
                foreach (var i in IterateNodes(node.LeftChild))
                {
                    yield return i;
                }
            }

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

        private static BinaryTreeNode<T> Insert(T data, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return new BinaryTreeNode<T>
                {
                    Data = data,
                };
            }

            var comparisonValue = data.CompareTo(node.Data);

            if (comparisonValue == 0)
            {
                throw new ArgumentNullException("The element already exists in the tree.");
            }

            if (comparisonValue < 0)
            {
                node.LeftChild = Insert(data, node.LeftChild);
            }
            else
            {
                node.RightChild = Insert(data, node.RightChild);
            }

            return node;
        }

        private static bool Contains(T data, BinaryTreeNode<T> node)
        {
            int comparisonValue = 1;

            while (node != null && (comparisonValue = data.CompareTo(node.Data)) != 0)
            {
                if (comparisonValue < 0)
                {
                    node = node.LeftChild;
                }
                else
                {
                    node = node.RightChild;
                }
            }

            return comparisonValue == 0;
        }

        private static BinaryTreeNode<T> Remove(T data, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            var comparisonValue = data.CompareTo(node.Data);
            if (comparisonValue < 0)
            {
                node.LeftChild = Remove(data, node.LeftChild);
            }
            else if (comparisonValue > 0)
            {
                node.RightChild = Remove(data, node.RightChild);
            }
            else
            {
                if (node.LeftChild == null)
                {
                    node = node.RightChild;
                }
                else if (node.RightChild == null)
                {
                    node = node.LeftChild;
                }
                else
                {
                    var replacementValue = FindMinimum(node.RightChild);

                    node.Data = replacementValue.Data;
                    node.RightChild = Remove(replacementValue.Data, node.RightChild);
                }
            }

            return node;
        }

        private static BinaryTreeNode<T> FindMinimum(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }

            return node;
        }
    }
}