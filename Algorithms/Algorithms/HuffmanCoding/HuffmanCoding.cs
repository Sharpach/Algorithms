using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.HuffmanCoding
{

    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public long frequency;
        public char ch;

        public HuffmanNode left;
        public HuffmanNode right;

        public HuffmanNode(char ch, long frequency)
        {
            this.ch = ch;
            this.frequency = frequency;
        }

        public int CompareTo(HuffmanNode node)
        {
            return frequency.CompareTo(node.frequency);
        }
    }

    public class HuffmanCoding
    {
        PriorityQueue<HuffmanNode> priorityQueue;
        HuffmanNode root = null;
        Dictionary<char, string> prefixCode = new Dictionary<char, string>();

        internal void BuildHuffmanTree(Dictionary<char, long> charFrequency)
        {
            // Create a priority queue with capacity as dictionary size (no of unique chars)
            priorityQueue = new PriorityQueue<HuffmanNode>(charFrequency.Count);

            foreach (var item in charFrequency)
            {
                var node = new HuffmanNode(item.Key, item.Value);
                priorityQueue.Enqueue(node);
            }

            while (priorityQueue.Count > 1)
            {
                var first = priorityQueue.Dequeue();
                var second = priorityQueue.Dequeue();

                var parent = new HuffmanNode('$', first.frequency + second.frequency);
                parent.left = first;
                parent.right = second;

                root = parent;

                priorityQueue.Enqueue(parent);
            }
        }

        internal void GeneratePrefixCode(HuffmanNode node, string input)
        {
            if (node.left == null && node.right == null && Char.IsLetter(node.ch))
            {
                prefixCode.Add(node.ch, input);
                return;
            }

            GeneratePrefixCode(node.left, input + "0");
            GeneratePrefixCode(node.right, input + "1");
        }

        internal Dictionary<char, long> GetCharacterFrequency(string inputStr)
        {
            var charFrequency = new Dictionary<char, long>();

            foreach (var ch in inputStr)
            {
                if (charFrequency.ContainsKey(ch))
                    charFrequency[ch]++;
                else
                    charFrequency[ch] = 1;
            }
            return charFrequency;
        }

        public string GetHuffmanCode(string data, string input)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException("Invalid data");
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("Invalid input string");

            string huffmanCode = string.Empty;

            var charFrequency = GetCharacterFrequency(data);
            BuildHuffmanTree(charFrequency);
            GeneratePrefixCode(root, string.Empty);

            if(prefixCode?.Count > 0)
            {
                foreach(var ch in input)
                {
                    huffmanCode += prefixCode[ch];
                }
            }
            return huffmanCode;
        }
    }
}
