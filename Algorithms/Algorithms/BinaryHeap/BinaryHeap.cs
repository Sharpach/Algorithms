using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Algorithms
{
    public class BinaryHeap<T> : IBinaryHeap<T>
        where T : IComparable
    {
        private readonly List<T> _data;
        private readonly HeapType _type;

        public BinaryHeap(HeapType type = HeapType.MaxHeap)
        {
            _data = new List<T>();
            _type = type;
        }

        public BinaryHeap(IEnumerable<T> elems, HeapType type = HeapType.MaxHeap)
        {
            _data = elems.ToList();
            _type = type;
            BuildHeap(_data);
        }

        /// <summary>
        ///     Returns true if elements are ordered, as it's required by HeapType
        /// </summary>
        private Func<T, T, bool> Cmp
        {
            get
            {
                if (_type is HeapType.MaxHeap) return (a, b) => a.CompareTo(b) > 0;
                return (a, b) => a.CompareTo(b) <= 0;
            }
        }

        /// <summary>
        ///     Returns size of the heap
        /// </summary>
        public int Size => _data.Count;

        /// <summary>
        ///     Adds element to the heap
        /// </summary>
        public void Add(T item)
        {
            _data.Add(item);
            var current = Size - 1;
            var parent = (current - 1) / 2;

            while (current > 0 && !Cmp(_data[parent], _data[current]))
            {
                (_data[parent], _data[current]) = (_data[current], _data[parent]);
                current = parent;
                parent = (current - 1) / 2;
            }
        }

        /// <summary>
        ///     Removes and returns root of the heap
        /// </summary>
        /// <exception cref="DataException">Thrown when trying to remove from empty heap</exception>
        public T RemoveRoot()
        {
            if (Size == 0) throw new DataException("Heap is empty");
            var result = _data[0];
            _data[0] = _data[Size - 1];
            _data.RemoveAt(Size - 1);
            Heapify(_data, 0);
            return result;
        }

        /// <summary>
        ///     Builds heap from an unordered set of data
        /// </summary>
        private void BuildHeap(IList<T> data)
        {
            for (var i = Size / 2; i >= 0; --i)
                Heapify(data, i);
        }

        /// <summary>
        ///     Turns unordered array into heap, with root in data[index]
        /// </summary>
        /// <param name="data">Array representation of heap</param>
        /// <param name="index">Element, that is considered to be root</param>
        private void Heapify(IList<T> data, int index)
        {
            while (true)
            {
                var l = 2 * index + 1;
                var r = 2 * index + 2;
                var max = index;
                if (l < Size && !Cmp(data[max], data[l])) max = l;
                if (r < Size && !Cmp(data[max], data[r])) max = r;
                if (max == index) return;

                (data[max], data[index]) = (data[index], data[max]);
                index = max;
            }
        }
    }

    /// <summary>
    ///     Indicates type of heap: either its root is maximum or minimum
    /// </summary>
    public enum HeapType
    {
        MaxHeap,
        MinHeap
    }
}