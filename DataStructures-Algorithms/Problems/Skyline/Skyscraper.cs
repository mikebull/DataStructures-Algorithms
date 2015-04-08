using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Problems.Skyline
{
    public class Skyscraper
    {
        public int Left { get; set; }

        public int Height { get; set; }

        public int Right { get; set; }

        public Skyscraper(int left, int height, int right)
        {
            Left = left;
            Height = height;
            Right = right;
        }

        public Skyscraper(string input)
        {
            // Parse input into variables
            var strValues = input.Split(',');

            if(strValues.Count() != 3)
            {
                throw new ArgumentException("Invalid number of values passed");
            }

            var intValues = strValues
                .Select(Int32.Parse)
                .ToArray();

            Left = intValues[0];
            Height = intValues[1];
            Right = intValues[2];
        }
    }
}
