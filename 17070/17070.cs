using System;

class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);
        int[,] map = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            for (int j = 0; j < n; j++)
            {
                map[i, j] = int.Parse(input[j]);
            }
        }

        long[,,] dp = new long[n, n, 3];
        dp[0, 1, 0] = 1;

        for (int r = 0; r < n; r++)
        {
            for (int c = 2; c < n; c++)
            {
                if (map[r, c] == 1)
                    continue;

                dp[r, c, 0] = dp[r, c - 1, 0] + dp[r, c - 1, 2];

                if (r > 0)
                {
                    dp[r, c, 1] = dp[r - 1, c, 1] + dp[r - 1, c, 2];
                }

                if (r > 0 && map[r - 1, c] == 0 && map[r, c - 1] == 0)
                {
                    dp[r, c, 2] = dp[r - 1, c - 1, 0] + dp[r - 1, c - 1, 1] + dp[r - 1, c - 1, 2];
                }
            }
        }

        long answer = dp[n - 1, n - 1, 0] + dp[n - 1, n - 1, 1] + dp[n - 1, n - 1, 2];
        Console.WriteLine(answer);
    }
}
