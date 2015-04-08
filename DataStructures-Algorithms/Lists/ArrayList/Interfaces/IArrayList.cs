using System;
using System.Collections;

namespace DataStructures_Algorithms.Lists.ArrayList.Interfaces
{
    public interface IArrayList<in T> : IEnumerable where T : IComparable
    {
        void Add(T value);

        void AddFirst(T node);

        void AddInside(T node, int index);

        void RemoveValue(T node);

        void RemoveFirst();

        void RemoveLast();

        void Remove(int index);

        int GetIndexByNode(T node);

        void Replace(T oldNode, T newNode);

        void ReplaceLast(T node);

        void ReplaceFirst(T node);

        void Empty();
    }
}