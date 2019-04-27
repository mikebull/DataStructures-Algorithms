using System;

namespace Hash_Tables
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashTable hash = new HashTable();

            hash.Add(0, "Zero");
            hash.Add(1, "One");
            hash.Add(2, "Two");
            hash.Add(3, "Three");
            hash.Add(4, "Four");
            hash.Add(4, "Five");

            Console.WriteLine($"Value 3 is {hash.Get(3)}");

            hash.Remove(3);

            Console.WriteLine(hash.ToString());
        }
    }
}
