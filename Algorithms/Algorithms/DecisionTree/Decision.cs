using System;
using System.Collections.Generic;

namespace Atlas.KarmaWorker.Utils.Decision
{
    public class Decision<TIn, TOut> : IDecision<TIn, TOut>
    {
        public Decision(TIn value)
        {
            Value = value;
        }

        public int Key { get; set; }
        
        public TOut Result { get; set; }
        public TIn Value { get; }

        public Dictionary<int, IDecision<TIn, TOut>> Branches { get; set; }
        public Action<IDecision<TIn, TOut>, TIn> Mutator { get; set; }
        
        public IDecision<TIn, TOut> GetNextBranch(int key) 
            => Branches.ContainsKey(key)
               ? Branches[key]
               : null;
    }
}