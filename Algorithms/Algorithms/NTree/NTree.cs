using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.NTree
{
    public class NTree<T> where T : IEquatable<T>
    {
        public T Value { get; set; }
        public NTree<T> Parent { get; set; }
        public List<NTree<T>> Children { get; set; } = new List<NTree<T>>();

        public NTree(T value)
        {
            Value = value;
        }

        public NTree<T> Add(T value)
        {
            var child = new NTree<T>(value)
            {
                Parent = this
            };
            Children.Add(child);
            return this;
        }

        public NTree<T> Find(T value)
        {
            if (Value.Equals(value))
            {
                return this;
            }

            return Children.Select(x => x.Find(value)).FirstOrDefault(x => x != null);
        }

        public void Remove()
        {
            if (Parent == null)
            {
                throw new ArgumentException("Can't remove root");
            }

            var index = Parent.Children.FindIndex(x => x.Value.Equals(Value));
            Parent.Children.RemoveAt(index);
        }

        // returns concatenated values in prefix order
        public override string ToString()
        {
            return Value + string.Concat(Children.Select(x => x.ToString()));
        }
    }
}
