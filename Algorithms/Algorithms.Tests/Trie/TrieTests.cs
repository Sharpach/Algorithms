using Xunit;
using Algorithms.Trie;

namespace Algorithms.Tests
{
    public class TrieTests
    {
        [Fact]
        public void Check()
        {
            var trie = new Algorithms.Trie.Trie();
            trie.Insert("Hello");
            trie.Insert("Hey");
            Assert.Empty(trie.FindPrefix("h"));
            Assert.Equal(2, trie.FindPrefix("H").Count);
            trie.Insert("Hello");
            trie.Insert("Hey");
            Assert.Empty(trie.FindPrefix("h"));
            Assert.Equal(2, trie.FindPrefix("H").Count);
            trie.Insert("hello");
            trie.Insert("hey");
            Assert.Equal(2, trie.FindPrefix("h").Count);
            Assert.Equal(2, trie.FindPrefix("H").Count);
            Assert.Equal(2, trie.FindPrefix("He").Count);
            Assert.Single(trie.FindPrefix("Hel"));
            Assert.Single(trie.FindPrefix("Hey"));
            trie.Clear();
            Assert.Empty(trie.FindPrefix("h"));
            Assert.Empty(trie.FindPrefix("H"));
        }
    }
}
