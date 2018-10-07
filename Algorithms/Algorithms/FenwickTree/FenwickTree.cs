using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class FenwickTree<T> : IEnumerable<T>
    {
        private int Length => _tree.Length - 1;
        private T[] _tree;
        private readonly T[] _input;
        private readonly Func<T, T, T> _sumOperation;

        public FenwickTree(T[] input, Func<T, T, T> sumOperation)
        {
            if (input == null || sumOperation == null)
            {
                throw new ArgumentNullException();
            }

            _input = input.Clone() as T[];

            _sumOperation = sumOperation;
            ConstructTree(input);
        }

        public T GetPrefixSum(int endIndex)
        {
            if (endIndex < 0 || endIndex > Length - 1)
            {
                throw new ArgumentException();
            }

            var sum = default(T);

            var currentIndex = endIndex + 1;

            while (currentIndex > 0)
            {
                sum = _sumOperation(sum, _tree[currentIndex]);
                currentIndex = GetParentIndex(currentIndex);
            }

            return sum;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _input.Select(x => x).GetEnumerator();
        }

        private void ConstructTree(T[] input)
        {
            _tree = new T[input.Length + 1];

            for (var i = 0; i < input.Length; i++)
            {
                var j = i + 1;
                while (j < input.Length)
                {
                    _tree[j] = _sumOperation(_tree[j], input[i]);
                    j = GetNextIndex(j);
                }
            }
        }

        private int GetNextIndex(int currentIndex)
        {
            return currentIndex + (currentIndex & (-currentIndex));
        }

        private int GetParentIndex(int currentIndex)
        {
            return currentIndex - (currentIndex & (-currentIndex));
        }
    }
}
