using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

class Program
{
    struct Edge
    {
        public int from;
        public int to;
        public int cost;

        public Edge(int from, int to, int cost)
        {
            this.from = from;
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
        int tc = fs.NextInt();
        var output = new System.Text.StringBuilder();       

        while (tc-- > 0)
        {
            int n = fs.NextInt();
            int m = fs.NextInt();
            int w = fs.NextInt();

            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < m; i++)
            {
                int s = fs.NextInt();
                int e = fs.NextInt();
                int t = fs.NextInt();

                edges.Add(new Edge(s, e, t));
                edges.Add(new Edge(e, s, t));
            }

            for (int i = 0; i < w; i++)
            {
                int s = fs.NextInt();
                int e = fs.NextInt();
                int t = fs.NextInt();

                edges.Add(new Edge(s, e, -t));
            }

            for (int i = 1; i <= n; i++)
            {
                edges.Add(new Edge(0, i, 0));
            }

            long[] dist = new long[n + 1];
            bool updated = false;

            for (int i = 0; i <= n; i++)
            {
                updated = false;

                foreach (var edge in edges)
                {
                    if (dist[edge.to] > dist[edge.from] + edge.cost)
                    {
                        dist[edge.to] = dist[edge.from] + edge.cost;
                        updated = true;

                        if (i == n)
                        {
                            break;
                        }
                    }
                }  

                if (!updated)
                    break;
            }

            output.AppendLine(updated ? "YES" : "NO");
        }

        Console.Write(output.ToString());
    }
}
