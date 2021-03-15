using System;
using System.Collections.Generic;

class Pair
{
    public string card { get; set; }
    public int i1 { get; set; }
    public int i2 { get; set; }
}

class ConcentrationGameSolution
{
    public static void ConcentrationGame()
    {
        int N = Convert.ToInt32(Console.ReadLine());

        Dictionary<string, Pair> seen = new Dictionary<string, Pair>(); // To find matches.
        HashSet<int> matched = new HashSet<int>(); // For not check index that already matched.
        HashSet<Tuple<int, int>> checkedPairs = new HashSet<Tuple<int, int>>(); // For not check checked pairs again.
        HashSet<int> checkedIndex = new HashSet<int>(); // For not check index that already checked.

        int i1 = 1, i2 = 2;
        Console.WriteLine(i1 + " " + i2); // First operation.

        // Add to checked pairs list.
        Tuple<int, int> pair = new Tuple<int, int>(i1, i2);
        Tuple<int, int> samePair = new Tuple<int, int>(i2, i1);
        checkedPairs.Add(pair);
        checkedPairs.Add(samePair);

        string reply = string.Empty;
        while (!((reply = Console.ReadLine()).Equals("-1"))) // Not invalid move.
        {
            if (reply.Equals("MATCH"))
            {
                matched.Add(i1);
                matched.Add(i2);

                if (matched.Count == 2 * N) // All card matched -> exit.
                {
                    Console.WriteLine("-1");
                    break;
                }
            }
            else
            {
                string[] nums = reply.Split();
                if (seen.ContainsKey(nums[0]) || seen.ContainsKey(nums[1])) // Update index of cards -> get next match.
                {
                    bool updateFirst = false, updateSecond = false;
                    foreach (KeyValuePair<string, Pair> p in seen)
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
                            updateFirst = true;
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
                            updateSecond = true;
                        }
                        if (updateFirst == true && updateSecond == true)
                        {
                            break;
                        }
                    }
                }

                if (!seen.ContainsKey(nums[0])) // If not seen - add new seen card.
                {
                    Pair newPair = new Pair();
                    newPair.card = nums[0];
                    newPair.i1 = i1;
                    seen.Add(nums[0], newPair);
                    checkedIndex.Add(i1);
                }
                if (!seen.ContainsKey(nums[1]))
                {
                    Pair newPair = new Pair();
                    newPair.card = nums[1];
                    newPair.i2 = i2;
                    seen.Add(nums[1], newPair);
                    checkedIndex.Add(i2);
                }
            }

            bool foundNext = false;
            foreach (Pair p in seen.Values) // Search for more matches.
            {
                if (p.i1 != 0 && p.i2 != 0 && !matched.Contains(p.i1)) // If there is a pair with two indexes.
                {
                    i1 = p.i1;
                    i2 = p.i2;
                    foundNext = true;
                    break;
                }
            }

            if (foundNext == false) // If not found another match.
            {
                int i = 1;
                while (checkedPairs.Contains(pair)) // Search for next indexes that not checked.
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
        }
    }
}