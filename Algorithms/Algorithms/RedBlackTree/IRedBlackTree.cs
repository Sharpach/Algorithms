using System;

namespace Algorithms
{
	internal interface IRedBlackTree<T>
		where T : IComparable
	{
		void Insert(T item);
		void Delete(T item);
	}
	public enum Colour
	{
		Red,
		Black
	}
	
}