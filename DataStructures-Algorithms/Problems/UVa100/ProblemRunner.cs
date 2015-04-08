using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Problems.UVa100
{
    public static class ProblemRunner
    {
        public static void Run()
        {
            Console.WriteLine(UVa100.Compute(1, 10));
            Console.WriteLine(UVa100.Compute(100, 200));
            Console.WriteLine(UVa100.Compute(201, 210));
            Console.WriteLine(UVa100.Compute(900, 1000));
            Console.WriteLine(UVa100.Compute(1000, 900));
            Console.WriteLine(UVa100.Compute(999999, 999990));
        }
    }
}
