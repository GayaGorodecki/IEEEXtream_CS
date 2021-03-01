using System;
using System.Collections.Generic;
using System.IO;

class MagicSquareSolution
{
    public static void MagicSquare()
    {
        int squareSize = Convert.ToInt32(Console.ReadLine());
        int sumOfdiagonal = 0, sumOfAntiDiagonal = 0;
        List<int> LinesNotEqual = new List<int>();

        if (squareSize != 1)
        {
            int num = 0;
            int[] sumOfRows = new int[squareSize];
            int[] sumOfCols = new int[squareSize];

            for (int i = 0; i < squareSize; i++) // Get input and calc sums
            {
                string[] inputSquareLine = Console.ReadLine().Split();
                for (int j = 0; j < squareSize; j++)
                {
                    num = Convert.ToInt32(inputSquareLine[j]);
                    sumOfRows[i] += num;
                    sumOfCols[j] += num;
                }
                sumOfdiagonal += Convert.ToInt32(inputSquareLine[i]);
                sumOfAntiDiagonal += Convert.ToInt32(inputSquareLine[(squareSize - 1 - i)]);
            }

            for (int line = 1; line <= squareSize; line++)
            {
                if (sumOfRows[line - 1] != sumOfdiagonal) // Check which rows do not sum up to the sum of the main diagonal
                {
                    LinesNotEqual.Add(line); // Add index to list
                }
                if (sumOfCols[line - 1] != sumOfdiagonal) // Check which cols do not sum up to the sum of the main diagonal
                {
                    LinesNotEqual.Add(-line);
                }
            }

            if (sumOfAntiDiagonal != sumOfdiagonal)
            {
                LinesNotEqual.Add(0);
            }
        }

        Console.WriteLine(LinesNotEqual.Count);
        if (LinesNotEqual.Count != 0) // If not magic square
        {
            LinesNotEqual.Sort((a, b) => (a.CompareTo(b))); // Sort in incremental order
            foreach (int line in LinesNotEqual)
            {
                Console.WriteLine(line);
            }
        }
    }
}