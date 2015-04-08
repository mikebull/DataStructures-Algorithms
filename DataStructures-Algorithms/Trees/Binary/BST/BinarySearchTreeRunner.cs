using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Trees.Binary.BST
{
    public static class BinarySearchTreeRunner
    {
        public static void Run()
        {
            var tree = new BinarySearchTree<int> { 56, 12, 69, 27, 16 };

            var isBst = tree.IsBinarySearchTree();

            tree.Contains(69);

            tree.Contains(27);

            tree.Contains(11);

            tree.Remove(12);

            var max = tree.GetMaxValue();

            tree.Contains(69);
        }
    }
}
