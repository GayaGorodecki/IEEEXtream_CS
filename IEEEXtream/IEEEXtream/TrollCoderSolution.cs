using System;

class TrollCoderSolution
{
    public static void TrollCoder()
    {
        int N = Convert.ToInt32(Console.ReadLine()); // Length of the sequence
        int[] quary = new int[N]; // Initialized to zeros

        Console.WriteLine("Q " + string.Join(" ", quary));
        int correctBits = Convert.ToInt32(Console.ReadLine()); // Check first quary
        int index = 0, newCorrectBits = 0;
        while (!(correctBits.Equals(N)))
        {
            quary[index] = 1; // Try to change the bit and check if num of correct bits got bigger
            Console.WriteLine("Q " + string.Join(" ", quary));
            newCorrectBits = Convert.ToInt32(Console.ReadLine());
            if (newCorrectBits < correctBits) // not correct - return bit to 0
            {
                quary[index] = 0;
            }
            else // correct - update correct bits
            {
                correctBits = newCorrectBits; 
            }
            index++;
        }
        Console.WriteLine("A " + string.Join(" ", quary));
    }
}