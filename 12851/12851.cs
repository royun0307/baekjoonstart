using System;

class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        const int MAX = 100000;
        int[] dist = new int[MAX + 1];
        int[] count = new int[MAX + 1];

        for (int i = 0; i <= MAX; i++)
        {
            dist[i] = -1;
        }

        Queue<int> q = new Queue<int>();

        dist[n] = 0;
        count[n] = 1;
        q.Enqueue(n);

        while (q.Count > 0)
        {
            int cur = q.Dequeue();

            int[] next_positions = { cur - 1, cur + 1, cur * 2 };

            foreach (int next in next_positions)
            {
                if (next < 0 || next > MAX)
                    continue;

                if (dist[next] == -1)
                {
                    dist[next] = dist[cur] + 1;
                    count[next] = count[cur];
                    q.Enqueue(next);
                }
                else if (dist[next] == dist[cur] + 1)
                {
                    count[next] += count[cur];
                }
            }
        }

        Console.WriteLine(dist[k]);
        Console.WriteLine(count[k]);
    }
}
