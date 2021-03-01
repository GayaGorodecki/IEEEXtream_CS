using System;
using System.Collections.Generic;
using System.IO;

class PaintersDilemmaSolution
{
    public static void PaintersDilemma()
    {
        int t = Convert.ToInt32(Console.ReadLine()); // number of scenarios

        for (int i = 0; i < t; i++)
        {
            int CountChanges = 1; // minimum is 1
            int N = Convert.ToInt32(Console.ReadLine()); // length of the sequence of colors

            if (N > 1) // -> else only one brush needed
            {
                string[] C = Console.ReadLine().Split(); // the sequence of colors
                int j = 0;
                string firstBrush = C[j];
                j++;
                while (j < N) // loop while the first color not changed
                {
                    if (!(C[j].Equals(firstBrush)))
                    {
                        break;
                    }
                    j++;
                }

                if (j < N)
                {
                    string secondBrush = C[j];
                    CountChanges++;

                    int firstBrushNum = checkNextSameNum(firstBrush, j, C); // update index for next same color
                    int secondBrushNum = checkNextSameNum(secondBrush, j, C);

                    j++;
                    while (j < N)
                    {
                        if (firstBrushNum.Equals(secondBrushNum)) // if there is no next same color for both
                        {
                            if (C[j - 1].Equals(firstBrush)) // use other brush from the last color
                            {
                                secondBrush = C[j];
                                CountChanges++;
                                secondBrushNum = checkNextSameNum(secondBrush, j, C);

                                if (!(firstBrushNum.Equals(N + 1))) // if there is more same color
                                {
                                    firstBrushNum--; // update index
                                }
                            }
                            else if (C[j - 1].Equals(secondBrush))
                            {
                                firstBrush = C[j];
                                CountChanges++;
                                firstBrushNum = checkNextSameNum(firstBrush, j, C);

                                if (!(secondBrushNum.Equals(N + 1)))
                                {
                                    secondBrushNum--;
                                }
                            }
                        }
                        else if (firstBrushNum < secondBrushNum) // if the firstBrush next same color is closer
                        {
                            if (firstBrushNum.Equals(0)) // got to the next same color - update and move on
                            {
                                firstBrushNum = checkNextSameNum(firstBrush, j, C);

                                if (!(secondBrushNum.Equals(N + 1)))
                                {
                                    secondBrushNum--;
                                }
                            }
                            else // change the further
                            {
                                secondBrush = C[j];
                                CountChanges++;
                                if (!(firstBrushNum.Equals(N + 1)))
                                {
                                    firstBrushNum--;
                                }

                                secondBrushNum = checkNextSameNum(secondBrush, j, C);
                            }
                        }
                        else if (secondBrushNum < firstBrushNum) // if the secondBrush next same color is closer
                        {
                            if (secondBrushNum.Equals(0)) // got to the next same color - update and move on
                            {
                                secondBrushNum = checkNextSameNum(secondBrush, j, C);

                                if (!(firstBrushNum.Equals(N + 1)))
                                {
                                    firstBrushNum--;
                                }
                            }
                            else // change the further
                            {
                                firstBrush = C[j];
                                CountChanges++;
                                if (!(secondBrushNum.Equals(N + 1)))
                                {
                                    secondBrushNum--;
                                }

                                firstBrushNum = checkNextSameNum(firstBrush, j, C);
                            }
                        }

                        j++;
                    }
                }
            }

            Console.WriteLine(CountChanges);
        }
    }

    private static int checkNextSameNum(string brush, int j, string[] C)
    {
        int N = C.Length;
        int brushNum = N + 1;
        int k = j + 1;
        while (k < N) // search for index for next same color if exist
        {
            if (!(C[k].Equals(brush)))
            {
                k++;
            }
            else
            {
                brushNum = (k - (j + 1)); 
                break;
            }
        }

        return brushNum;
    }
}