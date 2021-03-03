using System;
using System.Collections.Generic;

class DigitFunSolution
{
    public static void DigitFun()
    {
        List<string> input = getInput();

        foreach (string num in input)
        {
            int i = 1;
            string oldNum = num; // save A0
            string newNum = oldNum.Length.ToString(); // |A0|
            while (i > 0)
            {
                if (!(oldNum.Equals(newNum)))
                {
                    oldNum = newNum; // Ai = |Ai-1|
                    newNum = oldNum.Length.ToString(); // |Ai|
                    i++;
                }
                else
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }

    static List<string> getInput()
    {
        List<string> input = new List<string>();
        string line = string.Empty;

        while (!(line = Console.ReadLine()).Equals("END")) // Get input until "END" line
        {
            input.Add(line);
        }

        return input;
    }
}