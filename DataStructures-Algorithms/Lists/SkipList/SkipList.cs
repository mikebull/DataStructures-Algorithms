using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Lists.SkipList.Interfaces;

namespace DataStructures_Algorithms.Lists.SkipList
{
    public class SkipList<T> : ISkipList<T>, IEnumerable<T> where T : IComparable<T>, IComparable
    {
        private Node<T> Head { get; set; }

        private int Level { get; set; }

        private readonly Random _random;

        private double Probability { get; set; }

        private int MaxLevel { get; set; }

        /// <summary>
        /// Default constructor to set levels, 
        /// probability, and the maxinum level
        /// </summary>
        public SkipList()
        {
            _random = new Random();

            InitialiseVariables();
        }

        /// <summary>
        /// Initialise values
        /// </summary>
        public void InitialiseVariables()
        {
            Level = 0;
            Probability = 0.50;
            MaxLevel = 30;
        }

        /// <summary>
        /// Perform search while maintaining array of 
        /// pointers of nodes that require updating
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            var node = Head;

            if(node == null)
            {
                // First value, so add head and return
                Head = new Node<T>(MaxLevel, value);
                return;
            }

            var update = new Node<T>[MaxLevel + 1];

            for (int i = Level; i >= 0; i--)
            {
                while (node.Next[i] != null && node.Next[i].Value.CompareTo(value) < 0)
                {
                    node = node.Next[i];
                }

                update[i] = node;
            }

            node = node.Next[0];

            if (node != null && node.Value.Equals(value)) return;

            int lvl = GenerateRandomLevel();

            if (lvl > Level)
            {
                for (int i = Level + 1; i <= lvl; i++)
                {
                    update[i] = Head;
                }

                Level = lvl;
            }

            // Point forward point in node to what nodes 
            // in update vector are pointing at, and update 
            // nodes in update vector to point to node
            node = new Node<T>(lvl, value);

            for (int i = 0; i <= lvl; i++)
            {
                node.Next[i] = update[i].Next[i];
                update[i].Next[i] = node;
            }
        }

        /// <summary>
        /// Return true if value is in skip list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            var node = Head;

            for (int i = Level; i >= 0; i--)
            {
                while (node.Next[i] != null && node.Next[i].Value.CompareTo(value) < 0)
                {
                    node = node.Next[i];
                }
            }

            node = node.Next[0];
            
            return node != null && node.Value.Equals(value);
        }

        /// <summary>
        /// Remove 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Remove(T value)
        {
            var node = Head;

            var update = new Node<T>[MaxLevel + 1];

            for(int i = Level; i >= 0; i--)
            {
                while(node.Next[i] != null && node.Next[i].Value.CompareTo(value) < 0)
                {
                    node = node.Next[i];
                }

                update[i] = node;
            }

            node = node.Next[0];

            if (!node.Value.Equals(value)) return;

            for(int i = 0; i <= Level; i++)
            {
                if(update[i].Next[i] != node)
                {
                    break;
                }

                update[i].Next[i] = node.Next[i];
            }

            while(node.Next[Level] == null && Level > 0)
            {
                Level--;
            }
        }

        /// <summary>
        /// Return enumerable collection of nodes
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;

                node = node.Next[0];
            }
        }

        /// <summary>
        /// Grab enumeration of nodes and return 
        /// comma-delimited string of values
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var values = GetEnumerator();

            return String.Join(",", values);
        }

        /// <summary>
        /// Override enumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns a random level between zero and the max level using a 
        /// probability distribution.
        /// </summary>
        /// <returns></returns>
        private int GenerateRandomLevel()
        {
            int level = 1;
            while (_random.NextDouble() < Probability && level < MaxLevel)
            {
                level++;
            }

            return level;
        }
    }
}
