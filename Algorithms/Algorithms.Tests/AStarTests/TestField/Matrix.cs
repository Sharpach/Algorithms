using System;
using System.Collections.Generic;
using Algorithms.AStar;

namespace Algorithms.Tests.AStarTests.TestField
{
    public class MatrixField
    {
        public MatrixNode[][] Matrix;

        public int Width { get { return Matrix.Length; } }
        public int Height { get { return Matrix[0].Length; } }

        public MatrixNode Start;
        public MatrixNode Goal;

        /// <example>
        /// |S W|
        /// |W  |
        /// |W F|
        /// </example>
        public MatrixField()
        {
            Start = new MatrixNode(this, 0, 0, false);
            Goal = new MatrixNode(this, 2, 2, false);

            Matrix = new MatrixNode[3][];
            for (var i = 0; i < 3; i++)
                Matrix[i] = new MatrixNode[3];

            Matrix[Start.X][Start.Y] = Start;
            Matrix[Goal.X][Goal.Y] = Goal;

            Matrix[0][1] = new MatrixNode(this, 0, 2, false);
            Matrix[0][2] = new MatrixNode(this, 0, 2, true);

            Matrix[1][0] = new MatrixNode(this, 1, 0, true);
            Matrix[1][1] = new MatrixNode(this, 1, 0, false);
            Matrix[1][2] = new MatrixNode(this, 1, 0, false);

            Matrix[2][0] = new MatrixNode(this, 2, 0, true);
            Matrix[2][1] = new MatrixNode(this, 2, 1, true);
        }

        public string Print(IEnumerable<IWayNode> path)
        {
            var output = "";
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    output += Matrix[i][j].Print(Start, Goal, path);
                }
                output += "\n";
            }
            return output;
        }
    }
}
