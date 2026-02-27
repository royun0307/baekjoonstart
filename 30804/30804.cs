using System;
using System.IO;
using System.Numerics;

class Program
{
    private sealed class FastScanner
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer = new byte[1 << 16];
        private int _len, _ptr;

        public FastScanner()
        {
            _stream = Console.OpenStandardInput();
        }

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
            do c = Read(); while (c <= ' ');

            int sign = 1;
            if (c == '-')
            {
                sign = -1;
                c = Read();
            }

            int val = 0;
            while (c > ' ')
            {
                val = val * 10 + (c - (byte)'0');
                c = Read();
            }
            return val * sign;
        }
    }

    public static void Main()
    {
        var fs = new FastScanner();

        int n = fs.NextInt();
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = fs.NextInt();
        }

        int[] freq = new int[10];
        int distinct = 0;

        int left = 0, best = 0;

        for (int right = 0; right < n; right++)
        {
            int x = a[right];
            if (freq[x] == 0)
                distinct++;
            freq[x]++;

            while (distinct > 2)
            {
                int y = a[left++];
                freq[y]--;
                if (freq[y] == 0)
                    distinct--;
            }

            int len = right - left + 1;
            best = Math.Max(best, len);
        }

        Console.WriteLine(best);
    }
}
