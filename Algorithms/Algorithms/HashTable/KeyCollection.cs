using System;
using System.Collections;

namespace Algorithms
{
    internal class KeyCollection : IHashTableCollection
    {
        internal KeyCollection(HashTable hashtable) : base(hashtable) { }

        public override void CopyTo(Array array, int arrayIndex)
        {
            ValidateArray(array, arrayIndex);
            _hashtable.CopyKeys(array, arrayIndex);
        }

        public override IEnumerator GetEnumerator() => new HashTableEnumerator(_hashtable, HashTableEnumerator.ObjectReturnType.Keys);
    }
}
