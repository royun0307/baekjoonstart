using System;
using System.Runtime.ExceptionServices;

class Program
{
    public static void Main()
    {
        string[] first = Console.ReadLine()!.Split();
        int n = int.Parse(first[0]);
        int m = int.Parse(first[1]);
        int r = int.Parse(first[2]);

        int[] items = new int[n + 1];
        string[] item_input = Console.ReadLine()!.Split();
        for (int i = 1; i <= n; i++)
        {
            items[i] = int.Parse(item_input[i - 1]);
        }

        const int INF = 1_000_000_000;
        int[,] dist = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == j)
                    dist[i, j] = 0;
                else
                    dist[i, j] = INF;
            }
        }

        for (int i = 0;  i < r; i++)
        {
            string[] road = Console.ReadLine()!.Split();
            int a = int.Parse(road[0]);
            int b = int.Parse(road[1]);
            int l = int.Parse(road[2]);

            dist[a, b] = Math.Min(dist[a, b], l);
            dist[b, a] = Math.Min(dist[b, a], l);
        }

        for (int k = 1; k <= n; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        int answer = 0;

        for (int i = 1; i <= n; i++)
        {
            int sum = 0;

            for (int j = 1; j <= n; j++)
            {
                if (dist[i, j] <= m)
                {
                    sum += items[j];
                }
            }

            answer = Math.Max(answer, sum);
        }

        Console.WriteLine(answer.ToString());
    }
}
