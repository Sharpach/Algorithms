using Algorithms.AStar;
using Algorithms.Tests.AStarTests.TestField;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.AStarTests
{
    public class AStarTests
    {
        [Fact]
        void AStar_RunOnStable3On3Filed_ReturnCorrectPath()
        {
            /* The way
             * |F.W|
             * |W..|
             * |WWF|
             */

            var matrix = new MatrixField();
            var search = new AStarSearch(matrix.Start, matrix.Goal);
            var expectedPath = "s.W\nW..\nWWg\n";

            search.Run();
            var foundPath = matrix.Print(search.GetPath());

            foundPath.Should().Be(expectedPath);
        }
    }
}
