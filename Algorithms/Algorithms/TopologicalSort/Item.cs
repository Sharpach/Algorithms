namespace Algorithms
{
    public class Item
    {
        public string Name { get; }
        public string[] Dependencies { get; }

        public Item(string name, params string[] dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }
    }
}