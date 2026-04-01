using System;
using System.ComponentModel;
using System.IO;

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
            while ( c > 32)
            {
                value = value * 10 + (c - '0');
                c = Read();
            }

            return value * sign;
        }
    }

    public static void Main()
    {
        FastScanner fs = new FastScanner();

        int n = fs.NextInt();

        int a = fs.NextInt();
        int b = fs.NextInt();
        int c = fs.NextInt();

        int max_0 = a, max_1 = b, max_2 = c;
        int min_0 = a, min_1 = b, min_2 = c;

        for (int i = 1; i < n; i++)
        {
            a = fs.NextInt();
            b = fs.NextInt();
            c = fs.NextInt();

            int next_max_0 = a + Math.Max(max_0, max_1);
            int next_max_1 = b + Math.Max(max_0, Math.Max(max_1, max_2));
            int next_max_2 = c + Math.Max(max_1, max_2);

            int next_min_0 = a + Math.Min(min_0, min_1);
            int next_min_1 = b + Math.Min(min_0, Math.Min(min_1, min_2));
            int next_min_2 = c + Math.Min(min_1, min_2);

            max_0 = next_max_0;
            max_1 = next_max_1;
            max_2 = next_max_2;

            min_0 = next_min_0;
            min_1 = next_min_1;
            min_2 = next_min_2;
        }

        int max_awnser = Math.Max(max_0, Math.Max(max_1, max_2));
        int min_awnser = Math.Min(min_0, Math.Min(min_1, min_2));

        Console.WriteLine(max_awnser + " " + min_awnser);
    }
}
