using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Lists.LinkedList.Double.Interfaces;

namespace DataStructures_Algorithms.Lists.LinkedList.Double
{
    public class LinkedList<T>: ILinkedList<T>, IEnumerable where T : IComparable
    {
        private Node<T> Head { get; set; }

        private Node<T> Tail { get; set; }

        private Node<T> Current { get; set; } 

        /// <summary>
        /// Initialise linked list with empty head and tail
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Add a new node to the list
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            var newNode = new Node<T>(value);

            // If no head or tail, new node becomes both
            if (Head == null && Tail == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Current.Next = newNode;
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }

            // Current node always newest created node
            Current = newNode;
        }

        /// <summary>
        /// Loop through nodes, and remove node if value found.
        /// Once found, ensure that next node is set to continue
        /// list
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            var node = Head;

            if (node.Value.Equals(value))
            {
                Head = node.Next;
            }

            while (node != null)
            {
                if (node.Next.Value.Equals(value))
                {
                    node.Next = node.Next.Next;
                    node.Next.Prev = node;
                    return;
                }
                node = node.Next;
            }
        }

        /// <summary>
        /// Build collection of all nodes, and return as
        /// comma-delimited string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Head == null)
            {
                return String.Empty;
            }

            var list = new List<T>();

            var currentItem = Head;
            list.Add(currentItem.Value);

            while (currentItem.Next != null)
            {
                list.Add(currentItem.Next.Value);
                currentItem = currentItem.Next;
            }

            return String.Join(", ", list);
        }

        /// <summary>
        /// Generic enumeration
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
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
