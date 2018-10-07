using System.Text;
using Xunit;

namespace Algorithms.Tests.FowlerNollVoHashTests
{
    // tests taken from http://www.isthe.com/chongo/src/fnv/test_fnv.c
    public class FowlerNollVoHashTests
    {
        [Theory]
        [InlineData("", 0x811c9dc5)]
        [InlineData("a", 0x050c5d7e)]
        [InlineData("b", 0x050c5d7d)]
        [InlineData("foo", 0x408f5e13)]
        [InlineData("foob", 0xb4b1178b)]
        [InlineData("fooba", 0xfdc80fb0)]
        [InlineData("foobar", 0x31f0b262)]
        [InlineData("http://en.wikipedia.org/wiki/Fowler_Noll_Vo_hash", 0x025dfe59)]
        public void Test(string input, uint expected)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            Assert.Equal(expected, FowlerNollVoHash.FowlerNollVoHash.Hash(bytes));
        }
    }
}
