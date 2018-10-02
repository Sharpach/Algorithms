using System;
using System.Collections.Generic;

namespace Algorithms.DecisionTree
{
    public interface IDecision<TIn, TOut>
    {
        /// <summary>
        /// Shared object, common for all decisions
        /// </summary>
        TIn Value { get; }
        
        /// <summary>Action, changes state of tree</summary>
        Func<IDecision<TIn, TOut>, TIn, Either<IDecision<TIn,TOut>, TOut>> Decider { get; }
    }
}