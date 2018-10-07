namespace Algorithms.FowlerNollVoHash
{
    public static class FowlerNollVoHash
    {
        private static uint _fnvPrime = 16777619;
        private static uint _fnvOffset = 2166136261;
        // FNV-1 hash variant for 32-bit hash
        public static uint Hash(byte[] data)
        {
            if (data == null)
            {
                return 0;
            }
            var hash = _fnvOffset;
            foreach (var b in data)
            {
                hash = hash * _fnvPrime;
                hash = hash ^ b;
            }

            return hash;
        }
    }
}
