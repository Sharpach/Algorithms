using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class GenericEqualityComparer<TItem, TKey> : EqualityComparer<TItem>
    {
        private readonly Func<TItem, TKey> _getKey;
        private readonly EqualityComparer<TKey> _keyComparer;

        public GenericEqualityComparer(Func<TItem, TKey> getKey)
        {
            _getKey = getKey;
            _keyComparer = EqualityComparer<TKey>.Default;
        }

        public override bool Equals(TItem x, TItem y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return _keyComparer.Equals(_getKey(x), _getKey(y));
        }

        public override int GetHashCode(TItem obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return _keyComparer.GetHashCode(_getKey(obj));
        }
    }
}