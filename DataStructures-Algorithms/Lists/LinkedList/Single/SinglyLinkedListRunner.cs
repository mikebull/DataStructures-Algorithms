using System;

namespace DataStructures_Algorithms.Lists.LinkedList.Single
{
    public static class SinglyLinkedListRunner
    {
        /// <summary>
        /// Main runner method
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Runner for Singly Linked List");

            InstantiateIntegrerList();
            InstantiateStringList();
        }

        /// <summary>
        /// Build linked list of integrers and test add/remove/traverse
        /// </summary>
        private static void InstantiateIntegrerList()
        {
            var intList = new LinkedList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(String.Join(", ", intList));

            intList.Remove(5);

            Console.WriteLine(intList + "\r\n");
        }

        /// <summary>
        /// Build linked list of strings and test add/remove/traverse
        /// </summary>
        private static void InstantiateStringList()
        {
            var stringList = new LinkedList<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            Console.WriteLine(String.Join(", ", stringList));

            stringList.Remove("5");

            Console.WriteLine(stringList + "\r\n");
        }
    }
}
