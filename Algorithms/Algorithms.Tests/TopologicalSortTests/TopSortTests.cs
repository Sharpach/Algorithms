using System.Linq;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.TopologicalSortTests
{
    public class TopSortTests
    {
        [Fact]
        public void TopSort_SortItems_ReturnResult()
        {
            var a = new Item("A");
            var b = new Item("B", "C", "E");
            var c = new Item("C");
            var d = new Item("D", "A");
            var e = new Item("E", "D", "G");
            var f = new Item("F");
            var g = new Item("G", "F", "H");
            var h = new Item("H");
            var unsorted = new[] { a, b, c, d, e, f, g, h };
            var expected = "ACDFHGEB";
            
            var sortedItems = TopologicalSort.Sort(unsorted, x => x.Dependencies, x => x.Name);
            var data = sortedItems.Aggregate("", (current, group) => current + group.Name);

            data.Should().Be(expected);
        }

        [Fact]
        public void TopSort_GroupItems_ReturnResult()
        {
            var a = new Item("A");
            var b = new Item("B", "C", "E");
            var c = new Item("C");
            var d = new Item("D", "A");
            var e = new Item("E", "D", "G");
            var f = new Item("F");
            var g = new Item("G", "F", "H");
            var h = new Item("H");
            var unsorted = new[] { a, b, c, d, e, f, g, h };
            var expected = "ACFH/DG/E/B/";

            var grouped = TopologicalSort.Group(unsorted, x => x.Dependencies, x => x.Name);
            var data = "";
            foreach (var group in grouped)
            {
                data = group.Aggregate(data, (current, item) => current + item.Name);
                data += "/";
            }

            data.Should().Be(expected);
        }
    }
}
