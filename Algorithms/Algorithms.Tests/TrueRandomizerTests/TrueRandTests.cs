using Xunit;

namespace Algorithms.Tests.TrueRandomizerTests
{
	public class TrueRandomizerTests
    {
        [Fact]
		public void TrueRandomizerTest()
        {
			int[] input = { 1, 10000 };
			TrueRandomizer.Program randomizer = new TrueRandomizer.Program(input[0], input[1]);
			bool output = randomizer.RandomNumber >= input[0] && randomizer.RandomNumber <= input[1];
			Assert.True(output);
        }
    }
}