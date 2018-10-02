using Xunit;

namespace Algorithms.Tests
{
    public class KnuthMorrisPrattTests
    {
        [Fact]
        public void FunctionalityCheck()
        {
            var result = KnuthMorrisPratt.KnuthMorrisPratt.KMPSearch("AKMPAKMPCAADAKMPAKMPAA", "AKMPA");
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(0, result[0]);
            Assert.Equal(12, result[1]);
            Assert.Equal(16, result[2]);
        }

        [Fact]
        public void EmptyCheck()
        {
            var result = KnuthMorrisPratt.KnuthMorrisPratt.KMPSearch("AKMPACAADAKMPKMP", "ASD");
            Assert.Empty(result);
        }
    }
}
