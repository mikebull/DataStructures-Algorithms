using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Lists.SkipList
{
    public static class SkipListRunner
    {
        public static void Run()
        {
            Console.WriteLine("Runner for Skip List");

            var list = new SkipList<int> { 5, 10, 7, 7, 6 };

            bool seven = list.Contains(7);

            bool eight = list.Contains(9);

            list.Remove(7);

            seven = list.Contains(7);
        }
    }
}
