using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataStructures_Algorithms.Problems.UVa105
{
    public static class Skyline
    {
        public static string SweepLineSilhouette(Skyscraper[] skyscrapers)
        {
            var events = new Dictionary<int, List<Event>>();

            foreach (var skyscraper in skyscrapers.OrderBy(x => x.Left))
            {
                if (!events.ContainsKey(skyscraper.Left))
                {
                    events.Add(skyscraper.Left, new List<Event>());
                }

                if (!events.ContainsKey(skyscraper.Right))
                {
                    events.Add(skyscraper.Right, new List<Event>());
                }

                events[skyscraper.Left].Add(new Event { Skyscraper = skyscraper, IsAdd = true });
                events[skyscraper.Right].Add(new Event { Skyscraper = skyscraper, IsAdd = false });
            }

            var height = 0;
            var heights = new HashSet<Skyscraper>();
            var output = new List<int>();

            foreach (var position in events.OrderBy(x => x.Key))
            {
                foreach (var skyscraperEvent in position.Value)
                {
                    if (skyscraperEvent.IsAdd)
                    {
                        heights.Add(skyscraperEvent.Skyscraper);
                    }
                    else
                    {
                        heights.Remove(skyscraperEvent.Skyscraper);
                    }
                }

                var max = 0;

                if (heights.Any())
                {
                    max = heights.Max(x => x.Height);
                }

                if (height == max) continue;

                output.Add(position.Key);
                output.Add(max);

                height = max;
            }

            return String.Join(", ", output);
        }

        public static string BruteForceSilhouette(Skyscraper[] skyscrapers)
        {
            // Get maximum right coordinate value from skyscraper collection
            var max = skyscrapers
                .Select(skyscraper => skyscraper.Right)
                .Concat(new[] { 0 })
                .Max();

            var heights = new int[max + 2];

            // Calculate heights required for skyscrapers
            foreach (var skyscraper in skyscrapers)
            {
                for (var i = skyscraper.Left; i < skyscraper.Right; i++)
                {
                    heights[i] = Math.Max(heights[i], skyscraper.Height);
                }
            }

            var silhouettes = new List<int>();

            for (var i = 0; i < heights.Length - 1; i++)
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
