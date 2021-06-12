using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RumourSolution
{
    public static void Rumour()
    {
        int q = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < q; i++)
        {
            String[] query = Console.ReadLine().Split(); // Get input.
            long a = Convert.ToInt64(query[0]);
            long b = Convert.ToInt64(query[1]);

            int minimumDistance = 0;
            long minNum = Math.Min(a, b), maxNum = Math.Max(a, b), newNum; // Save min and max num.

            // While the numbers doesn't eauql -> 
            // Go up with the updated max num and count 1 step each time.
            while (minNum != maxNum)
            {
                if (maxNum % 2 == 0) // If num is even -> The father will be num/2
                {
                    newNum = maxNum / 2;
                }
                else
                { // If num is odd -> The father will be (num-1)/2
                    newNum = (maxNum - 1) / 2;
                }

                // Add the step.
                minimumDistance += 1;

                // Update min and max.
                maxNum = Math.Max(minNum, newNum);
                minNum = Math.Min(minNum, newNum);
            }

            Console.WriteLine(minimumDistance);
        }
    }
}