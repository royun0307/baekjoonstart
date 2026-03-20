using System;

class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] dp = new int[n][];

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            dp[i] = new int[i + 1];

            for (int j = 0; j <= i; j++)
            {
                int num = int.Parse(input[j]);
                if (i == 0)
                {
                    dp[i][j] = num;
                }
                else if (j == 0)
                {
                    dp[i][j] = dp[i - 1][j] + num;
                }
                else if (j == i)
                {
                    dp[i][j] = dp[i - 1][j - 1] + num;
                }
                else
                {
                    dp[i][j] = Math.Max(dp[i - 1][j - 1], dp[i - 1][j]) + num;
                }
            }
        }

        int awnser = 0;
        for (int j = 0; j < n; j++)
        {
            awnser = Math.Max(awnser, dp[n - 1][j]);
        }

        Console.WriteLine(awnser);
    }
}
