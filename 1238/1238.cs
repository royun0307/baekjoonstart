using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    struct Edge
    {
        public int to;
        public int w;
        public Edge(int to, int w)
        {
            this.to = to;
            this.w = w;
        }
    }

    class FastScanner
    {
        private readonly byte[] _buffer = new byte[1 << 16];
        private readonly Stream _stream;
        private int _ptr, _len;

        public FastScanner()
        {
            _stream = Console.OpenStandardInput();
        }

        private byte ReadByte()
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
            do c = ReadByte();
            while (c <= 32);

            int sign = 1;
            if (c == '-')
            {
                sign = -1;
                c = ReadByte();
            }

            int val = 0;
            while (c > 32)
            {
                val = val * 10 + (c - (byte)'0');
                c = ReadByte();
            }
            return val * sign;
        }
    }

    const long INF = (long)1e18;

    static long[] Dijkstra(int n, List<Edge>[] g, int start)
    {
        long[] dist = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dist[i] = INF;
        }
        dist[start] = 0;

        var pq = new PriorityQueue<int, long>();
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int cur, out long d);
            if (d != dist[cur])
                continue;

            var list = g[cur];
            for (int i = 0; i < list.Count; i++)
            {
                var e = list[i];
                long nd = d + e.w;
                if (nd < dist[e.to]) 
                {
                    dist[e.to] = nd;
                    pq.Enqueue(e.to, nd);
                }
            }
        }

        return dist;
    }

    public static void Main()
    {
        var fs = new FastScanner();
        int n = fs.NextInt();
        int m = fs.NextInt();
        int x = fs.NextInt();

        var g = new List<Edge>[n + 1];
        var rg = new List<Edge>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            g[i] = new List<Edge>();
            rg[i] = new List<Edge>();
        }

        for (int i = 0; i < m; i++)
        {
            int a = fs.NextInt();
            int b = fs.NextInt();
            int t = fs.NextInt();
            g[a].Add(new Edge(b, t));
            rg[b].Add(new Edge(a, t));
        }

        long[] from_x = Dijkstra(n, g, x);

        long[] to_x = Dijkstra(n, rg, x);

        long ans = 0;
        for (int i = 1; i <= n; i++)
        {
            long round_trip = to_x[i] + from_x[i];
            if (round_trip > ans)
                ans = round_trip;
        }

        Console.WriteLine(ans);
    }
}
