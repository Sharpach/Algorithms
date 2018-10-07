using System;
using System.Collections;

namespace Algorithms
{
    internal class ValueCollection : IHashTableCollection
    {
        internal ValueCollection(HashTable hashtable) : base(hashtable) { }

        public override void CopyTo(Array array, int arrayIndex)
        {
            ValidateArray(array, arrayIndex);
            _hashtable.CopyValues(array, arrayIndex);
        }

        public override IEnumerator GetEnumerator() => new HashTableEnumerator(_hashtable, HashTableEnumerator.ObjectReturnType.Values);
    }
}
