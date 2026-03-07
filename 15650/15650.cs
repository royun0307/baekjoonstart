using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class Program
{
    static int n, m;
    static int[] selected;
    static StringBuilder sb = new StringBuilder();

    static void Dfs(int depth, int start)
    {
        if (depth == m)
        {
            for (int i = 0; i < m; i++)
            {
                sb.Append(selected[i]).Append(' ');
            }
            sb.AppendLine();
            return;
        }

        for (int num = start; num <= n; num++)
        {
            selected[depth] = num;
            Dfs(depth + 1, num + 1);
        }
    }

    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        n = int.Parse(input[0]);
        m = int.Parse(input[1]);

        selected = new int[m];

        Dfs(0, 1);
        
        Console.WriteLine(sb.ToString());
    }
}
