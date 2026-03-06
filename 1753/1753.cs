using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const long INF = (long)4e18;

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
                if (_len == 0)
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

    static long[] Dijkstra(List<Edge>[] g, int start)
    {
        int n = g.Length - 1;

        long[] dist = new long[n + 1];
        for (int i = 1; i <= n; i++)
            dist[i] = INF;
        dist[start] = 0;

        var pq = new PriorityQueue<int, long>();
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int cur, out long c);
            if (c != dist[cur])
                continue;

            var list = g[cur];
            for (int i = 0; i < list.Count; i++)
            {
                var e = list[i];
                long nc = c + e.cost;
                if (nc < dist[e.to])
                {
                    dist[e.to] = nc;
                    pq.Enqueue(e.to, nc);
                }
            }
        }
        return dist;
    }

    public static void Main()
    {
        var fs = new FastScanner();

        int v = fs.NextInt();
        int e = fs.NextInt();
        int k = fs.NextInt();

        List<Edge>[] graph = new List<Edge>[v + 1];
        for (int i = 1; i <= v; i++)
            graph[i] = new List<Edge>();

        for (int i = 0; i < e; i++)
        {
            int to = fs.NextInt();
            int from = fs.NextInt();
            int cost = fs.NextInt();
            graph[to].Add(new Edge(from, cost));
        }

        long[] dist = Dijkstra(graph, k);

        using var sw = new StreamWriter(Console.OpenStandardOutput());
        for (int i = 1; i <= v; i++)
        {
            if (dist[i] == INF)
                sw.WriteLine("INF");
            else
                sw.WriteLine(dist[i]);
        }
    }
}
