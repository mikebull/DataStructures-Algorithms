using System;
using System.Collections;

namespace DataStructures_Algorithms.Lists.LinkedList.Double.Interfaces
{
    public interface ILinkedList<T> : IEnumerable where T : IComparable
    {
        void Add(T value);

        void AddAfter(T value, Node<T> after);

        void AddBefore(T value, Node<T> before);

        void AddAtBeginning(T value);

        void AddAtEnd(T value);

        void Remove(T value);

        Node<T> Get(T value);
    }
}