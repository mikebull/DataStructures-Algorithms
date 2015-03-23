using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Lists.ArrayList
{
    public static class ArrayListRunner
    {
        public static void Run()
        {
            Console.WriteLine("Runner for Array List");

            var arrayList = new ArrayList<int> { 1, 2, 4, 5 };

            arrayList.AddInside(3, 2);

            arrayList.ReplaceFirst(10);

            arrayList.ReplaceLast(50);

            // Should display "10, 2, 3, 4, 50"
            Console.WriteLine(arrayList.ToString());

            var newArrayList = new ArrayList<int>(new[] { 1, 2, 3, 4, 5, 80 });

            newArrayList.AddFirst(0);

            newArrayList.RemoveLast();

            newArrayList.Replace(3, 300);

            // Should display "0, 1, 2, 300, 4, 5"
            Console.WriteLine(newArrayList.ToString());
        }
    }
}
