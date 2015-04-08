using System.Collections;

namespace DataStructures_Algorithms.Lists.LinkedList.Single.Interfaces
{
    public interface ILinkedList<in T> : IEnumerable
    {
        void Add(T value);

        void Remove(T value);
    }
}