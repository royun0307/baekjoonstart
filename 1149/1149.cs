using System;
using System.IO;

class Program
{
    public static void Main()
    {
        using var sr = new StreamReader(Console.OpenStandardInput());
        int n = int.Parse(sr.ReadLine()!);

        int dp_r = 0, dp_g = 0, dp_b = 0;

        for (int i = 0; i < n; i++)
        {
            string[] parts = sr.ReadLine()!.Split();
            int r = int.Parse(parts[0]);
            int g = int.Parse(parts[1]);
            int b = int.Parse(parts[2]);

            int next_r = Math.Min(dp_g, dp_b) + r;
            int next_g = Math.Min(dp_r, dp_b) + g;
            int next_b = Math.Min(dp_r, dp_g) + b;

            dp_r = next_r;
            dp_g = next_g;
            dp_b = next_b;
        }

        int ans = Math.Min(dp_r, Math.Min(dp_g, dp_b));
        Console.WriteLine(ans);
    }
}
