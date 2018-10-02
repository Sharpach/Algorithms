using System;

namespace Algorithms.BinaryHeap
{
    internal interface IBinaryHeap<T>
        where T : IComparable
    {
        void Add(T item);
        T RemoveRoot();
    }
}