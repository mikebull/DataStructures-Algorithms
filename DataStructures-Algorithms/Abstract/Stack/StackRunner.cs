using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Abstract.Stack
{
    public static class StackRunner
    {
        public static void Run()
        {
            var stack = new Stack<string>();

            stack.Push("One");
            stack.Push("Two");
            stack.Push("Three");

            var count = stack.Count;

            var three = stack.Pop();
            var two = stack.Pop();
            var one = stack.Pop();

            stack.Push("Test");

            stack.Empty();
        }
    }
}
