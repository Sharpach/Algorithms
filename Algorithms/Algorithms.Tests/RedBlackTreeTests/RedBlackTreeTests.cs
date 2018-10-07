using System;
using System.Collections.Generic;
using Algorithms.DecisionTree;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class RedBlackTreeTests
    {
        [Fact]
		public void Test_RedBlackTree_Integer()
		{
			RedBlackTree<int> tree = new RedBlackTree<int>();
			List<int> inOrderTree = new List<int> { 1, 3, 5, 7, 9 };
			tree.Insert(5);
			tree.Insert(3);
			tree.Insert(7);
			tree.Insert(1);
			tree.Insert(9);
			tree.Insert(-1);
			tree.Delete(-1);
			List<int> finalTree = tree.DisplayTree();
			finalTree.Should().BeEquivalentTo(inOrderTree);
		}
	}
}