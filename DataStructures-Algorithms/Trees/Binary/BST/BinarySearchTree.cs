using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Trees.Binary.BST.Interfaces;

namespace DataStructures_Algorithms.Trees.Binary.BST
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private Node<T> Root { get; set; }

        /// <summary>
        /// Starting from root, go down tree and add value
        /// as leaf node
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Add(Root, value);
        }

        /// <summary>
        /// Go down tree and add value as leaf node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void Add(Node<T> node, T value)
        {
            if (node == null)
            {
                Root = new Node<T>(value);
                return;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                    return;
                }

                Add(node.Left, value);
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                    return;
                }

                Add(node.Right, value);
            }
        }

        /// <summary>
        /// From root, recursively go down tree and 
        /// split children until node is found
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return Contains(Root, value);
        }

        /// <summary>
        /// Recursively go down tree and split children until
        /// node is found
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Node<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.Equals(value))
            {
                return true;
            }

            if (value.CompareTo(node.Value) <= 0)
            {
                return Contains(node.Left, value);
            }

            return Contains(node.Right, value);
        }

        /// <summary>
        /// Starting at root, remove node once found
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            var node = Remove(Root, value);

            return node != null;
        }

        /// <summary>
        /// Go down tree until node is found
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> Remove(Node<T> node, T value)
        {
            if (node == null) return null;

            if (value.CompareTo(node.Value) < 0)
            {
                // Remove node and replace with child

                node.Left = Remove(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                // Remove node and replace with child

                node.Right = Remove(node.Right, value);
            } 
            else if (node.Left != null && node.Right != null)
            {
                // Grab in-order successor, change node value to it, 
                // and recursively remove from right

                node.Value = GetMinValue(node.Right);
                node.Right = Remove(node.Right, node.Value);
            } else
            {
                // This node has no children

                return node.Right ?? node.Left;
            }

            return node;
        }

        /// <summary>
        /// Check validity of BST
        /// </summary>
        /// <returns></returns>
        public bool IsBinarySearchTree()
        {
            var min = GetMinValue();
            var max = GetMaxValue();

            return IsBinarySearchTree(Root, min, max);
        }

        /// <summary>
        /// Check validity of a subset of the BST using 
        /// min/max values
        /// </summary>
        /// <param name="node"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public bool IsBinarySearchTree(Node<T> node, T min, T max)
        {
            if (node == null) return true;

            if (node.Value.CompareTo(min) < 0 || node.Value.CompareTo(max) > 0)
            {
                return false;
            }

            return IsBinarySearchTree(node.Left, min, node.Value) && IsBinarySearchTree(node.Right, node.Value, max);
        }

        /// <summary>
        /// Starting from the root, travel right down the tree
        /// until last leaf value found
        /// </summary>
        /// <returns></returns>
        public T GetMaxValue()
        {
            return GetMaxValue(Root);
        }

        /// <summary>
        /// Travel right down the tree until last
        /// leaf value found
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public T GetMaxValue(Node<T> node)
        {
            return node.Right == null ? node.Value : GetMaxValue(node.Right);
        }

        /// <summary>
        /// Starting from the root, travel left down the tree 
        /// until last leaf value found
        /// </summary>
        /// <returns></returns>
        public T GetMinValue()
        {
            return GetMinValue(Root);
        }

        /// <summary>
        /// Travel left down the tree until last
        /// leaf value found
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public T GetMinValue(Node<T> node)
        {
            return node.Left == null ? node.Value : GetMinValue(node.Left);
        }

        /// <summary>
        /// Starting from root node, traverse BST and 
        /// return nodes in order
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(Root);
        }

        /// <summary>
        /// Traverse BST and return nodes in order
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> InOrderTraversal(Node<T> node)
        {
            if (node == null) yield break;

            foreach (var value in InOrderTraversal(node.Left))
            {
                yield return value;
            }

            yield return node.Value;

            foreach (var value in InOrderTraversal(node.Right))
            {
                yield return value;
            }
        }

        /// <summary>
        /// Perform pre-order depth-first search on tree
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrderTraversal(Root);
        }

        /// <summary>
        /// Perform pre-order depth-first search on tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> PreOrderTraversal(Node<T> node)
        {
            if (node == null) yield break;

            yield return node.Value;

            foreach (var value in PreOrderTraversal(node.Left))
            {
                yield return value;
            }

            foreach (var value in PreOrderTraversal(node.Right))
            {
                yield return value;
            }
        }

        /// <summary>
        /// Perform post-order depth-first search on tree
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PostOrderTraversal()
        {
            return PostOrderTraversal(Root);
        }

        /// <summary>
        /// Perform post-order depth-first search on tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> PostOrderTraversal(Node<T> node)
        {
            if (node == null) yield break;

            foreach (var value in PreOrderTraversal(node.Left))
            {
                yield return value;
            }

            foreach (var value in PreOrderTraversal(node.Right))
            {
                yield return value;
            }

            yield return node.Value;
        }

        /// <summary>
        /// Override default ToString to render nodes in order
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var values = InOrderTraversal(Root);

            return String.Join(", ", values);
        }

        /// <summary>
        /// Generic enumeration
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var node = Root;

            var list = InOrderTraversal(node);

            return list.GetEnumerator();
        }

        /// <summary>
        /// Call generic enumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
