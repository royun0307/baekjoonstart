using System;
using System.ComponentModel;

class Program 
{
    static void Main()
    {
        const int MOD = 10007;
        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(1);
            return;
        }
        if (n == 2)
        {
            Console.WriteLine(3);
            return;
        }

        int a = 1;
        int b = 3;

        for (int i = 3; i <= n; i++)
        {
            int c = (b + 2 * a) % MOD;
            a = b;
            b = c;
        }

        Console.WriteLine(b);
    }
}
