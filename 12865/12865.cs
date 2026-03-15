using System;
using System.IO;

class Program
{
    public static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        string[] first = sr.ReadLine()!.Split();
        int n = int.Parse(first[0]);
        int k = int.Parse(first[1]);

        int[] dp = new int[k + 1];

        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine()!.Split();
            int w = int.Parse(input[0]);
            int v = int.Parse(input[1]);

            for (int j = k; j >= w; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - w] + v);
            }
        }

        Console.WriteLine(dp[k]);
    }
}
