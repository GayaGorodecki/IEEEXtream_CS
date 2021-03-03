using System;

class XtremeRappersSolution
{
    public static void XtremeRappers()
    {
        string[] numOfWords = Console.ReadLine().Split();
        long K = Convert.ToInt64(numOfWords[0]);
        long J = Convert.ToInt64(numOfWords[1]);
        long ThreewordPhrasesCounter = 0;

        if (K == 0 || J == 0 || ((K + J) < 3)) // Not enough words
        {
            ThreewordPhrasesCounter = 0;
        }
        else if ((K >= (J * 2)) || (J >= (K * 2))) // Two words from one and one word from another needed
        {
            ThreewordPhrasesCounter = Math.Min(K, J);
        }
        else // (J <= K < J*2 || K <= J < K*2)
        {
            ThreewordPhrasesCounter = ((K + J) / 3);
        }

        Console.WriteLine(ThreewordPhrasesCounter);
    }
}