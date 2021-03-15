using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Star
{
    public int S { get; set; }
    public int F { get; set; }
    public int D { get; set; }
    public int preIndex { get; set; }
}

class TelescopeSchedulingSolution
{
    public static void TelescopeScheduling()
    {
        int N = Convert.ToInt32(Console.ReadLine());
        List<Star> stars = new List<Star>();
        stars.Add(new Star()); // Init first index with zero desirability.
        for (int input = 0; input < N; input++) // Get input.
        {
            string[] InputStar = Console.ReadLine().Split();
            Star star = new Star();
            star.S = Convert.ToInt32(InputStar[0]);
            star.F = Convert.ToInt32(InputStar[1]);
            star.D = Convert.ToInt32(InputStar[2]);
            stars.Add(star);
        }

        stars.Sort((x, y) => (x.F).CompareTo(y.F)); // Sort stars by final time.

        int i = 1, j = 1;
        while (i <= N)
        {
            j = 1;
            while (j < i)
            {
                if (stars[j].F < stars[i].S)
                {
                    stars[i].preIndex = j; // Save the last index whos not conflict with.
                }
                j++;
            }
            i++;
        }

        for (int s = 1; s <= N; s++) // Update the desirability of each index by the maximum
        {                            // between the preIndex not-conflict D + corrent D, and the i-1 D.
            stars[s].D = Math.Max(stars[s - 1].D, stars[stars[s].preIndex].D + stars[s].D);
        }
        Console.WriteLine(stars[N].D);
    }
}

