using System;

namespace Algorithms 
{
    internal interface IBinaryHeap<T>
        where T : IComparable
    {
        void Add(T item);
        T RemoveRoot();
    }
}