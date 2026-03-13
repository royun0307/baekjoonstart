using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();

        for (int i = 0; i < n - 1; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            graph[a].Add(b);
            graph[b].Add(a);
        }

        int[] parent = new int[n + 1];
        bool[] visited = new bool[n + 1];

        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        visited[1] = true;

        while (q.Count > 0)
        {
            int current = q.Dequeue();

            foreach (int next in graph[current])
            {
                if (visited[next])
                    continue;
                visited[next] = true;
                parent[next] = current;
                q.Enqueue(next);
            }
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 2; i <= n; i++)
            sb.AppendLine(parent[i].ToString());

        Console.WriteLine(sb.ToString());
    }
}
