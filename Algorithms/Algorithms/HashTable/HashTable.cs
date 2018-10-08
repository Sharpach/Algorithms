using System;
using System.Collections;

namespace Algorithms
{
    public class HashTable : IDictionary
    {
        public struct Entry
        {
            public int hashKey;
            public object key;
            public object val;
            public int collision;
        }

        internal Entry[] Data;
        private const int _maxArraySize = 2146435069;
        private const int _resizeMultiplier = 2;
        private const int _initArraySize = 3;
        private object _syncRoot;
        private ICollection _keyCollection, _valCollection;

        public HashTable() { }

        public HashTable(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException("capacity", "Capacity must be non negative");
            Init(capacity);
        }

        /// <summary>
        /// Division hash function
        /// </summary>
        /// <param name="hashKey">Hash key of current item</param>
        private int HashIndex(uint hashKey) => (int)(hashKey % (uint)Data.Length);

        /// <summary>
        /// Double hashing function
        /// </summary>
        /// <param name="hashKey">Hash key of current item</param>
        private uint HashIndex2(uint hashKey) => (1 + (hashKey % ((uint)Data.Length - 2)));

        private void Init(int capacity)
        {
            var size = NextPrime(capacity);
            Data = new Entry[size];
            Count = 0;
            for (int i = 0; i < Data.Length; i++)
                Data[i].hashKey = -1;
        }

        private void Resize()
        {
            var newSize = Data.Length * _resizeMultiplier;
            if ((uint)newSize > _maxArraySize)
                newSize = _maxArraySize;

            Resize(newSize);
        }

        private void Resize(int newSize)
        {
            var _oldData = new Entry[Data.Length];
            Array.Copy(Data, 0, _oldData, 0, Data.Length);
            Init(newSize);

            for (int i = 0; i < _oldData.Length; i++)
            {
                if (_oldData[i].hashKey >= 0)
                {
                    _oldData[i].collision = 0;
                    Put(_oldData[i], true);
                }
            }
        }

        public void Add(object key, object value)
        {
            Insert(key, value, true);
        }

        public void Remove(object key)
        {
            var index = FindIndex(key);
            if (index >= 0)
            {
                Data[index].hashKey = -1;
                Data[index].key = null;
                Data[index].val = null;
                Count--;
            }
        }

        public object this[object key]
        {
            get
            {
                var index = FindIndex(key);
                if (index >= 0)
                    return Data[index].val;
                else
                    return null;
            }
            set => Insert(key, value, false);
        }

        private void Insert(object key, object value, bool add)
        {
            if (key == null) throw new ArgumentNullException("key");
            Put(new Entry { key = key, val = value, hashKey = (int)(uint)key.GetHashCode() }, add);
        }

        /// <summary>
        /// Inserts or updates hash item
        /// </summary>
        /// <param name="item">Hash item to insert or update</param>
        /// <param name="add">Flag to specify if this is an add or update</param>
        private void Put(Entry item, bool add)
        {
            if (Data == null)
                Init(_initArraySize);
            else if (Count == Data.Length)
                Resize();

            var index = FindIndex(item.key);

            if (add)
            {
                if (index < 0)
                {
                    index = HashIndex((uint)item.hashKey);
                    while (!IsVacent(index))
                    {
                        index = NextIndex(index, (uint)item.hashKey);
                        item.collision++;
                    }
                    ++Count;
                }
                else
                {
                    throw new ArgumentException("Error key exists!");
                }
            }
            Data[index] = item;
        }

        private int FindIndex(object key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            if (Data != null)
            {
                var hashKey = (uint)key.GetHashCode();
                var count = 0;
                var i = HashIndex(hashKey);
                while ((count < Data.Length) && (!IsVacent(i)) && (Data[i].hashKey != hashKey))
                {
                    ++count;
                    i = NextIndex(i, hashKey);
                }
                return (Data[i].hashKey == (int)hashKey ? i : -1);
            }
            return -1;
        }

        private bool IsVacent(int index) => (Data[index].hashKey < 0);

        private int NextIndex(int index, uint hashKey)
        {
            return (int)((index + HashIndex2(hashKey)) % (uint)Data.Length);
        }

        /// <summary>
        /// Return the next prime number if input is not already one
        /// </summary>
        /// <param name="num">seed</param>
        private int NextPrime(int num)
        {
            do
            {
                if (CheckPrime(num))
                    return num;
            } while (num++ < _maxArraySize);
            return num;
        }

        /// <summary>
        /// Checks if number is a prime number
        /// </summary>
        /// <param name="num">input</param>
        private bool CheckPrime(int num)
        {
            if ((num & 1) != 0)
            {
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            }
            return (num == 2);
        }

        public ICollection Keys
        {
            get
            {
                if (_keyCollection == null) _keyCollection = new KeyCollection(this);
                return _keyCollection;
            }
        }

        public ICollection Values
        {
            get
            {
                if (_valCollection == null) _valCollection = new ValueCollection(this);
                return _valCollection;
            }
        }

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public bool IsSynchronized => false;

        public int Count { get; private set; }

        public object SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                    System.Threading.Interlocked.CompareExchange<object>(ref _syncRoot, new Object(), null);
                return _syncRoot;
            }
        }

        public void Clear()
        {
            if (Count > 0)
            {
                for (int i = 0; i < Data.Length; i++)
                {
                    Data[i].hashKey = -1;
                    Data[i].key = null;
                    Data[i].val = null;
                }
            }
            Count = 0;
        }

        public bool Contains(object key) => ContainsKey(key);

        public bool ContainsKey(object key) => (FindIndex(key) >= 0);

        public bool ContainsValue(object value)
        {
            if (value == null)
            {
                foreach (var item in Data)
                {
                    if (item.key != null && item.val == null)
                        return true;
                }
            }
            else
            {
                foreach (var item in Data)
                {
                    if (item.val != null && item.val.Equals(value))
                        return true;
                }
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Rank != 1)
                throw new ArgumentException("Array Multi Dimension Not Supported");
            if (index < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
            if (array.Length - index < Count)
                throw new ArgumentException("Array too small");

            foreach (var entry in Data)
            {
                if (entry.key != null && entry.hashKey >= 0)
                {
                    var dic = new DictionaryEntry(entry.key, entry.val);
                    array.SetValue(dic, index++);
                }
            }
        }

        internal void CopyKeys(Array array, int arrayIndex)
        {
            foreach (var entry in Data)
            {
                if (entry.key != null && entry.hashKey >= 0)
                {
                    array.SetValue(entry.key, arrayIndex++);
                }
            }
        }

        internal void CopyValues(Array array, int arrayIndex)
        {
            foreach (var entry in Data)
            {
                if (entry.key != null && entry.hashKey >= 0)
                {
                    array.SetValue(entry.val, arrayIndex++);
                }
            }
        }

        public IDictionaryEnumerator GetEnumerator() => new HashTableEnumerator(this, HashTableEnumerator.ObjectReturnType.DictionaryEntry);

        IEnumerator IEnumerable.GetEnumerator() => new HashTableEnumerator(this, HashTableEnumerator.ObjectReturnType.DictionaryEntry);
    }
}
