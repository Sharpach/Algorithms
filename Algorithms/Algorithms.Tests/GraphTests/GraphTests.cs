using Algorithms.Graphs;
using Xunit;

namespace Algorithms.Tests.GraphTests
{
    public class GraphTests
    {
        public Graph BuildGraph()
        {
            var verteces = new[]
            {
                1,
                2, 3, 4,
                5, 6, 7, 8,
                9, 10
            };

            var edges = new[]
            {
                (1, 2), (1, 3), (1, 4),
                (2, 5),
                (3, 6), (3, 7),
                (4, 8),
                (5, 9),
                (6, 10)
            };

            return new Graph(verteces, edges);
        }

        [Fact]
        public void PathLengthIsCorrect()
        {
            var graph = BuildGraph();

            var resultBFS = graph.BreadthFirstSearch(1, 9);
            var resultDFS = graph.DepthFirstSearch(1, 9);

            Assert.Equal(4, resultBFS.Count);
            Assert.Equal(4, resultDFS.Count);
        }

        [Fact]
        public void PathIsCorrect()
        {
            var graph = BuildGraph();

            var resultBFS = graph.BreadthFirstSearch(3, 10);
            var resultDFS = graph.DepthFirstSearch(3, 10);

            Assert.Equal(3, resultBFS[0]);
            Assert.Equal(6, resultBFS[1]);
            Assert.Equal(10, resultBFS[2]);

            Assert.Equal(3, resultDFS[0]);
            Assert.Equal(6, resultDFS[1]);
            Assert.Equal(10, resultDFS[2]);
        }

        [Fact]
        public void PathIsEmpty()
        {
            var graph = BuildGraph();

            var resultBFS = graph.BreadthFirstSearch(3, 8);
            var resultDFS = graph.DepthFirstSearch(3, 8);

            Assert.Empty(resultBFS);
            Assert.Empty(resultDFS);
        }
    }
}
