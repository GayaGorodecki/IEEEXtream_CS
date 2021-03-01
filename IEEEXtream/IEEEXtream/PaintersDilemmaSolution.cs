using System;
using System.Collections.Generic;
using System.IO;

class PaintersDilemmaSolution
{
    public static void PaintersDilemma()
    {
        int t = Convert.ToInt32(Console.ReadLine());
        int k;
        for (int i = 0; i < t; i++)
        {
            int CountChanges = 1;
            int N = Convert.ToInt32(Console.ReadLine());
            if (N > 1)
            {
                string[] C = Console.ReadLine().Split();
                int j = 0, firstBrushNum = N + 1, secondBrushNum = N + 1;
                string firstBrush = C[j];
                j++;
                while (j < N)
                {
                    if (C[j].Equals(firstBrush))
                    {
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (j < N)
                {
                    string secondBrush = C[j];
                    CountChanges++;

                    k = j + 1;
                    while (k < N)
                    {
                        if (!(C[k].Equals(firstBrush)))
                        {
                            k++;
                        }
                        else
                        {
                            firstBrushNum = (k - (j + 1));
                            break;
                        }
                    }
                    if (k.Equals(N))
                    {
                        firstBrushNum = N + 1;
                    }

                    k = j + 1;
                    while (k < N)
                    {
                        if (!(C[k].Equals(secondBrush)))
                        {
                            k++;
                        }
                        else
                        {
                            secondBrushNum = (k - (j + 1));
                            break;
                        }
                    }
                    if (k.Equals(N))
                    {
                        secondBrushNum = N + 1;
                    }

                    j++;
                    while (j < N)
                    {
                        if (firstBrushNum.Equals(secondBrushNum))
                        {
                            if (C[j - 1].Equals(firstBrush))
                            {
                                secondBrush = C[j];
                                CountChanges++;
                                if (!(firstBrushNum.Equals(N + 1)))
                                {
                                    firstBrushNum--;
                                }
                                k = j + 1;
                                while (k < N)
                                {
                                    if (!(C[k].Equals(secondBrush)))
                                    {
                                        k++;
                                    }
                                    else
                                    {
                                        secondBrushNum = (k - (j + 1));
                                        break;
                                    }
                                }
                                if (k.Equals(N))
                                {
                                    secondBrushNum = N + 1;
                                }
                            }
                            else if (C[j - 1].Equals(secondBrush))
                            {
                                firstBrush = C[j];
                                CountChanges++;
                                if (!(secondBrushNum.Equals(N + 1)))
                                {
                                    secondBrushNum--;
                                }
                                k = j + 1;
                                while (k < N)
                                {
                                    if (!(C[k].Equals(firstBrush)))
                                    {
                                        k++;
                                    }
                                    else
                                    {
                                        firstBrushNum = (k - (j + 1));
                                        break;
                                    }
                                }
                                if (k.Equals(N))
                                {
                                    firstBrushNum = N + 1;
                                }
                            }
                        }
                        else if (firstBrushNum < secondBrushNum)
                        {
                            if (firstBrushNum.Equals(0))
                            {
                                k = j + 1;
                                while (k < N)
                                {
                                    if (!(C[k].Equals(firstBrush)))
                                    {
                                        k++;
                                    }
                                    else
                                    {
                                        firstBrushNum = (k - (j + 1));
                                        break;
                                    }
                                }
                                if (k.Equals(N))
                                {
                                    firstBrushNum = N + 1;
                                }

                                if (!(secondBrushNum.Equals(N + 1)))
                                {
                                    secondBrushNum--;
                                }
                            }
                            else
                            {
                                secondBrush = C[j];
                                CountChanges++;
                                if (!(firstBrushNum.Equals(N + 1)))
                                {
                                    firstBrushNum--;
                                }
                                k = j + 1;
                                while (k < N)
                                {
                                    if (!(C[k].Equals(secondBrush)))
                                    {
                                        k++;
                                    }
                                    else
                                    {
                                        secondBrushNum = (k - (j + 1));
                                        break;
                                    }
                                }
                                if (k.Equals(N))
                                {
                                    secondBrushNum = N + 1;
                                }
                            }
                        }
                        else if (secondBrushNum < firstBrushNum)
                        {
                            if (secondBrushNum.Equals(0))
                            {
                                k = j + 1;
                                while (k < N)
                                {
                                    if (!(C[k].Equals(secondBrush)))
                                    {
                                        k++;
                                    }
                                    else
                                    {
                                        secondBrushNum = (k - (j + 1));
                                        break;
                                    }
                                }
                                if (k.Equals(N))
                                {
                                    secondBrushNum = N + 1;
                                }

                                if (!(firstBrushNum.Equals(N + 1)))
                                {
                                    firstBrushNum--;
                                }
                            }
                            else
                            {
                                firstBrush = C[j];
                                CountChanges++;
                                if (!(secondBrushNum.Equals(N + 1)))
                                {
                                    secondBrushNum--;
                                }
                                k = j + 1;
                                while (k < N)
                                {
                                    if (!(C[k].Equals(firstBrush)))
                                    {
                                        k++;
                                    }
                                    else
                                    {
                                        firstBrushNum = (k - (j + 1));
                                        break;
                                    }
                                }
                                if (k.Equals(N))
                                {
                                    firstBrushNum = N + 1;
                                }
                            }
                        }

                        j++;
                    }
                }
            }

            Console.WriteLine(CountChanges);
        }
    }
}