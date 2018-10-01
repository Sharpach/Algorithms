using Algorithms.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(T data)
        {
            throw new NotImplementedException();
        }

        public BinarySearchTree(BinaryTreeNode<T> root)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty { get; }

        public bool Contains(T data)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Insert(T data)
        {
            throw new NotImplementedException();
        }

        public void Remove(T data)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}