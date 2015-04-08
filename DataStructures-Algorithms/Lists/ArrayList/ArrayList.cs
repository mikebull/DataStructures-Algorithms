using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures_Algorithms.Lists.ArrayList.Interfaces;

namespace DataStructures_Algorithms.Lists.ArrayList
{
    public class ArrayList<T> : IArrayList<T> where T : IComparable
    {
        private T[] Items { get; set; }
        private int Count { get; set; }

        /// <summary>
        /// Handle constant time lookup
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return Items[index];
                }

                throw new IndexOutOfRangeException("index given larger than ArrayList size");
            }
            set
            {
                if (index < Count)
                {
                    Items[index] = value;
                }

                throw new IndexOutOfRangeException("index given larger than ArrayList size");
            }
        }

        /// <summary>
        /// Default constructor to create empty ArrayList
        /// </summary>
        public ArrayList()
        {
            Items = new T[0];
        }

        /// <summary>
        /// Default constructor to create ArrayList of given length
        /// </summary>
        /// <param name="length"></param>
        public ArrayList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Invalid length", "length");
            }

            Items = new T[length];
        }

        /// <summary>
        /// Default constructor to create ArrayList from another list
        /// </summary>
        /// <param name="list"></param>
        public ArrayList(ICollection<T> list)
        {
            var index = 0;

            Items = new T[list.Count];

            foreach (var item in list)
            {
                Items[index] = item;
                Count++;
                index++;
            }
        }

        /// <summary>
        /// Takes current backing array and extends it by 1
        /// </summary>
        public void ExtendArray()
        {
            int size = (Items.Length + 1);

            var tempArr = new T[size];

            Items.CopyTo(tempArr, 0);

            Items = tempArr;
        }

        /// <summary>
        /// Add node to end of ArrayList
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (Items.Length == Count)
            {
                ExtendArray();
            }

            Items[Count++] = value;
        }

        /// <summary>
        /// Copy to new array with larger index, and add first node in
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(T node)
        {
            const int sourceIndex = 0;
            const int destinationIndex = 1;

            if (Items.Length == Count)
            {
                ExtendArray();
            }

            // TODO: Implement Array.Copy
            Array.Copy(Items, sourceIndex, Items, destinationIndex, Count);

            Items[sourceIndex] = node;

            Count++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public void AddInside(T node, int index)
        {
            if (index > Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index larger than size of ArrayList");
            }

            if (Items.Length == Count)
            {
                ExtendArray();
            }

            var length = Count - index;
            
            Array.Copy(Items, index, Items, index + 1, length);

            Items[index] = node;

            Count++;
        }

        /// <summary>
        /// Remove a given node from ArrayList
        /// </summary>
        /// <param name="node"></param>
        public void RemoveValue(T node)
        {
            for (var i = 0; i < Count; i++)
            {
                var item = Items[i];

                if (!item.Equals(node)) continue;

                Remove(i);
                Count--;
            }
        }

        /// <summary>
        /// Remove first node from ArrayList
        /// </summary>
        public void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Remove(0);
        }

        /// <summary>
        /// Remove last node from ArrayList
        /// </summary>
        public void RemoveLast()
        {
            var index = Count - 1;

            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Remove(index);
        }

        /// <summary>
        /// Removes a node from a given index
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var length = Items.Length - 1;

            var dest = new T[length];

            if(index > 0)
            {
                Array.Copy(Items, 0, dest, 0, index);
            }

            if (index < length)
            {
                Array.Copy(Items, index + 1, dest, index, length - index);
            }

            Items = dest;

            // Reduce count
            Count--;

        }

        /// <summary>
        /// Return the index of a given node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetIndexByNode(T node)
        {
            for (var i = 0; i < Count; i++)
            {
                var item = Items[i];

                if (item.Equals(node))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Replace a node with another
        /// </summary>
        /// <param name="oldNode"></param>
        /// <param name="newNode"></param>
        public void Replace(T oldNode, T newNode)
        {
            // If the same, no need to do anything!
            if (oldNode.Equals(newNode)) return;

            for (var i = 0; i < Count; i++)
            {
                var node = Items[i];

                if (node.Equals(oldNode))
                {
                    Items[i] = newNode;
                }
            }
        }

        /// <summary>
        /// Replace last node with new node
        /// </summary>
        /// <param name="node"></param>
        public void ReplaceLast(T node)
        {
            var index = Count - 1;

            if(Count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Items[index] = node;
        }

        /// <summary>
        /// Replace first node with new node
        /// </summary>
        /// <param name="node"></param>
        public void ReplaceFirst(T node)
        {
            if (Count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Items[0] = node;
        }

        /// <summary>
        /// Empty tree
        /// </summary>
        public void Empty()
        {
            Count = 0;
        }

        /// <summary>
        /// Generic enumeration
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for(var i = 0; i < Count; i++)
            {
                yield return Items[i];
            }
        }

        /// <summary>
        /// Call generic enumeration
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        /// <summary>
        /// Return comma delimited list of items
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Join(", ", Items);
        }
    }
}
