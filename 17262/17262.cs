using System;
using System.Runtime.ExceptionServices;

class Program 
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] dp = new int[n + 1];

        for (int i = 0; i <= n; i++)
        {
            dp[i] = i;

            for (int j = 1; j * j <= i; j++)
            {
                int square = j * j;
                dp[i] = Math.Min(dp[i], dp[i - square] + 1);
            }
        }

        Console.WriteLine(dp[n]);
    }
}
