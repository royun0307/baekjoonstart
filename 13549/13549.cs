using System;
using System.Collections.Generic;

class Program
{
    const int MAX = 100000;
    const int INF = int.MaxValue;

    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] dist = new int[MAX + 1];
        for (int i = 0; i <= MAX; i++)
            dist[i] = INF;

        LinkedList<int> deque = new LinkedList<int>();
        dist[n] = 0;
        deque.AddLast(n);

        while (deque.Count > 0)
        {
            int cur = deque.First!.Value;
            deque.RemoveFirst();

            if (cur == k)
            {
                Console.WriteLine(dist[cur]);
                return;
            }

            int next = cur * 2;
            if (next <= MAX && dist[next] > dist[cur])
            {
                dist[next] = dist[cur];
                deque.AddFirst(next);
            }

            next = cur - 1;
            if (next >= 0 && dist[next] > dist[cur] + 1)
            {
                dist[next] = dist[cur] + 1;
                deque.AddLast(next);
            }

            next = cur + 1;
            if (next <= MAX && dist[next] > dist[cur] + 1)
            {
                dist[next] = dist[cur] + 1;
                deque.AddLast(next);
            }
        }
    }
}
