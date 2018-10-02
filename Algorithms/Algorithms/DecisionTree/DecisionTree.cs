namespace Algorithms.DecisionTree
{
    /// <summary>Decision tree</summary>
    /// <typeparam name="TIn">Shared state, carrying through all decisions</typeparam>
    /// <typeparam name="TOut">Decision type</typeparam>
    /// <remarks>Kind of specialized N-ary decision tree with mutable state, carrying along all decisions</remarks>
    public class DecisionTree<TIn, TOut>
    {
        private readonly IDecision<TIn, TOut> _root;

        public DecisionTree(IDecision<TIn, TOut> root)
        {
            _root = root;
        }

        public TOut Solve() => SolveInternal(_root);

        private TOut SolveInternal(IDecision<TIn, TOut> currentNode) 
            => currentNode.Decider(currentNode, currentNode.Value)
                          .Match(x => SolveInternal(x),
                                 y => y);
    }
}