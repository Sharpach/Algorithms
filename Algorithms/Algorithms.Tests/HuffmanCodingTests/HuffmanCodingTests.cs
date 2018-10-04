using Algorithms.HuffmanCoding;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algorithms.Tests.HuffmanCodingTests
{
    public class HuffmanCodingTests
    {
        [Fact]
        public void TestPriorityQueue()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(20);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(100);

            Assert.Equal(5, priorityQueue.Dequeue());
        }

        [Theory]
        [InlineData("abaacaabd", "d", "011")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaac", "a", "1")]
        [InlineData("cad", "acd", "11100")]
        public void TestHuffmanCode(string data, string input, string expectedCode)
        {
            HuffmanCoding.HuffmanCoding huffmanCoding = new HuffmanCoding.HuffmanCoding();
            Assert.Equal(expectedCode, huffmanCoding.GetHuffmanCode(data, input));
        }
    }
}
