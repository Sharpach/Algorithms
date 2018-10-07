using System.Collections.Generic;

namespace Algorithms.AStar
{
    public interface IWayNode
    {
        int TotalCost { get; }
        int MovementCost { get; }
        int EstimatedCost { get; }

        IWayNode Parent { get; set; }
        IEnumerable<IWayNode> Children { get; }

        bool IsGoal(IWayNode goal);
        bool IsClosedNodes(IEnumerable<IWayNode> closedNodes);
        bool IsOpenNodes(IEnumerable<IWayNode> openNodes);

        void SetOpenNode(bool value);
        void SetClosedNode(bool value);
        void SetMovementCost(IWayNode parent);
        void SetEstimatedCost(IWayNode goal);
    }
}
