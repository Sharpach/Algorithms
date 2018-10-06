using System;

namespace Algorithms.DecisionTree
{
    public class Decision<TIn, TOut> : IDecision<TIn, TOut>
    {
        public Decision(TIn value, Func<IDecision<TIn, TOut>, TIn, Either<IDecision<TIn, TOut>, TOut>> decider)
        {
            Value = value;
            Decider = decider;
        }

        public TIn Value { get; }

        public Func<IDecision<TIn, TOut>, TIn, Either<IDecision<TIn, TOut>, TOut>> Decider { get; }
    }
}