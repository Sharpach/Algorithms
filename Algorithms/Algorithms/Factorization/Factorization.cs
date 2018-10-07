using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class Factorization
    {
        public static IEnumerable<int> GetFactorsOf(int input)
        {
            if (input < 0)
                return new [] {0};

            var first = GetPrimes()
                .TakeWhile(x => x <= Math.Sqrt(input))
                .FirstOrDefault(x => input % x == 0);

            var result = first == 0
                ? new[] { input }
                : new[] { first }.Concat(GetFactorsOf(input / first));

            return result;
        }

        private static IEnumerable<int> GetSequence()
        {
            yield return 2;
            yield return 3;

            var k = 1;
            while (k > 0)
            {
                yield return 6 * k - 1;
                yield return 6 * k + 1;
                k++;
            }
        }

        private static IEnumerable<int> GetPrimes()
        {
            var memoized = new List<int>();
            var sqrt = 1;
            var primes = GetSequence().Where(x =>
            {
                sqrt = GetSqrtCeiling(x, sqrt);
                return memoized
                    .TakeWhile(y => y <= sqrt)
                    .All(y => x % y != 0);
            });

            foreach (var prime in primes)
            {
                yield return prime;
                memoized.Add(prime);
            }
        }

        private static int GetSqrtCeiling(int value, int start)
        {
            while (start * start < value)
            {
                start++;
            }
            return start;
        }
    }
}
