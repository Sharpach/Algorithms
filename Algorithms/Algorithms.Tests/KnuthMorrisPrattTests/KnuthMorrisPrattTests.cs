using System.Collections.Generic;
using Xunit;

namespace Algorithms.Tests
{
    public class KnuthMorrisPrattTests
    {
        [Theory]
        [InlineData("AKMPAKMPCAADAKMPAKMPAA", "AKMPA", 3, 0, 0)]
        [InlineData("AKMPAKMPCAADAKMPAKMPAA", "AKMPA", 3, 1, 12)]
        [InlineData("AKMPAKMPCAADAKMPAKMPAA", "AKMPA", 3, 2, 16)]
        [InlineData("AKMPACAADAKMPKMP", "PKMP", 1, 0, 12)]
        public void FunctionalityCheck(string text, string search, int resultCount, int index, int expectedResult)
        {
            var result = KnuthMorrisPratt.KnuthMorrisPratt.KMPSearch(text, search);
            Assert.NotEmpty(result);
            Assert.Equal(resultCount, result.Count);
            Assert.Equal(expectedResult, result[index]);
        }

        [Theory]
        [InlineData("AKMPACAADAKMPKMP", "ASD")]
        [InlineData("AKMPACAADAKMPKMP", "AADC")]
        [InlineData("AKMPACAADAKMPKMP", "AADAKMPKP")]
        public void EmptyCheck(string text, string search)
        {
            var result = KnuthMorrisPratt.KnuthMorrisPratt.KMPSearch(text, search);
            Assert.Empty(result);
        }
    }
}
