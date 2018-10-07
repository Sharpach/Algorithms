using System;
using System.Collections.Generic;
using Algorithms.AStar;

namespace Algorithms.Tests.AStarTests.TestField
{
    public class MatrixNode : IWayNode
    {
        private MatrixField Matrix;

        private bool isOpenList = false;
        private bool isClosedList = false;
        
        private static int[] childXPos = new int[] { 0, -1, 1, 0, };
        private static readonly int[] childYPos = new int[] { -1, 0, 0, 1, };

        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsWall { get; set; }
        
        public MatrixNode(MatrixField matrix, int x, int y, bool isWall)
        {
            Matrix = matrix;
            X = x;
            Y = y;
            IsWall = isWall;
        }

        public IWayNode Parent { get; set; }

        public IEnumerable<IWayNode> Children
        {
            get
            {
                var children = new List<MatrixNode>();

                for (int i = 0; i < childXPos.Length; i++)
                {
                    // skip any nodes out of bounds.
                    if (X + childXPos[i] >= Matrix.Width || Y + childYPos[i] >= Matrix.Height)
                        continue;
                    if (X + childXPos[i] < 0 || Y + childYPos[i] < 0)
                        continue;

                    children.Add(Matrix.Matrix[X + childXPos[i]][Y + childYPos[i]]);
                }

                return children;
            }
        }

        public int TotalCost { get { return MovementCost + EstimatedCost; } }

        public int MovementCost { get; private set; }

        public int EstimatedCost { get; private set; }

        public bool IsOpenNodes(IEnumerable<IWayNode> openNodes)
        {
            return isOpenList;
        }

        public void SetOpenNode(bool value)
        {
            isOpenList = value;
        }

        public bool IsClosedNodes(IEnumerable<IWayNode> closedNodes)
        {
            return IsWall || isClosedList;
        }

        public void SetClosedNode(bool value)
        {
            isClosedList = value;
        }

        public void SetMovementCost(IWayNode parent)
        {
            MovementCost = parent.MovementCost + 1;
        }

        public void SetEstimatedCost(IWayNode goal)
        {
            var goalNode = (MatrixNode)goal;
            EstimatedCost = Math.Abs(X - goalNode.X) + Math.Abs(Y - goalNode.Y);
        }

        public bool IsGoal(IWayNode goal)
        {
            return IsEqual((MatrixNode)goal);
        }

        public bool IsEqual(MatrixNode node)
        {
            return (this == node) || (this.X == node.X && this.Y == node.Y);
        }

        public string Print(MatrixNode start, MatrixNode goal, IEnumerable<IWayNode> path)
        {
            if (IsWall)
            {
                return "W";
            }
            else if (IsEqual(start))
            {
                return "s";
            }
            else if (IsEqual(goal))
            {
                return "g";
            }
            else if (IsInPath(path))
            {
                return ".";
            }
            else
            {
                return " ";
            }
        }

        private bool IsInPath(IEnumerable<IWayNode> path)
        {
            foreach (var node in path)
            {
                if (IsEqual((MatrixNode)node))
                    return true;
            }
            return false;
        }
    }
}
