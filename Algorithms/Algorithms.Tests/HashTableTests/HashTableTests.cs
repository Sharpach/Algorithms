using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.Tests.HashTableTests
{
    public class HashTableTests
    {
        public struct TestObj
        {
            public int Number;
        }
        [Theory]
        [InlineData(new int[] { }, 0)]
        [InlineData(new[] { 1, 2, 3 }, 3)]
        [InlineData(new[] { 42 }, 1)]
        [InlineData(new[] { 5, 10, 15, 25, 40, 80 }, 6)]
        public void HashTable_Count_elements_added(int[] source, int expectedSize)
        {
            var ht = new HashTable();

            foreach (var item in source)
                ht.Add(item, item);

            Assert.True(ht.Count == expectedSize);
        }

        [Fact]
        public void HashTable_find_items_with_contains()
        {
            var ht = new HashTable();

            var objs = new TestObj[] {
                    new TestObj { Number = 5 },
                    new TestObj { Number = 1 } };

            Assert.False(ht.Contains(objs[0]));

            ht.Add(objs[0], objs[0].Number);
            ht.Add(objs[1], objs[1].Number);

            Assert.True(ht.Contains(objs[0]));

            Assert.True(ht.ContainsValue((int)5));
        }

        [Fact]
        public void HastTable_clear_with_counts()
        {
            var ht = new HashTable();

            ht.Clear();

            var obj1 = new TestObj { Number = 5 };
            var obj2 = new TestObj { Number = 1 };

            ht.Add(obj1, obj1.Number);
            ht.Add(obj2, obj2.Number);

            var count = ht.Count;

            ht.Clear();

            var newCount = ht.Count;

            Assert.True(count == 2);
            Assert.True(newCount == 0);
            Assert.Empty(ht);
        }

        [Fact]
        public void HastTable_remove_with_counts()
        {
            var ht = new HashTable();

            var obj1 = new TestObj { Number = 7 };
            var obj2 = new TestObj { Number = 8 };
            var obj3 = new TestObj { Number = 9 };

            ht.Add(obj1, obj1.Number);
            ht.Add(obj2, obj2.Number);
            ht.Add(obj3, obj3.Number);

            var count = ht.Count;

            ht.Remove(obj2);

            var newCount = ht.Count;

            Assert.True(count == 3);
            Assert.True(newCount == 2);
            Assert.True(!ht.Contains(obj2));
        }

        [Fact]
        public void HashTable_copyTo_Array()
        {
            var ht = new HashTable();

            var array = new object[5];
            array[2] = new DictionaryEntry((int)4, (int)5);
            array[3] = new DictionaryEntry((int)1, (int)9);

            var test = new object[5];
            ht.Add((int)4, (int)5);
            ht.Add((int)1, (int)9);
            ht.CopyTo(test, 2);

            Assert.Equal(array, test);
        }

        [Fact]
        public void HashTable_indexer_access()
        {
            var ht = new HashTable();

            ht.Add((int)6, "value");
            ht.Add((int)7, "test");

            var result = ht[6];

            Assert.Equal("value", result);

            ht[7] = "new";

            Assert.Equal("new", ht[7]);
        }

        [Fact]
        public void HashTable_Add_Method_Exception()
        {
            var ht = new HashTable();

            Assert.Throws<ArgumentNullException>(() => ht.Add(null, "test"));
        }

        [Fact]
        public void HashTable_Add_Method_dupe_Exception()
        {
            var ht = new HashTable();

            var obj1 = new TestObj { Number = 1 };
            var obj2 = new TestObj { Number = 2 };

            ht.Add(obj1, obj1.Number);
            ht.Add(obj2, obj2.Number);

            Assert.Throws<ArgumentException>(() => ht.Add(obj2, obj2.Number));
        }

        [Fact]
        public void HashTable_copyTo_Method_Exception()
        {
            var ht = new HashTable();

            var objs = new TestObj[] {
                new TestObj { Number = 25 },
                new TestObj { Number = 9 } };

            var test = new object[1];

            ht.Add(objs[0], objs[0].Number);
            ht.Add(objs[1], objs[1].Number);

            Assert.Throws<ArgumentException>(() => ht.CopyTo(test, 0));
        }

        [Fact]
        public void HashTable_indexer_Exception()
        {
            var ht = new HashTable();

            var obj1 = new TestObj { Number = 7 };
            var obj2 = new TestObj { Number = 8 };

            ht.Add(obj1, obj1.Number);
            ht.Add(obj2, obj2.Number);

            Assert.Throws<ArgumentNullException>(() => ht[null]);
            Assert.Throws<ArgumentNullException>(() => ht[null] = obj2);
        }
    }
}
