namespace DataStructures_Algorithms.Lists.LinkedList.Single.Interfaces
{
    public interface ILinkedList<in T>
    {
        void Add(T value);

        void Remove(T value);
    }
}