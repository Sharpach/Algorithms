using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class Graph
    {
        private readonly int[] _verteces;
        private readonly ValueTuple<int, int>[] _edges;

        public Graph(int[] verteces, (int, int)[] edges)
        {
            _verteces = verteces;
            _edges = edges;
        }

        public List<int> BreadthFirstSearch(int startVertex, int endVertex)
        {
            var queue = new Queue<int>();
            var parents = new int[_verteces.Length + 1];
            var usedVerteces = new bool[_verteces.Length + 1];

            queue.Enqueue(startVertex);
            usedVerteces[startVertex] = true;
            parents[startVertex] = -1;

            while (queue.Count != 0)
            {
                var vertex = queue.Dequeue();
                var unusedVerteces = _edges.Where(edge => edge.Item1 == vertex).Select(unused => unused.Item2);

                foreach (var unusedVertex in unusedVerteces)
                {
                    queue.Enqueue(unusedVertex);
                    usedVerteces[unusedVertex] = true;
                    parents[unusedVertex] = vertex;
                }
            }

            if (!usedVerteces[endVertex])
            {
                return null;
            }

            var path = new List<int>();

            for (var v = endVertex; v != -1; v = parents[v])
            {
                path.Add(v);
            }

            path.Reverse();

            return path;
        }
    }
}