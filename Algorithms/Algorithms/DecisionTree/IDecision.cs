using System;
using System.Collections.Generic;

namespace Atlas.KarmaWorker.Utils.Decision
{
    public interface IDecision<TIn, TOut>
    {
        /// <summary>
        /// Key to get branch from dictionary
        /// </summary>
        int Key { get; set; }
        
        /// <summary>
        /// Final result
        /// </summary>
        TOut Result { get; set; }
        
        /// <summary>
        /// Shared object, common for all decisions
        /// </summary>
        TIn Value { get; }
        
        Dictionary<int, IDecision<TIn,TOut>> Branches { get; set; }
        
        Action<IDecision<TIn, TOut>, TIn> Mutator { get; set; }
        
        IDecision<TIn, TOut> GetNextBranch(int key);
    }
}