using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    struct Edge
    {
        public int to;
        public int cost;

        public Edge(int to, int cost)
        {
            this.to = to;
            this.cost = cost;
        }
    }

    static List<Edge>[] graph;
    static bool[] visited;
    static int far_node;
    static int max_dist;

    static void Dfs(int node, int dist)
    {
        visited[node] = true;

        if (dist > max_dist)
        {
            max_dist = dist;
            far_node = node;
        }

        foreach (var next in graph[node])
        {
            if (!visited[next.to])
            {
                Dfs(next.to, dist + next.cost);
            }
        }
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);

        graph = new List<Edge>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<Edge>();

        for (int i = 0; i < n - 1; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            int parent = int.Parse(input[0]);
            int child = int.Parse(input[1]);
            int weight = int.Parse(input[2]);

            graph[parent].Add(new Edge(child, weight));
            graph[child].Add(new Edge(parent, weight));
        }

        visited = new bool[n + 1];
        max_dist = 0;
        far_node = 1;
        Dfs(far_node, max_dist);

        visited = new bool[n + 1];
        max_dist = 0;
        Dfs(far_node, 0);

        Console.WriteLine(max_dist);
    }
}
