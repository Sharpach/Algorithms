using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trie
{
    public class Trie
    {
        private Dictionary<char, Trie> _children = new Dictionary<char, Trie>();
        private bool _isWordCompleted = false;
        private int _size = 0;

        public void Insert(string s)
        {
            Insert(s, 0);
        }

        private void Insert(string s, int index)
        {
            _size++;
            if (index == s.Length)
            {
                _isWordCompleted = true;
                return;
            }
            char c = s[index];
            Trie child = GetNode(c);
            if (child == null)
            {
                child = new Trie();
                InsertNode(c, child);
            }
            child.Insert(s, index + 1);
        }

        private Trie GetNode(char c)
        {
            if (_children.ContainsKey(c))
            {
                return _children[c];
            }
            return null;
        }

        private void InsertNode(char c, Trie node)
        {
            _children.Add(c, node);
        }
        
        public List<string> FindPrefix(string word)
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(word))
                return list;

            var iterator = this;
            var fetchedWord = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!iterator._children.ContainsKey(c))
                    break;

                fetchedWord.Append(c);
                iterator = iterator._children[c];
            }

            if (iterator._isWordCompleted)
            {
                list.Add(fetchedWord.ToString());
            }
            if (fetchedWord.Length<1) return list;
            var remainingWords = GetAllWordsFromTrie(iterator);
            var preWord = fetchedWord.ToString();
            var words = remainingWords.Select(w => $"{preWord}{w}");
            list.AddRange(words);
            return list;
        }

        private List<string> GetAllWordsFromTrie(Trie iterator)
        {
            var list = new List<string>();
            if (iterator == null || !iterator._children.Any())
                return list;

            foreach (var iteratorChild in iterator._children)
            {
                var fetchedWord = new StringBuilder();
                fetchedWord.Append(iteratorChild.Key);
                if (iteratorChild.Value._isWordCompleted)
                {
                    list.Add(fetchedWord.ToString());
                }

                var remaining = GetAllWordsFromTrie(iteratorChild.Value);
                var preword = fetchedWord.ToString();
                var res = remaining.Select(w => $"{preword}{w}");
                list.AddRange(res);
            }
            return list;
        }

        public void Clear()
        {
            ClearNodes(this);
        }

        private void ClearNodes(Trie value)
        {
            int removedNodes = 0;
            foreach (var keyValue in _children)
            {
                ClearNodes(keyValue.Value);
                removedNodes++;
            }
            _size -= removedNodes;
            _children.Clear();
        }
    }
}
