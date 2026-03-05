using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static long a, b, c;

    static long ModPow(long a, long b, long mod)
    {
        if (b == 0) return 1 % mod;
        if (b == 1) return a % mod;

        long half = ModPow(a, b / 2, mod);
        long res = (half * half) % mod;

        if ((b & 1) == 1)
            res = (res * (a % mod)) % mod;
        return res;
    }

    public static void Main()
    {
        var parts = Console.ReadLine()!.Split(' ');
        a=long.Parse(parts[0]);
        b=long.Parse(parts[1]);
        c=long.Parse(parts[2]);

        Console.WriteLine(ModPow(a % c, b, c));
    }
}
