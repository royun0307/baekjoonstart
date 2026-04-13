using System;

class Program
{
    const long MOD = 1000000007;

    static long Pow(long a, long exp)
    {
        long result = 1;
        a %= MOD;

        while (exp > 0)
        {
            if ((exp & 1) == 1)
                result = (result * a) % MOD;

            a = (a * a) % MOD;
            exp >>= 1;
        }

        return result;
    }

    public static void Main()
    {
        int m = int.Parse(Console.ReadLine()!);
        long answer = 0;

        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            long n = long.Parse(input[0]);
            long s = long.Parse(input[1]);

            long inverse = Pow(n, MOD - 2);
            answer = (answer + (s % MOD) * inverse) % MOD;
        }

        Console.WriteLine(answer);
    }
}
