using System;
using System.Collections;

namespace Algorithms
{
    internal abstract class IHashTableCollection : ICollection
    {
        internal HashTable _hashtable;

        internal IHashTableCollection(HashTable hashtable)
        {
            _hashtable = hashtable;
        }

        public abstract void CopyTo(Array array, int arrayIndex);

        internal void ValidateArray(Array array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Rank != 1)
                throw new ArgumentException("Array Multi Dimension Not Supported");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
            if (array.Length - arrayIndex < _hashtable.Count)
                throw new ArgumentException("Array too small");
        }

        public abstract IEnumerator GetEnumerator();

        public virtual bool IsSynchronized { get => _hashtable.IsSynchronized; }

        public virtual Object SyncRoot { get => _hashtable.SyncRoot; }

        public virtual int Count { get => _hashtable.Count; }
    }
}
