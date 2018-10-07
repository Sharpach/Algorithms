using System;

namespace Algorithms
{
    public static class CatalanNumberGenerator
    {
        private static double Factorial(double n)
        {
            if (n <= 0.0)
                return 1;

            return n * Factorial(n - 1);
        }

        public static double GetNumberOn(int n)
        {
            if (n <= 0)
                return 0;

            const double topMultiplier = 2.0;
            var result = Factorial(topMultiplier * n) / (Factorial(n + 1) * Factorial(n));

            return Math.Ceiling(result);
        }
    }
}
