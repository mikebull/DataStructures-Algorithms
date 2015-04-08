using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Trees.Binary.BST
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; } 

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            Value = value;
        }
    }
}
