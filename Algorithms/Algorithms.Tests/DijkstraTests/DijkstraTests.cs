using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algorithms.Tests
{
   public class DijkstraTests
    {

        [Fact]
        public void TraverseDFS()
        {
           
            Dijkstra dijkstra = new Dijkstra();
            int[,] inputGraph =  {
                            { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                            { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                            { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                            { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                            { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                            { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                            { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                            { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                            { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                            };

            int[] output = { 0, 6, 15, 20, 22, 12, 10, 9, 14 };

           var result= dijkstra.DijkstraAlgo(inputGraph, 0, 9);
            for(int i=0; i< output.Length; i += 1)
            {
                Assert.Equal(output[i], result[i]);
            }
           
        }
    }
}
