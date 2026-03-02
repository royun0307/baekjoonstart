using System;
using System.IO;
using System.Collections.Generic;

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
        private int _ptr, _len;
        private readonly Stream _stream;

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
            if(c == '-')
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

    static (int far_node, long far_dist) FarthestFrom(int start, List<Edge>[] g)
    {
        int n = g.Length - 1;
        var dist = new long[n + 1];
        var visited = new bool[n + 1];

        var stack = new Stack<int>();
        stack.Push(start);
        visited[start] = true;
        dist[start] = 0;

        while (stack.Count > 0)
        {
            int u = stack.Pop();
            foreach (var e in g[u])
            {
                int v = e.to;
                if (visited[v])
                    continue;
                visited[v] = true;
                dist[v] = dist[u] + e.w;
                stack.Push(v);
            }
        }

        int far_node = start;
        long far_dist = 0;
        for (int i = 1; i <= n; i++)
        {
            if(visited[i] && dist[i] > far_dist)
            {
                far_dist = dist[i];
                far_node = i;
            }
        }
        return (far_node, far_dist);
    }

    public static void Main()
    {
        var fs = new FastScanner();
        int v = fs.NextInt();

        var g = new List<Edge>[v + 1];
        for (int i = 1; i <= v; i++)
        {
            g[i] = new List<Edge>();
        }

        for (int i = 0; i < v; i++)
        {
            int v_num = fs.NextInt();
            while (true)
            {
                int to = fs.NextInt();
                if (to == -1)
                    break;
                int w = fs.NextInt();
                g[v_num].Add(new Edge(to, w));
            }
        }

        var a = FarthestFrom(1, g);
        var b = FarthestFrom(a.far_node, g);

        Console.WriteLine(b.far_dist);
    }
}
