namespace DataStructures_Algorithms.Lists.SkipList.Interfaces
{
    public interface ISkipList<in T>
    {
        void Add(T value);

        bool Contains(T value);

        void Remove(T value);
    }
}