using System;
using System.Runtime.ExceptionServices;

class Program
{
    static int n, m;
    static int[,] lab;
    static List<(int r, int c)> empties = new List<(int r, int c)>();
    static List<(int r, int c)> viruses = new List<(int r, int c)>();
    static int answer = 0;

    static int[] dr = { -1, 1, 0, 0 };
    static int[] dc = { 0, 0, -1, 1 };

    static void SpreadVirus(int[,] temp)
    {
        Queue<(int r, int c)> q = new Queue<(int r, int c)>();

        foreach (var virus in viruses)
            q.Enqueue(virus);

        while (q.Count > 0)
        {
            var cur = q.Dequeue();

            for (int d = 0; d < 4; d++)
            {
                int nr = cur.r + dr[d];
                int nc = cur.c + dc[d];

                if (nr < 0 || nr >= n || nc < 0 || nc >= m)
                    continue;

                if (temp[nr, nc] != 0)
                    continue;

                temp[nr, nc] = 2;
                q.Enqueue((nr, nc));
            }
        }
    }

    static int CountSafeArea(int[,] temp)
    {
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (temp[i, j] == 0)
                    count++;
            }
        }

        return count;
    }

    public static void Main()
    {
        string[] nm = Console.ReadLine()!.Split();
        n = int.Parse(nm[0]);
        m = int.Parse(nm[1]);

        lab = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            for (int j = 0; j < m; j++)
            {
                lab[i, j] = int.Parse(input[j]);

                if (lab[i, j] == 0)
                    empties.Add((i, j));
                else if (lab[i, j] == 2)
                    viruses.Add((i, j));
            }
        }

        for (int i = 0; i < empties.Count - 2; i++)
        {
            for (int j = i + 1; j < empties.Count - 1; j++)
            {
                for (int k = j + 1; k < empties.Count; k++)
                {
                    int[,] temp = (int[,])lab.Clone();

                    temp[empties[i].r, empties[i].c] = 1;
                    temp[empties[j].r, empties[j].c] = 1;
                    temp[empties[k].r, empties[k].c] = 1;

                    SpreadVirus(temp);

                    int safe_area = CountSafeArea(temp);
                    answer = Math.Max(answer, safe_area);
                }
            }
        }

        Console.WriteLine(answer);
    }
}
