using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Lists.LinkedList.Double
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; set; }

        public Node<T> Prev { get; set; }

        public Node<T> Next { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            Value = value;
            Prev = null;
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
