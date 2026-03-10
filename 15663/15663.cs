using System;
using System.Text;

class Program
{
    static int n, m;
    static int[] nums;
    static int[] selected;
    static bool[] visited;
    static StringBuilder sb = new StringBuilder();

    static void Dfs(int depth)
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

        for (int i = 0; i < n; i++)
        {
            if (visited[i])
                continue;
            if (nums[i] == prev)
                continue;

            visited[i] = true;
            selected[depth] = nums[i];
            prev = nums[i];
            Dfs(depth + 1);
            visited[i] = false;
        }
    }

    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        n = int.Parse(input[0]);
        m = int.Parse(input[1]);

        nums = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        visited = new bool[n];
        selected = new int[m];
        Array.Sort(nums);

        Dfs(0);
        
        Console.WriteLine(sb.ToString());
    }
}
