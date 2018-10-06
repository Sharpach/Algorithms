using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithms
{


	
	public class RedBlackTree<T> : IRedBlackTree<T>
		where T : IComparable
	{
		/// <summary>
		/// Object of type Node contains 4 properties
		/// Colour
		/// Left
		/// Right
		/// Parent
		/// Data
		/// </summary>
		public class Node
		{
			public Colour Colour;
			public Node Left;
			public Node Right;
			public Node Parent;
			public T Data;

			public Node(T Data) { this.Data = Data; }
			public Node(Colour Colour) { this.Colour = Colour; }
			public Node(T Data, Colour Colour) { this.Data = Data; this.Colour = Colour; }
		}
		/// <summary>
		/// Root node of the tree (both reference & pointer)
		/// </summary>
		private Node root;
		/// <summary>
		/// New instance of a Red-Black tree object
		/// </summary>
		public RedBlackTree() { }
		/// <summary>
		/// Left Rotate
		/// </summary>
		/// <param name="x"></param>
		/// <returns>void</returns>
		private void LeftRotate(Node x)
		{
			Node y = x.Right; // set y
			x.Right = y.Left;//turn y's Left subtree into x's Right subtree
			if (y.Left != null)
			{
				y.Left.Parent = x;
			}
			if (y != null)
			{
				y.Parent = x.Parent;//link x's Parent to y
			}
			if (x.Parent == null)
			{
				root = y;
			}
			if (x == x.Parent.Left)
			{
				x.Parent.Left = y;
			}
			else
			{
				x.Parent.Right = y;
			}
			y.Left = x; //put x on y's Left
			if (x != null)
			{
				x.Parent = y;
			}

		}
		/// <summary>
		/// Rotate Right
		/// </summary>
		/// <param name="y"></param>
		/// <returns>void</returns>
		private void RightRotate(Node y)
		{
			// Right rotate is simply mirror code from Left rotate
			Node x = y.Left;
			y.Left = x.Right;
			if (x.Right != null)
			{
				x.Right.Parent = y;
			}
			if (x != null)
			{
				x.Parent = y.Parent;
			}
			if (y.Parent == null)
			{
				root = x;
			}
			if (y == y.Parent.Right)
			{
				y.Parent.Right = x;
			}
			if (y == y.Parent.Left)
			{
				y.Parent.Left = x;
			}

			x.Right = y;//put y on x's Right
			if (y != null)
			{
				y.Parent = x;
			}
		}
		/// <summary>
		/// Display Tree
		/// </summary>
		public List<T> DisplayTree()
		{
			List<T> inOrderList = new List<T>();
			if (root == null)
			{
				Console.WriteLine("Tree is empty!");
			}
			if (root != null)
			{
				InorderDisplay(inOrderList, root);
			}
			return inOrderList;
		}
		/// <summary>
		/// Find item in the tree
		/// </summary>
		/// <param name="key"></param>
		public Node Find(T key)
		{
			bool isFound = false;
			Node temp = root;
			Node item = null;
			while (!isFound)
			{
				if (temp == null)
				{
					break;
				}
				if (key.CompareTo(temp.Data) < 0)
				{
					temp = temp.Left;
				}
				if (key.CompareTo(temp.Data) > 0)
				{
					temp = temp.Right;
				}
				if (key.CompareTo(temp.Data) == 0)
				{
					isFound = true;
					item = temp;
				}
			}
			if (isFound)
			{
				Console.WriteLine("{0} was found", key);
				return temp;
			}
			else
			{
				Console.WriteLine("{0} not found", key);
				return null;
			}
		}
		/// <summary>
		/// Insert a new object into the RB Tree
		/// </summary>
		/// <param name="item"></param>
		public void Insert(T item)
		{
			Node newItem = new Node(item);
			if (root == null)
			{
				root = newItem;
				root.Colour = Colour.Black;
				return;
			}
			Node y = null;
			Node x = root;
			while (x != null)
			{
				y = x;
				if (newItem.Data.CompareTo(x.Data) < 0)
				{
					x = x.Left;
				}
				else
				{
					x = x.Right;
				}
			}
			newItem.Parent = y;
			if (y == null)
			{
				root = newItem;
			}
			else if (newItem.Data.CompareTo(y.Data) < 0)
			{
				y.Left = newItem;
			}
			else
			{
				y.Right = newItem;
			}
			newItem.Left = null;
			newItem.Right = null;
			newItem.Colour = Colour.Red;//Colour the new node red
			InsertionCheck(newItem);//call method to check for violations and fix
		}
		private void InorderDisplay(List<T> inorderList, Node current)
		{
			if (current != null)
			{
				InorderDisplay(inorderList, current.Left);
				inorderList.Add(current.Data);
				InorderDisplay(inorderList, current.Right);
			}
		}
		private void InsertionCheck(Node item)
		{
			//Checks Red-Black Tree properties
			while (item != root && item.Parent.Colour == Colour.Red)
			{
				/*We have a violation*/
				if (item.Parent == item.Parent.Parent.Left)
				{
					Node y = item.Parent.Parent.Right;
					if (y != null && y.Colour == Colour.Red)//Case 1: uncle is red
					{
						item.Parent.Colour = Colour.Black;
						y.Colour = Colour.Black;
						item.Parent.Parent.Colour = Colour.Red;
						item = item.Parent.Parent;
					}
					else //Case 2: uncle is black
					{
						if (item == item.Parent.Right)
						{
							item = item.Parent;
							LeftRotate(item);
						}
						//Case 3: reColour & rotate
						item.Parent.Colour = Colour.Black;
						item.Parent.Parent.Colour = Colour.Red;
						RightRotate(item.Parent.Parent);
					}

				}
				else
				{
					//mirror image of code above
					Node x = null;

					x = item.Parent.Parent.Left;
					if (x != null && x.Colour == Colour.Black)//Case 1
					{
						item.Parent.Colour = Colour.Red;
						x.Colour = Colour.Red;
						item.Parent.Parent.Colour = Colour.Black;
						item = item.Parent.Parent;
					}
					else //Case 2
					{
						if (item == item.Parent.Left)
						{
							item = item.Parent;
							RightRotate(item);
						}
						//Case 3: reColour & rotate
						item.Parent.Colour = Colour.Black;
						item.Parent.Parent.Colour = Colour.Red;
						LeftRotate(item.Parent.Parent);

					}

				}
				root.Colour = Colour.Black;//re-Colour the root black as necessary
			}
		}
		/// <summary>
		/// Deletes a specified value from the tree
		/// </summary>
		/// <param name="item"></param>
		public void Delete(T key)
		{
			//first find the node in the tree to delete and assign to item pointer/reference
			Node item = Find(key);
			Node x = null;
			Node y = null;

			if (item == null)
			{
				Console.WriteLine("Nothing to delete!");
				return;
			}
			if (item.Left == null || item.Right == null)
			{
				y = item;
			}
			else
			{
				y = TreeSuccessor(item);
			}
			if (y.Left != null)
			{
				x = y.Left;
			}
			else
			{
				x = y.Right;
			}
			if (x != null)
			{
				x.Parent = y;
			}
			if (y.Parent == null)
			{
				root = x;
			}
			else if (y == y.Parent.Left)
			{
				y.Parent.Left = x;
			}
			else
			{
				y.Parent.Left = x;
			}
			if (y != item)
			{
				item.Data = y.Data;
			}
			if (y.Colour == Colour.Black)
			{
				DeletionCheck(x);
			}

		}
		/// <summary>
		/// Checks the tree for any violations after deletion and performs a fix
		/// </summary>
		/// <param name="x"></param>
		private void DeletionCheck(Node x)
		{

			while (x != null && x != root && x.Colour == Colour.Black)
			{
				if (x == x.Parent.Left)
				{
					Node W = x.Parent.Right;
					if (W.Colour == Colour.Red)
					{
						W.Colour = Colour.Black; //case 1
						x.Parent.Colour = Colour.Red; //case 1
						LeftRotate(x.Parent); //case 1
						W = x.Parent.Right; //case 1
					}
					if (W.Left.Colour == Colour.Black && W.Right.Colour == Colour.Black)
					{
						W.Colour = Colour.Red; //case 2
						x = x.Parent; //case 2
					}
					else if (W.Right.Colour == Colour.Black)
					{
						W.Left.Colour = Colour.Black; //case 3
						W.Colour = Colour.Red; //case 3
						RightRotate(W); //case 3
						W = x.Parent.Right; //case 3
					}
					W.Colour = x.Parent.Colour; //case 4
					x.Parent.Colour = Colour.Black; //case 4
					W.Right.Colour = Colour.Black; //case 4
					LeftRotate(x.Parent); //case 4
					x = root; //case 4
				}
				else //mirror code from above with "Right" & "Left" exchanged
				{
					Node W = x.Parent.Left;
					if (W.Colour == Colour.Red)
					{
						W.Colour = Colour.Black;
						x.Parent.Colour = Colour.Red;
						RightRotate(x.Parent);
						W = x.Parent.Left;
					}
					if (W.Right.Colour == Colour.Black && W.Left.Colour == Colour.Black)
					{
						W.Colour = Colour.Black;
						x = x.Parent;
					}
					else if (W.Left.Colour == Colour.Black)
					{
						W.Right.Colour = Colour.Black;
						W.Colour = Colour.Red;
						LeftRotate(W);
						W = x.Parent.Left;
					}
					W.Colour = x.Parent.Colour;
					x.Parent.Colour = Colour.Black;
					W.Left.Colour = Colour.Black;
					RightRotate(x.Parent);
					x = root;
				}
			}
			if (x != null)
				x.Colour = Colour.Black;
		}
		private Node Minimum(Node x)
		{
			while (x.Left.Left != null)
			{
				x = x.Left;
			}
			if (x.Left.Right != null)
			{
				x = x.Left.Right;
			}
			return x;
		}
		private Node TreeSuccessor(Node x)
		{
			if (x.Left != null)
			{
				return Minimum(x);
			}
			else
			{
				Node y = x.Parent;
				while (y != null && x == y.Right)
				{
					x = y;
					y = y.Parent;
				}
				return y;
			}
		}
	}
}

