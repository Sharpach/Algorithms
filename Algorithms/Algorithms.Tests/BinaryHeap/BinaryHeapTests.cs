using System.Collections.Generic;
using System.Data;
using Algorithms.BinaryHeap;
using Xunit;

namespace Algorithms.Tests.BinaryHeap
{
    public class BinaryHeapTests
    {
        [Fact]
        public void Can_not_remove_root_from_empty_heap()
        {
            var heap = new BinaryHeap<int>();
            Assert.Throws<DataException>(() => heap.RemoveRoot());
        }
        
        [Fact]
        public void Heap_size_should_increase_after_add()
        {
            var heap = new BinaryHeap<int>();
            heap.Add(42);
            Assert.True(heap.Size == 1);
        }

        [Fact]
        public void Heap_size_should_decrease_after_remove()
        {
            var heap = new BinaryHeap<int>(new List<int>{1, 2, 3});
            heap.RemoveRoot();
            Assert.True(heap.Size == 2);
        }
        
        [Theory]
        [InlineData(new int[] {}, 0)]
        [InlineData(new [] {1, 2, 3}, 3)]
        [InlineData(new [] {42}, 1)]
        public void Heap_size_should_be_equal_to_array_length(int[] source, int expectedSize)
        {
            var heap = new BinaryHeap<int>(source);
            Assert.True(heap.Size == expectedSize);
        }

        [Theory]
        [InlineData(new [] {1}, 1)]
        [InlineData(new [] {1, 2, 3}, 3, 2, 1)]
        [InlineData(new [] {42, 3, 67, -10}, 67, 42)]
        public void Root_should_always_be_max_in_MaxHeap(int[] data, params int[] expectedValues)
        {
            var heap = new BinaryHeap<int>(data, HeapType.MaxHeap);
            foreach (var value in expectedValues)
            {
                Assert.True(heap.RemoveRoot() == value);
            }
        }

        [Theory]
        [InlineData(new [] {1}, 1)]
        [InlineData(new [] {1, 2, 3}, 1, 2, 3)]
        [InlineData(new [] {7, 1, 54, 3, -42}, -42, 1, 3, 7, 54)]
        public void Root_should_always_be_min_in_MinHeap(int[] data, params int[] expectedValues)
        {
            var heap = new BinaryHeap<int>(data, HeapType.MinHeap);
            foreach (var value in expectedValues)
            {
                Assert.True(heap.RemoveRoot() == value);
            }
        }
    }
}