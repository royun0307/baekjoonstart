using System;
using System.Data;
using System.IO;
using System.Numerics;

class Program
{
    static int[] parent;

    static int Find(int x)
    {
        if (parent[x] == x)
            return x;
        return parent[x] = Find(parent[x]);
    }

    static void Union(int a, int b)
    {
        a = Find(a);
        b = Find(b);
        if (a == b)
            return;
        parent[b] = a;
    }

    public static void Main()
    {
        var nm = Console.ReadLine()!.Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        parent = new int[n + 1];
        for (int i = 0; i <= n; i++)
            parent[i] = i;

        var t_line = Console.ReadLine()!.Split();
        int t = int.Parse(t_line[0]);
        var truth = new List<int>();
        for (int i = 1; i <= t; i++)
            truth.Add(int.Parse(t_line[i]));

        var parties = new List<int[]>();

        for (int i = 1; i <= m; i++)
        {
            var parts = Console.ReadLine()!.Split();
            int k = int.Parse(parts[0]);
            int[] members = new int[k];
            for (int j = 0; j < k; j++)
                members[j] = int.Parse(parts[j + 1]);
            parties.Add(members);

            for (int j = 1; j < k; j++)
                Union(members[0], members[j]);
        }

        var truth_roots = new HashSet<int>();
        foreach (var p in truth)
            truth_roots.Add(Find(p));

        int awnser = 0;

        foreach (var party in parties)
        {
            bool canLie = true;
            foreach (var member in party)
            {
                if (truth_roots.Contains(Find(member)))
                {
                    canLie = false;
                    break;
                }
            }
            if (canLie)
                awnser++;
        }

        Console.WriteLine(awnser);
    }
}
