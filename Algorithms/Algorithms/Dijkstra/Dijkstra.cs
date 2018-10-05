using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
   public class Dijkstra
    {
        /// <summary>
        ///  Calculate minimum distance
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="shortestPathTreeSet"></param>
        /// <param name="verticesCount"></param>
        /// <returns></returns>
        private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        /// <summary>
        /// Print final output
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="verticesCount"></param>
        private void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }


        /// <summary>
        /// Dijkstra Algorithm
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="source"></param>
        /// <param name="verticesCount"></param>
        public int[] DijkstraAlgo(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }
            Print(distance, verticesCount);
            return distance;
            
        }
    }
}
