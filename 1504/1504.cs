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

    static long[] Dijkstra(List<Edge>[] g, int start)
    {
        int n = g.Length - 1;
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
        int e = fs.NextInt();

        var g = new List<Edge>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            g[i] = new List<Edge>();
        }

        for (int i = 0; i < e; i++)
        {
            int a = fs.NextInt();
            int b = fs.NextInt();
            int t = fs.NextInt();
            g[a].Add(new Edge(b, t));
            g[b].Add(new Edge(a, t));
        }
        
        int v_1 = fs.NextInt();
        int v_2 = fs.NextInt();

        var d_1 = Dijkstra(g, 1);
        var d_v1 = Dijkstra(g, v_1);
        var d_v2 = Dijkstra(g, v_2);

        long path_1 = (d_1[v_1] >= INF || d_1[v_2] >= INF || d_v2[n] >= INF) 
            ? INF : d_1[v_1] + d_v1[v_2] + d_v2[n];
        long path_2 = (d_1[v_2] >= INF || d_v2[v_1] >= INF || d_v1[n] >= INF) 
            ? INF : d_1[v_2] + d_v2[v_1] + d_v1[n];

        long ans = Math.Min(path_1, path_2);

        Console.WriteLine(ans >= INF ? -1 : ans);
    }
}
