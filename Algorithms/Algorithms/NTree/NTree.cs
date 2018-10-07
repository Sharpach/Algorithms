using System.Collections.Generic;
using System.Linq;

namespace Algorithms.NTree
{
    public class NTree<T>
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
        
        // returns concatenated values in prefix order
        public override string ToString()
        {
            return Value + string.Concat(Children.Select(x => x.ToString()));
        }
    }
}
