using System;
using System.Collections;

namespace Algorithms
{
    internal class HashTableEnumerator : IDictionaryEnumerator
    {
        private HashTable _hashtable;
        private int _index;
        private bool _current;
        private object _currentKey, _currentValue;
        private ObjectReturnType _objectReturnType;

        internal enum ObjectReturnType
        {
            Keys = 1,
            Values,
            DictionaryEntry
        };

        internal HashTableEnumerator(HashTable hashtable, ObjectReturnType returnType)
        {
            _hashtable = hashtable;
            _index = hashtable.Data?.Length ?? -1;
            _objectReturnType = returnType;
        }

        public object Key
        {
            get
            {
                if (_current == false) throw new InvalidOperationException();
                return _currentKey;
            }
        }

        public object Value
        {
            get
            {
                if (_current == false) throw new InvalidOperationException();
                return _currentValue;
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                if (_current == false) throw new InvalidOperationException();
                return new DictionaryEntry(_currentKey, _currentValue);
            }
        }
        public object Current
        {
            get
            {
                if (_current == false) throw new InvalidOperationException();

                if (_objectReturnType == ObjectReturnType.Keys)
                    return _currentKey;
                else if (_objectReturnType == ObjectReturnType.Values)
                    return _currentValue;
                else
                    return new DictionaryEntry(_currentKey, _currentValue);
            }
        }

        public bool MoveNext()
        {
            while (_index > 0)
            {
                _index--;
                if (_hashtable.Data[_index].key != null && _hashtable.Data[_index].hashKey >= 0)
                {
                    _currentKey = _hashtable.Data[_index].key;
                    _currentValue = _hashtable.Data[_index].val;
                    _current = true;
                    return true;
                }
            }
            _current = false;
            return false;
        }

        public void Reset()
        {
            _current = false;
            _index = _hashtable.Data.Length;
            _currentKey = null;
            _currentValue = null;
        }
    }
}
