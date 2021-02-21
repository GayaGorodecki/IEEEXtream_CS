using System;
using System.Collections.Generic;
using System.IO;

class DogWalkingSolution
{
    static void Main(string[] args)
    {
        int numOfTestCases = Convert.ToInt32(Console.ReadLine()); // Get num of tast cases for the loop

        for (int tc = 0; tc < numOfTestCases; tc++)
        {
            string[] dogsAndWalkers = Console.ReadLine().Split();
            int N = Convert.ToInt32(dogsAndWalkers[0]); // Get num of dogs
            int K = Convert.ToInt32(dogsAndWalkers[1]); // Get num of dog walkers

            List<int> DogSizes = new List<int>();
            for (int ds = 0; ds < N; ds++) // Get dog sizes
            {
                DogSizes.Add(Convert.ToInt32(Console.ReadLine()));
            }
            DogSizes.Sort(); // sort dog sizes list

            List<int> Ranges = new List<int>();
            for (int r = 0; r < DogSizes.Count - 1; r++) // Calc ranges between all dog sizes
            {
                Ranges.Add(DogSizes[r + 1] - DogSizes[r]);
            }
            Ranges.Sort(); // sort ranges list

            int sumOfDiffs = 0;
            int rangesSize = Ranges.Count - 1;
            for (int dw = 0; dw < K - 1; dw++) // Choose where to divide the dog sizes into k groups.
            {
                sumOfDiffs += Ranges[rangesSize];
                rangesSize--;
            }

            int SumOfRanges = (DogSizes[N - 1] - DogSizes[0]); // If k==1: the range is between max to min dog size.
            if (K != 1)
            {
                SumOfRanges -= sumOfDiffs; // If k!=1: Reduce the sum of ranges with the sum of diffs that cancels because of the split.
            }

            Console.WriteLine(SumOfRanges);
        }
    }
}