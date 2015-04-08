using System.Collections;
using System.Collections.Generic;

namespace DataStructures_Algorithms.Trees.Binary.BST.Interfaces
{
    public interface IBinarySearchTree<T> : IEnumerable
    {
        void Add(T value);

        bool Contains(T value);

        bool Remove(T value);

        bool IsBinarySearchTree();

        T GetMaxValue();

        T GetMinValue();

        IEnumerable<T> InOrderTraversal();

        IEnumerable<T> PreOrderTraversal();

        IEnumerable<T> PostOrderTraversal();
    }
}