using System;

namespace Atlas.KarmaWorker.Utils.Decision
{
    /// <summary>
    /// Decision tree
    /// </summary>
    /// <typeparam name="TIn">Shared object, common for all decisions</typeparam>
    /// <typeparam name="TOut">Decision type</typeparam>
    public class DecisionTree<TIn, TOut>
    {
        private IDecision<TIn, TOut> root;

        public DecisionTree(IDecision<TIn, TOut> root)
        {
            this.root = root;
        }

        public TOut Solve()
        {
            if (root == null)
                throw new InvalidOperationException();

            TOut result = default;
            while (root != null)
            {
                root.Mutator(root, root.Value);
                if (root.Key == 0)
                {
                    result = root.Result;
                    break;
                }
                root = root.GetNextBranch(root.Key);
            }

            return result;
        }
    }
}