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

        for (int i = 0; i < n; i++)
        {
            if (visited[i])
                continue;

            visited[i] = true;
            selected[depth] = nums[i];
            Dfs(depth + 1);
            visited[i] = false;
        }
    }

    public static void Main()
    {
        string[] first = Console.ReadLine()!.Split();
        n = int.Parse(first[0]);
        m = int.Parse(first[1]);

        string[] input = Console.ReadLine()!.Split();
        nums = new int[n];
        visited = new bool[n];
        selected = new int[m];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(input[i]);
        }
        Array.Sort(nums);
        Dfs(0);
        
        Console.WriteLine(sb.ToString());
    }
}
