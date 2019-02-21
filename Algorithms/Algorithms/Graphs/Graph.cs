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
                var unusedVerteces = _edges.Where(edge => edge.Item1 == vertex).Select(adj => adj.Item2);

                foreach (var unusedVertex in unusedVerteces)
                {
                    queue.Enqueue(unusedVertex);
                    usedVerteces[unusedVertex] = true;
                    parents[unusedVertex] = vertex;
                }
            }

            var path = new List<int>();

            if (!usedVerteces[endVertex])
            {
                return path;
            }

            for (var v = endVertex; v != -1; v = parents[v])
            {
                path.Add(v);
            }

            path.Reverse();
            return path;
        }

        public List<int> DepthFirstSearch(int startVertex, int endVertex)
        {
            var parents = new int[_verteces.Length + 1];
            var stack = new Stack<int>();
            var usedVerteces = new bool[_verteces.Length + 1];

            stack.Push(startVertex);
            parents[startVertex] = -1;

            while (stack.Count != 0)
            {
                var vertex = stack.Pop();

                if (!usedVerteces[vertex])
                {
                    usedVerteces[vertex] = true;

                    var adjacentVerteces = _edges.Where(edge => edge.Item1 == vertex).Select(adj => adj.Item2);

                    foreach (var adjVertex in adjacentVerteces)
                    {
                        stack.Push(adjVertex);
                        parents[adjVertex] = vertex;
                    }
                }
            }

            var path = new List<int>();

            if (!usedVerteces[endVertex])
            {
                return path;
            }

            for (var v = endVertex; v != -1; v = parents[v])
            {
                path.Add(v);
            }

            path.Reverse();
            return path;
        }
    }
}