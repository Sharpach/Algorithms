using System.Collections.Generic;

namespace Algorithms.AStar
{
    public enum State
    {
        Searching,
        GoalFound,
        Failed
    }

    internal class DuplicateComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x <= y ? -1 : 1;
        }
    }

    public class AStarSearch
    {
        private readonly SortedList<int, IWayNode> _openNodes;
        private readonly SortedList<int, IWayNode> _closeNodes;

        public IEnumerable<IWayNode> OpenNodes => _openNodes.Values;
        public IEnumerable<IWayNode> ClosedNodes => _closeNodes.Values;

        public IWayNode Current { get; private set; }
        public IWayNode Goal { get; private set; }

        public int Steps { get; private set; }

        public AStarSearch(IWayNode start, IWayNode goal)
        {
            var duplicateComparer = new DuplicateComparer();
            _openNodes = new SortedList<int, IWayNode>(duplicateComparer);
            _closeNodes = new SortedList<int, IWayNode>(duplicateComparer);

            Reset(start, goal);
        }

        public void Reset(IWayNode start, IWayNode goal)
        {
            _openNodes.Clear();
            _closeNodes.Clear();

            Current = start;
            Goal = goal;

            _openNodes.Add(Current);
            Current.SetOpenNode(true);
        }

        public State Run()
        {
            while (true)
            {
                var state = NextStep();
                if (state != State.Searching)
                    return state;
            }
        }

        private State NextStep()
        {
            Steps++;
            while (true)
            {
                if (_openNodes.IsEmpty())
                {
                    return State.Failed;
                }

                Current = _openNodes.Pop();
                if (Current.IsClosedNodes(ClosedNodes))
                {
                    continue;
                }

                break;
            }

            Current.SetOpenNode(false);
            _closeNodes.Add(Current);
            Current.SetClosedNode(true);

            if (Current.IsGoal(Goal))
            {
                return State.GoalFound;
            }

            foreach (var child in Current.Children)
            {
                if (child.IsOpenNodes(OpenNodes) || child.IsClosedNodes(ClosedNodes))
                {
                    continue;
                }

                child.Parent = Current;
                child.SetMovementCost(Current);
                child.SetEstimatedCost(Goal);

                _openNodes.Add(child);
                child.SetOpenNode(true);
            }

            return State.Searching;
        }

        public IEnumerable<IWayNode> GetPath()
        {
            if (Current != null)
            {
                var next = Current;
                var path = new List<IWayNode>();
                while (next != null)
                {
                    path.Add(next);
                    next = next.Parent;
                }
                path.Reverse();
                return path.ToArray();
            }
            return null;
        }
    }
}
