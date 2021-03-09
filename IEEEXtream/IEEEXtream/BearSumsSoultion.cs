using System;
using System.Collections.Generic;
using System.Linq;

class BearSumsSolution
{
    public static void BearSums()
    {
        int T = Convert.ToInt32(Console.ReadLine()); // Num of test case.
        for (int i = 0; i < T; i++)
        {
            bool noSolution = true; // flag.
            string[] S_E = Console.ReadLine().Split();
            int S = Convert.ToInt32(S_E[0]); // Expected sum.
            int E = Convert.ToInt32(S_E[1]); // Num of elements.
            string L_Input = Console.ReadLine();
            if (!L_Input.Equals(string.Empty) && E > 1)
            {
                List<int> L = L_Input.Split().Select(Int32.Parse).ToList<int>();
                HashSet<int> requiredNumbers = new HashSet<int>();

                foreach (int element in L)
                {
                    if (requiredNumbers.Contains(element)) // If exists - found the first complete pair.
                    {
                        int smaller = Math.Min(element, S - element);
                        int bigger = Math.Max(element, S - element);
                        Console.WriteLine(smaller + " " + bigger);
                        noSolution = false;
                        break;
                    }
                    else
                    {
                        requiredNumbers.Add(S - element); // Add to list the required number for the sum.
                    }
                }
            }
            if (noSolution == true)
            {
                Console.WriteLine("!OK");
            }
            noSolution = true;
        }
    }
}