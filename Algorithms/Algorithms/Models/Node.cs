namespace Algorithms.Models
{
    /// <summary>
    /// Serves as a base class for other node types.
    /// </summary>
    public abstract class Node<T>
    {
        public T Data { get; set; }
    }
}