using System;
using System.ComponentModel;
using System.Text;

class Program
{
    static int n, m;
    static int[] nums;
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

        int prev = -1;

        for (int i = start; i < n; i++) {
            if (nums[i] == prev)
                continue;

            prev = nums[i];
            selected[depth] = nums[i];
            Dfs(depth + 1, i);
        }
    }

    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        n = int.Parse(input[0]);
        m = int.Parse(input[1]);

        nums = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(nums);

        selected = new int[m];

        Dfs(0, 0);

        Console.Write(sb.ToString());
    }
}
