using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Lists.SkipList
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; set; }

        public Node<T>[] Next { get; set; }

        public int Level { get { return Next.Length; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="level"></param>
        /// <param name="value"></param>
        public Node(int level, T value)
        {
            Value = value;
            Next = new Node<T>[level + 1];
        }
    }
}
