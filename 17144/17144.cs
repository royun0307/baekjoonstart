using System;

class Program
{
    static int R, C, T;
    static int[,] map;
    static int upper = -1, lower = -1;

    static int[] dr = { -1, 1, 0, 0 };
    static int[] dc = { 0, 0, -1, 1 };

    static void SpreadDust()
    {
        int[,] next = new int[R, C];

        next[upper, 0] = -1;
        next[lower, 0] = -1;

        for (int r = 0; r < R; r++)
        {
            for (int c = 0; c < C; c++)
            {
                if (map[r, c] > 0)
                {
                    int spread_amount = map[r, c] / 5;
                    int count = 0;

                    for (int d = 0; d < 4; d++)
                    {
                        int nr = r + dr[d];
                        int nc = c + dc[d];

                        if (nr < 0 || nr >= R || nc < 0 || nc >= C)
                            continue;
                        if (map[nr, nc] == -1)
                            continue;

                        next[nr, nc] += spread_amount;
                        count++;
                    }

                    next[r, c] += map[r, c] - spread_amount * count;
                }
            }
        }

        map = next;
    }

    static void OperateCleaner()
    {
        for (int r = upper - 1; r > 0; r--)
            map[r, 0] = map[r - 1, 0];
        for (int c = 0; c < C - 1; c++)
            map[0, c] = map[0, c + 1];
        for (int r = 0; r < upper; r++)
            map[r, C - 1] = map[r + 1, C - 1];
        for (int c = C - 1; c > 1; c--)
            map[upper, c] = map[upper, c - 1];

        map[upper, 1] = 0;

        for (int r = lower + 1; r < R - 1; r++)
            map[r, 0] = map[r + 1, 0];
        for (int c = 0; c < C - 1; c++)
            map[R - 1, c] = map[R - 1, c + 1];
        for (int r = R - 1; r > lower; r--)
            map[r, C - 1] = map[r - 1, C - 1];
        for (int c = C - 1; c > 1; c--)
            map[lower, c] = map[lower, c - 1];

        map[lower, 1] = 0;

        map[upper, 0] = -1;
        map[lower, 0] = -1;
    }

    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        R = int.Parse(input[0]);
        C = int.Parse(input[1]);
        T = int.Parse(input[2]);

        map = new int[R, C];

        for (int r = 0; r < R; r++)
        {
            string[] row = Console.ReadLine()!.Split();
            for (int c = 0; c < C; c++)
            {
                map[r, c] = int.Parse(row[c]);

                if (map[r, c] == -1)
                {
                    if (upper == -1)
                        upper = r;
                    else
                        lower = r;
                }
            }
        }

        for (int t = 0; t < T; t++)
        {
            SpreadDust();
            OperateCleaner();
        }

        int answer = 0;
        for (int r = 0; r < R; r++)
        {
            for (int c = 0; c < C; c++)
            {
                if (map[r, c] > 0)
                    answer += map[r, c];
            }
        }

        Console.WriteLine(answer);
    }
}
