using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures_Algorithms.Lists.LinkedList.Double.Interfaces;

namespace DataStructures_Algorithms.Lists.LinkedList.Double
{
    public class LinkedList<T> : ILinkedList<T>, IEnumerable where T : IComparable
    {
        private Node<T> Head { get; set; }

        private Node<T> Tail { get; set; }

        private int Count { get; set; }

        /// <summary>
        /// Initialise linked list with empty head and tail
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
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

        /// <summary>
        /// Initial add method
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (Tail == null)
            {
                Tail = new Node<T>(value);
                Count++;
            }
            else
            {
                AddAtEnd(value);
            }
        }

        /// <summary>
        /// Add node after another node
        /// </summary>
        /// <param name="value"></param>
        /// <param name="after"></param>
        public void AddAfter(T value, Node<T> after)
        {
            if (after == null)
            {
                throw new NullReferenceException();
            }

            var newNode = new Node<T>(value);
            if (after == Tail)
            {
                newNode.Prev = after;
                after.Next = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = after.Next;
                after.Next.Prev = newNode;
                newNode.Prev = after;
                after.Next = newNode;
            }

            if (Head != null) return;

            Head = after;
            Head.Next = newNode;

            Count++;
        }

        /// <summary>
        /// Add node before other node
        /// </summary>
        /// <param name="value"></param>
        /// <param name="before"></param>
        public void AddBefore(T value, Node<T> before)
        {
            if (before == null)
            {
                throw new NullReferenceException();
            }

            var newNode = new Node<T>(value);
            if (Head == before)
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
                Count++;
            }
            else
            {
                AddAfter(value, before.Prev);
            }
        }

        /// <summary>
        /// Add value to beginning of list
        /// </summary>
        /// <param name="value"></param>
        public void AddAtBeginning(T value)
        {
            AddAfter(value, Head);
        }

        /// <summary>
        /// Add value to end of list
        /// </summary>
        /// <param name="value"></param>
        public void AddAtEnd(T value)
        {
            AddAfter(value, Tail);
        }

        /// <summary>
        /// Loop through collection to get node
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> Get(T value)
        {
            var node = Head;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }

                node = node.Next;
            }

            return null;
        }

        /// <summary>
        /// Grab node and alter next/prev pointers based on positon
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            var currentItem = Get(value);
            
            if (currentItem == null) return;

            var prevItem = currentItem.Prev;

            Count--;

            if (Count == 0)
            {
                // Current node is head
                Head = null;
            }
            else if (prevItem == null)
            {
                // Current node is head
                Head = currentItem.Next;
                Head.Prev = null;
            }
            else if (currentItem == Tail)
            {
                // Current noe is at end
                currentItem.Prev.Next = null;
                Tail = currentItem.Prev;
            }
            else
            {
                // Current node is in middle of list
                currentItem.Prev.Next = currentItem.Next;
                currentItem.Next.Prev = currentItem.Prev;
            }
        }
    }
}
