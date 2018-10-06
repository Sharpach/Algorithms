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
			public Colour colour;
			public Node left;
			public Node right;
			public Node parent;
			public T data;

			public Node(T data) { this.data = data; }
			public Node(Colour colour) { this.colour = colour; }
			public Node(T data, Colour colour) { this.data = data; this.colour = colour; }
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
		/// <param name="X"></param>
		/// <returns>void</returns>
		private void LeftRotate(Node X)
		{
			Node Y = X.right; // set Y
			X.right = Y.left;//turn Y's left subtree into X's right subtree
			if (Y.left != null)
			{
				Y.left.parent = X;
			}
			if (Y != null)
			{
				Y.parent = X.parent;//link X's parent to Y
			}
			if (X.parent == null)
			{
				root = Y;
			}
			if (X == X.parent.left)
			{
				X.parent.left = Y;
			}
			else
			{
				X.parent.right = Y;
			}
			Y.left = X; //put X on Y's left
			if (X != null)
			{
				X.parent = Y;
			}

		}
		/// <summary>
		/// Rotate Right
		/// </summary>
		/// <param name="Y"></param>
		/// <returns>void</returns>
		private void RightRotate(Node Y)
		{
			// right rotate is simply mirror code from left rotate
			Node X = Y.left;
			Y.left = X.right;
			if (X.right != null)
			{
				X.right.parent = Y;
			}
			if (X != null)
			{
				X.parent = Y.parent;
			}
			if (Y.parent == null)
			{
				root = X;
			}
			if (Y == Y.parent.right)
			{
				Y.parent.right = X;
			}
			if (Y == Y.parent.left)
			{
				Y.parent.left = X;
			}

			X.right = Y;//put Y on X's right
			if (Y != null)
			{
				Y.parent = X;
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
				InOrderDisplay(inOrderList, root);
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
				if (key.CompareTo(temp.data) < 0)
				{
					temp = temp.left;
				}
				if (key.CompareTo(temp.data) > 0)
				{
					temp = temp.right;
				}
				if (key.CompareTo(temp.data) == 0)
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
				root.colour = Colour.Black;
				return;
			}
			Node Y = null;
			Node X = root;
			while (X != null)
			{
				Y = X;
				if (newItem.data.CompareTo(X.data) < 0)
				{
					X = X.left;
				}
				else
				{
					X = X.right;
				}
			}
			newItem.parent = Y;
			if (Y == null)
			{
				root = newItem;
			}
			else if (newItem.data.CompareTo(Y.data) < 0)
			{
				Y.left = newItem;
			}
			else
			{
				Y.right = newItem;
			}
			newItem.left = null;
			newItem.right = null;
			newItem.colour = Colour.Red;//colour the new node red
			InsertionCheck(newItem);//call method to check for violations and fix
		}
		private void InOrderDisplay(List<T> inOrderList, Node current)
		{
			if (current != null)
			{
				InOrderDisplay(inOrderList, current.left);
				inOrderList.Add(current.data);
				InOrderDisplay(inOrderList, current.right);
			}
		}
		private void InsertionCheck(Node item)
		{
			//Checks Red-Black Tree properties
			while (item != root && item.parent.colour == Colour.Red)
			{
				/*We have a violation*/
				if (item.parent == item.parent.parent.left)
				{
					Node Y = item.parent.parent.right;
					if (Y != null && Y.colour == Colour.Red)//Case 1: uncle is red
					{
						item.parent.colour = Colour.Black;
						Y.colour = Colour.Black;
						item.parent.parent.colour = Colour.Red;
						item = item.parent.parent;
					}
					else //Case 2: uncle is black
					{
						if (item == item.parent.right)
						{
							item = item.parent;
							LeftRotate(item);
						}
						//Case 3: recolour & rotate
						item.parent.colour = Colour.Black;
						item.parent.parent.colour = Colour.Red;
						RightRotate(item.parent.parent);
					}

				}
				else
				{
					//mirror image of code above
					Node X = null;

					X = item.parent.parent.left;
					if (X != null && X.colour == Colour.Black)//Case 1
					{
						item.parent.colour = Colour.Red;
						X.colour = Colour.Red;
						item.parent.parent.colour = Colour.Black;
						item = item.parent.parent;
					}
					else //Case 2
					{
						if (item == item.parent.left)
						{
							item = item.parent;
							RightRotate(item);
						}
						//Case 3: recolour & rotate
						item.parent.colour = Colour.Black;
						item.parent.parent.colour = Colour.Red;
						LeftRotate(item.parent.parent);

					}

				}
				root.colour = Colour.Black;//re-colour the root black as necessary
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
			Node X = null;
			Node Y = null;

			if (item == null)
			{
				Console.WriteLine("Nothing to delete!");
				return;
			}
			if (item.left == null || item.right == null)
			{
				Y = item;
			}
			else
			{
				Y = TreeSuccessor(item);
			}
			if (Y.left != null)
			{
				X = Y.left;
			}
			else
			{
				X = Y.right;
			}
			if (X != null)
			{
				X.parent = Y;
			}
			if (Y.parent == null)
			{
				root = X;
			}
			else if (Y == Y.parent.left)
			{
				Y.parent.left = X;
			}
			else
			{
				Y.parent.left = X;
			}
			if (Y != item)
			{
				item.data = Y.data;
			}
			if (Y.colour == Colour.Black)
			{
				DeletionCheck(X);
			}

		}
		/// <summary>
		/// Checks the tree for any violations after deletion and performs a fix
		/// </summary>
		/// <param name="X"></param>
		private void DeletionCheck(Node X)
		{

			while (X != null && X != root && X.colour == Colour.Black)
			{
				if (X == X.parent.left)
				{
					Node W = X.parent.right;
					if (W.colour == Colour.Red)
					{
						W.colour = Colour.Black; //case 1
						X.parent.colour = Colour.Red; //case 1
						LeftRotate(X.parent); //case 1
						W = X.parent.right; //case 1
					}
					if (W.left.colour == Colour.Black && W.right.colour == Colour.Black)
					{
						W.colour = Colour.Red; //case 2
						X = X.parent; //case 2
					}
					else if (W.right.colour == Colour.Black)
					{
						W.left.colour = Colour.Black; //case 3
						W.colour = Colour.Red; //case 3
						RightRotate(W); //case 3
						W = X.parent.right; //case 3
					}
					W.colour = X.parent.colour; //case 4
					X.parent.colour = Colour.Black; //case 4
					W.right.colour = Colour.Black; //case 4
					LeftRotate(X.parent); //case 4
					X = root; //case 4
				}
				else //mirror code from above with "right" & "left" exchanged
				{
					Node W = X.parent.left;
					if (W.colour == Colour.Red)
					{
						W.colour = Colour.Black;
						X.parent.colour = Colour.Red;
						RightRotate(X.parent);
						W = X.parent.left;
					}
					if (W.right.colour == Colour.Black && W.left.colour == Colour.Black)
					{
						W.colour = Colour.Black;
						X = X.parent;
					}
					else if (W.left.colour == Colour.Black)
					{
						W.right.colour = Colour.Black;
						W.colour = Colour.Red;
						LeftRotate(W);
						W = X.parent.left;
					}
					W.colour = X.parent.colour;
					X.parent.colour = Colour.Black;
					W.left.colour = Colour.Black;
					RightRotate(X.parent);
					X = root;
				}
			}
			if (X != null)
				X.colour = Colour.Black;
		}
		private Node Minimum(Node X)
		{
			while (X.left.left != null)
			{
				X = X.left;
			}
			if (X.left.right != null)
			{
				X = X.left.right;
			}
			return X;
		}
		private Node TreeSuccessor(Node X)
		{
			if (X.left != null)
			{
				return Minimum(X);
			}
			else
			{
				Node Y = X.parent;
				while (Y != null && X == Y.right)
				{
					X = Y;
					Y = Y.parent;
				}
				return Y;
			}
		}
	}
}

