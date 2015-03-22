using System;

namespace DataStructures_Algorithms.Lists.LinkedList.Single
{
    public static class LinkedListRunner
    {
        /// <summary>
        /// Main runner method
        /// </summary>
        public static void Run()
        {
            var intList = new LinkedList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(String.Join(", ", intList));

            intList.Remove(5);

            Console.WriteLine(intList.ToString());

            var stringList = new LinkedList<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            Console.WriteLine(String.Join(", ", stringList));

            stringList.Remove("5");

            Console.WriteLine(stringList.ToString());
        }
    }
}
