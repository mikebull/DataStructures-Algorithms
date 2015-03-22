using System;

namespace DataStructures_Algorithms.Lists.LinkedList.Single
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            Value = value;
            Next = null;
        }

        /// <summary>
        /// ToString value override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
