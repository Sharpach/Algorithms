using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class BracketsBalance
    {
        private static readonly HashSet<char> OpeningBrackets = new HashSet<char>{'{','(','['};
        
        public static bool IsValidBracketString(string input)
        {
            var stack = new Stack<char>();

            var bracketPairs = new Dictionary<char, char>
            {
                {'}', '{'},
                {')', '('},
                {']', '['}
            };

            foreach (var charick in input)
            {
                if (charick.IsOpeningBracket())
                {
                    stack.Push(charick);
                    continue;
                }

                var lastBracket = stack.Peek();
                
                if (bracketPairs[charick] != lastBracket) return false;
                
                stack.Pop();
            }
            
            return stack.Count == 0;
        }

        private static bool IsOpeningBracket(this char charick)
        {
            return OpeningBrackets.Contains(charick);
        }
    }
}