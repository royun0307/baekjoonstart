using System;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

class Program
{
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
            if ( c == '-')
            {
                sign = -1;
                c = Read();
            }

            int value = 0;
            while (c > 32)
            {
                value = value * 10 + (c - '0');
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

        const int INF = int.MaxValue;
        int[,] dist = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == j)
                    dist[i, j] = 0;
                else
                    dist[i, j] = INF;
            }
        }

        for (int i = 0; i < m; i++)
        {
            int a = fs.NextInt();
            int b = fs.NextInt();
            int c = fs.NextInt();

            if (c < dist[a, b])
                dist[a, b] = c;
        }

        for (int k = 1; k <= n; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (dist[i, k] == INF || dist[k, j] == INF)
                        continue;

                    int through = dist[i, k] + dist[k, j];
                    if (through < dist[i, j])
                        dist[i, j] = through;
                }
            }
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (dist[i, j] == INF)
                    sb.Append(0);
                else
                    sb.Append(dist[i, j]);

                if (j < n)
                    sb.Append(' ');
            }
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}
