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
            if (c == '-')
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
        int t = fs.NextInt();
        StringBuilder sb = new StringBuilder();

        while (t-- > 0)
        {
            int n = fs.NextInt();

            int[,] sticker = new int[2, n + 1];
            int[,] dp = new int[2, n + 1];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j <= n; j++)
                    sticker[i, j] = fs.NextInt();
            }

            dp[0, 1] = sticker[0, 1];
            dp[1, 1] = sticker[1, 1];

            for (int i = 2; i <= n; i++)
            {
                dp[0, i] = Math.Max(dp[1, i - 1], dp[1, i - 2]) + sticker[0, i];
                dp[1, i] = Math.Max(dp[0, i - 1], dp[0, i - 2]) + sticker[1, i];
            }

            sb.AppendLine(Math.Max(dp[0, n], dp[1, n]).ToString());
        }

        Console.WriteLine(sb.ToString());
    }
}
