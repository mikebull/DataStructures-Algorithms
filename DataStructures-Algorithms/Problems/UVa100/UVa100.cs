using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Problems.UVa100
{
    public static class UVa100
    {
        /// <summary>
        /// Compute the maximum cycle length between 
        /// and including i and j, and return string with 
        /// i, i, and the max value
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static string Compute(int i, int j)
        {
            var max = 0;

            for (var x = i; x <= j; x++)
            {
                var cycleLength = ComputeCycleLength(x);

                if (cycleLength > max)
                {
                    max = cycleLength;
                }
            }

            return String.Format("{0} {1} {2}", i, j, max);
        }

        /// <summary>
        /// Computes the number of cycle lengths made
        /// during the run of this algorithm
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int ComputeCycleLength(int n)
        {
            var cycles = new List<int> { n };

            while (n != 1)
            {
                if (n % 2 != 0)
                {
                    n = (3 * n) + 1;
                }
                else
                {
                    n = n / 2;
                }

                cycles.Add(n);
            }

            return cycles.Count;
        }
    }
}
