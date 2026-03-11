using System;

class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);
        int[] arr = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] dp = new int[n];
        int answer = 0;

        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;

            for (int j = 0; j < i; j++)
            {
                if (arr[j] < arr[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }

            answer = Math.Max(answer, dp[i]);
        }
        Console.WriteLine(answer);
    }
}
