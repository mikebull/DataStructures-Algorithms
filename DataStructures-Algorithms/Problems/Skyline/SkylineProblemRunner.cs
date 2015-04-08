using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Problems.Skyline
{
    public static class SkylineProblemRunner
    {
        public static void Run()
        {
            var skyscrapers = new[]
            {
                new Skyscraper("1,11,5"),
                new Skyscraper("2,6,7"),
                new Skyscraper("3,13,9"),
                new Skyscraper("12,7,16"),
                new Skyscraper("14,3,25"),
                new Skyscraper("19,18,22"),
                new Skyscraper("23,13,29"),
                new Skyscraper("24,4,28")
            };

            var output = Skyline.GenerateSilhouetteCoordinates(skyscrapers);
        }
    }
}
