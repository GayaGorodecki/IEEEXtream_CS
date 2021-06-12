using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FullAdderSolution
{
    static int b;
    static string symbols;
    static string firstInputNum;
    static string secondInputNum;
    static string seperator;
    static string result;

    public static void FullAdder()
    {
        getInput();

        // Calculate result:
        int firstNum = 0, secondNum = 0, num = 0, carry = 0;
        char[] res = new char[firstInputNum.Length];

        for (int i = firstInputNum.Length - 1; i > 0; i--)
        {
            // Convert symbol to base-10
            firstNum = getNum(firstInputNum[i]);
            secondNum = getNum(secondInputNum[i]);

            // Calc sum
            num = firstNum + secondNum + carry;

            // Check carry for next calculation
            if (num >= b)
            {
                carry = 1;
                num -= b;
            }
            else
            {
                carry = 0;
            }

            // Convert back to base-B
            res[i] = symbols[num];
        }

        // Last calculation - if there more carry to add or just space.
        res[0] = ' ';
        if (carry != 0)
        {
            res[0] = '1';
        }
        result = String.Join("", res);

        printOutput();
    }

    private static void getInput()
    {
        string[] firstLine = Console.ReadLine().Split();
        b = Convert.ToInt32(firstLine[0]);
        symbols = firstLine[1];
        firstInputNum = Console.ReadLine();
        secondInputNum = Console.ReadLine();
        seperator = Console.ReadLine();
        Console.ReadLine();
    }

    private static int getNum(char s)
    {
        // if one of the numbers ended - put 0 to calc only the other num + carry
        // else get the base-10 num by the index of the symbol.
        int num = 0;
        if (!s.Equals(' '))
        {
            num = symbols.IndexOf(s);
        }

        return num;
    }

    private static void printOutput()
    {
        Console.WriteLine(b + " " + symbols);
        Console.WriteLine(firstInputNum);
        Console.WriteLine(secondInputNum);
        Console.WriteLine(seperator);
        Console.WriteLine(result);
    }
}
