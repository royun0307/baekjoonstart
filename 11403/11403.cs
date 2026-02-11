using System;
using System.Text;

class Program 
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] g = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                g[i, j] = int.Parse(parts[j]);
            }
        }

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                if (g[i, k] == 0) continue;
                for (int j = 0; j < n; j++)
                {
                    if (g[k, j] == 1)
                        g[i, j] = 1;
                }
            }
        }

        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sb.Append(g[i, j]);
                if (j + 1 < n)
                    sb.Append(' ');
            }
            if (i + 1 < n)
                sb.Append('\n');
        }

        Console.Write(sb.ToString());
    }
}
