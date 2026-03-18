using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net;

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

    class FastScanner
    {
        private readonly Stream _stream = Console.OpenStandardInput();
        private readonly byte[] _buffer = new byte[1 << 16];
        private int _ptr, _len;

        private byte Read()
        {
            if (_ptr >= _len)
            {
                _len = _stream.Read(_buffer, 0, _buffer.Length);
                _ptr = 0;
                if (_len <= 0)
                    return 0;
            }
            return _buffer[_ptr++];
        }
        public int NextInt()
        {
            byte c;
            do c = Read();
            while (c <= 32);

            int sign = 1;
            if (c == '-')
            {
                sign = -1;
                c = Read();
            }

            int value = 0;
            while (c > 32)
            {
                value = value * 10 + (c - (byte)'0');
                c = Read();
            }

            return value * sign;
        }
    }

    public static void Main()
    {
        var fs = new FastScanner();

        int n = fs.NextInt();
        int m = fs.NextInt();

        List<Edge>[] graph = new List<Edge>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<Edge>();

        for (int i = 0; i < m; i++)
        {
            int from = fs.NextInt();
            int to = fs.NextInt();
            int cost = fs.NextInt();
            graph[from].Add(new Edge(to,cost));
        }

        int start = fs.NextInt();
        int end = fs.NextInt();

        const int INF = int.MaxValue;
        int[] dist = new int[n + 1];
        Array.Fill(dist, INF);
        dist[start] = 0;

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int cur, out int cur_cost);

            if (dist[cur] < cur_cost)
                continue;

            foreach (var edge in graph[cur])
            {
                int next = edge.to;
                int next_cost = cur_cost + edge.cost;

                if (dist[next] > next_cost)
                {
                    dist[next] = next_cost;
                    pq.Enqueue(next, next_cost);
                }
            }
        }

        Console.WriteLine(dist[end]);
    }
}
