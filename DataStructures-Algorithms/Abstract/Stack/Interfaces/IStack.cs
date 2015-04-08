namespace DataStructures_Algorithms.Abstract.Stack.Interfaces
{
    public interface IStack<T>
    {
        bool Empty();

        void Push(T item);

        T Pop();
    }
}