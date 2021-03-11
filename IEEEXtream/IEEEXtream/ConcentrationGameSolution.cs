using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class pairs
{
    public string num;
    public int i1;
    public int i2;
}

class ConcentrationGameSolution
{
    public static void ConcentrationGame()
    {
        int N = Convert.ToInt32(Console.ReadLine());
        int t = 0;
        bool foundNext = false;

        Dictionary<string, pairs> seen = new Dictionary<string, pairs>();
        HashSet<int> matched = new HashSet<int>();
        HashSet<Tuple<int, int>> checkedPairs = new HashSet<Tuple<int, int>>();
        HashSet<int> checkedIndex = new HashSet<int>();

        int i1 = 1, i2 = 2;
        Console.WriteLine(i1 + " " + i2);
        Tuple<int, int> pair = new Tuple<int, int>(i1, i2);
        Tuple<int, int> samePair = new Tuple<int, int>(i2, i1);
        checkedPairs.Add(pair);
        checkedPairs.Add(samePair);

        string ans = string.Empty;
        while (!((ans = Console.ReadLine()).Equals("-1")))
        {
            if (ans.Equals("MATCH"))
            {
                matched.Add(i1);
                matched.Add(i2);
                t++;
                if (t == N)
                {
                    Console.WriteLine("-1");
                    break;
                }
                foreach (pairs p in seen.Values)
                {
                    if (p.i1 != 0 && p.i2 != 0 && !matched.Contains(p.i1)) // match = list<pairs> ??
                    {
                        i1 = p.i1;
                        i2 = p.i2;
                        foundNext = true;
                        break;
                    }
                }
            }
            else
            {
                string[] nums = ans.Split();
                if (seen.ContainsKey(nums[0]) || seen.ContainsKey(nums[1]))
                {
                    foreach (KeyValuePair<string,pairs> p in seen)
                    {
                        if (p.Key == nums[0])
                        {
                            if (p.Value.i1 != 0)
                            {
                                p.Value.i2 = i1;
                            }
                            else if (p.Value.i2 != 0)
                            {
                                p.Value.i1 = i1;
                            }
                            break;
                        }
                        else if (p.Key == nums[1])
                        {
                            if (p.Value.i1 != 0)
                            {
                                p.Value.i2 = i2;
                            }
                            else if (p.Value.i2 != 0)
                            {
                                p.Value.i1 = i2;
                            }
                            break;
                        }
                    }
                }
                if (!seen.ContainsKey(nums[0]))
                {
                    pairs newPair = new pairs();
                    newPair.num = nums[0];
                    newPair.i1 = i1;
                    seen.Add(nums[0], newPair);
                    checkedIndex.Add(i1);
                }
                if (!seen.ContainsKey(nums[1]))
                {
                    pairs newPair = new pairs();
                    newPair.num = nums[1];
                    newPair.i2 = i2;
                    seen.Add(nums[1], newPair);
                    checkedIndex.Add(i2);
                }

                foreach (pairs p in seen.Values)
                {
                    if (p.i1 != 0 && p.i2 != 0 && !matched.Contains(p.i1))
                    {
                        i1 = p.i1;
                        i2 = p.i2;
                        foundNext = true;
                        break;
                    }
                }

                if (foundNext == false)
                {
                    foreach (pairs p in seen.Values)
                    {
                        if (p.num == nums[0] && p.i1 != i1 && p.i2 != i1)
                        {
                            if (p.i1 != 0)
                            {
                                i2 = p.i1;
                            }
                            else if (p.i2 != 0)
                            {
                                i2 = p.i2;
                            }
                            foundNext = true;
                            break;
                        }
                        else if (p.num == nums[1] && p.i1 != i2 && p.i2 != i2)
                        {
                            if (p.i1 != 0)
                            {
                                i1 = p.i1;
                            }
                            else if (p.i2 != 0)
                            {
                                i1 = p.i2;
                            }
                            foundNext = true;
                            break;
                        }
                    }
                }
            }

            if (foundNext == false)
            {
                int i = 1;
                while (checkedPairs.Contains(pair))
                {
                    while ((checkedIndex.Contains(i) || matched.Contains(i)) && i < 2 * N - 1)
                    {
                        i++;
                    }
                    i1 = i++;
                    while ((checkedIndex.Contains(i) || matched.Contains(i) || i == i1) && i < 2 * N)
                    {
                        i++;
                    }
                    i2 = i;
                    pair = new Tuple<int, int>(i1, i2);
                    samePair = new Tuple<int, int>(i2, i1);
                }
                checkedPairs.Add(pair);
                checkedPairs.Add(samePair);
            }

            Console.WriteLine(i1 + " " + i2);
            foundNext = false;
        }
    }
}