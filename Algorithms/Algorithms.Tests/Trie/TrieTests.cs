using Xunit;
using Algorithms.Trie;

namespace Algorithms.Tests
{
    public class TrieTests
    {
        [Fact]
        public void EmptyCheck()
        {
            var trie = new Algorithms.Trie.Trie();
            Assert.Empty(trie.FindPrefix("h"));
        }

        [Fact]
        public void InsertAndFindCheck()
        {
            var trie = new Algorithms.Trie.Trie();
            trie.Insert("Hello");
            trie.Insert("Hey");
            Assert.Equal(2, trie.FindPrefix("H").Count);
            Assert.Equal(2, trie.FindPrefix("He").Count);
            Assert.Single(trie.FindPrefix("Hel"));
            Assert.Single(trie.FindPrefix("Hey"));
        }

        [Fact]
        public void DuplicateInsertAndFindCheck()
        {
            var trie = new Algorithms.Trie.Trie();
            trie.Insert("Hello");
            trie.Insert("Hey");
            Assert.Equal(2, trie.FindPrefix("H").Count);
            trie.Insert("Hello");
            trie.Insert("Hey");
            Assert.Equal(2, trie.FindPrefix("H").Count);
            trie.Insert("hello");
            trie.Insert("hey");
            Assert.Equal(2, trie.FindPrefix("h").Count);
            Assert.Equal(2, trie.FindPrefix("H").Count);
        }

        [Fact]
        public void CaseSensitiveFindCheck()
        {
            var trie = new Algorithms.Trie.Trie();
            trie.Insert("Hello");
            trie.Insert("Hey");
            Assert.Equal(2, trie.FindPrefix("H").Count);
            Assert.Empty(trie.FindPrefix("h"));
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
        }

        [Fact]
        public void ClearCheck()
        {
            var trie = new Algorithms.Trie.Trie();
            trie.Insert("Hello");
            trie.Insert("Hey");
            Assert.Equal(2, trie.FindPrefix("H").Count);
            Assert.Empty(trie.FindPrefix("h"));
            trie.Clear();
            Assert.Empty(trie.FindPrefix("h"));
            Assert.Empty(trie.FindPrefix("H"));
        }
    }
}
