using System.Collections.Generic;

namespace Algorithms.AStar
{
    internal static class Extensions
    {
        internal static bool IsEmpty<TKey, TValue>(this SortedList<TKey, TValue> sortedList)
        {
            return sortedList.Count == 0;
        }

        internal static void Add(this SortedList<int, IWayNode> sortedList, IWayNode wayNode)
        {
            sortedList.Add(wayNode.TotalCost, wayNode);
        }

        internal static IWayNode Pop(this SortedList<int, IWayNode> sortedList)
        {
            var top = sortedList.Values[0];
            sortedList.RemoveAt(0);
            return top;
        }
    }
}
