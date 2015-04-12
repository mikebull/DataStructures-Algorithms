using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures_Algorithms.Problems.UVa105
{
    public static class Skyline
    {
        public static string BruteForceSilhouette(Skyscraper[] skyscrapers)
        {
            // Get maximum right coordinate value from skyscraper collection
            var max = skyscrapers
                .Select(skyscraper => skyscraper.Right)
                .Concat(new[] { 0 })
                .Max();

            var heights = new int[max + 2];

            // Calculate heights required for skyscrapers
            foreach(var skyscraper in skyscrapers)
            {
                for(var i = skyscraper.Left; i < skyscraper.Right; i++)
                {
                    heights[i] = Math.Max(heights[i], skyscraper.Height);
                }
            }

            var silhouettes = new List<int>();

            for(var i = 0; i < heights.Length - 1; i++)
            {
                if (heights[i] != heights[i + 1])
                {
                    silhouettes.Add(i + 1);
                    silhouettes.Add(heights[i + 1]);
                }
            }

            return String.Join(", ", silhouettes);
        }
    }
}
