using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Abstract.Stack.Interfaces;

namespace DataStructures_Algorithms.Abstract.Stack
{
    public class Stack<T> : IStack<T> where T : IComparable
    {
        private T[] Nodes { get; set; }

        public int Count { get; set; }

        private const int Capacity = 10;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Stack()
        {
            InstantiateNodes();
        }

        /// <summary>
        /// Clear existing nodes by instantiating new
        /// inner array
        /// </summary>
        private void InstantiateNodes()
        {
            Nodes = new T[Capacity];
        }

        /// <summary>
        /// Clear count to empty node
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            InstantiateNodes();

            return Count == 0;
        }

        /// <summary>
        /// Add node to top of stack
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (Count == Nodes.Length)
            {
                IncreaseCapacity(Nodes.Length * 2);
            }

            Nodes[Count++] = item;
        }

        /// <summary>
        /// Take node from top of stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new StackOverflowException("Cannot remove node from empty stack");
            }

            var node = Nodes[--Count];

            return node;
        }

        /// <summary>
        /// Override method to generate string of all
        /// assigned nodes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var nodes = new T[Count];

            Array.Copy(Nodes, nodes, Count);

            return String.Join(", ", nodes);
        }

        /// <summary>
        /// Helper method to increase the capacity of the 
        /// given 
        /// </summary>
        /// <param name="capacity"></param>
        private void IncreaseCapacity(int capacity)
        {
            var newNodes = new T[capacity];

            Array.Copy(Nodes, newNodes, capacity);
        } 
    }
}
