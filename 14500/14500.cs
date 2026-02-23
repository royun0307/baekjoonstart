using System;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;

class Program 
{
    static int n, m;
    static int[,] a;
    static bool[,] vis;
    static int ans = 0;

    static readonly int[] dr = { -1, 1, 0, 0 };
    static readonly int[] dc = { 0, 0, -1, 1 };

    static void Main()
    {
        var nm = Console.ReadLine().Split();
        n = int.Parse(nm[0]);
        m = int.Parse(nm[1]);

        a = new int[n, m];
        vis = new bool[n, m];

        for (int i = 0; i < n; i++)
        {
            var row = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < m; j++)
                a[i, j] = row[j];
        }

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                vis[r, c] = true;
                Dfs(r, c, 1, a[r, c]);
                vis[r, c] = false;

                CheckT(r, c);
            }
        }

        Console.WriteLine(ans);
    }

    static void Dfs(int r, int c, int depth, int sum)
    {
        if (depth == 4)
        {
            if (sum > ans)
                ans = sum;
            return;
        }

        for (int k = 0; k < 4; k++)
        {
            int nr = r + dr[k];
            int nc = c + dc[k];
            if (nr < 0 || nr >= n | nc < 0 || nc >= m)
                continue;
            if (vis[nr, nc])
                continue;
            
            vis[nr, nc] = true;
            Dfs(nr, nc, depth + 1, sum + a[nr, nc]);
            vis[nr, nc] = false;
        }
    }

    static void CheckT(int r, int c)
    {
        int center = a[r, c];

        int[] neigh = new int[4];
        bool[] ok = new bool[4];

        for (int k = 0; k < 4; k++)
        {
            int nr = r + dr[k];
            int nc = c + dc[k];

            if(nr < 0 || nr >= n || nc < 0 || nc >= m)
            {
                ok[k] = false;
                neigh[k] = 0;
            }
            else
            {
                ok[k] = true;
                neigh[k] = a[nr, nc];
            }
        }

        int cnt = 0;
        for (int k = 0; k < 4; k++)
        {
            if(ok[k])
                cnt++;
        }
        if (cnt < 3)
            return;

        if (cnt == 4)
        {
            int sum4 = center + neigh[0] + neigh[1] + neigh[2] + neigh[3];
            int min = Math.Min(Math.Min(neigh[0], neigh[1]), Math.Min(neigh[2], neigh[3]));
            ans = Math.Max(ans, sum4 - min);
            return;
        }

        int sum3 = center;
        for (int k = 0; k < 4; k++)
        {
            if (ok[k]) 
                sum3 += neigh[k];
        }
        ans = Math.Max(ans, sum3);

    }
}
