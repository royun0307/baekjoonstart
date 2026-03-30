using System;
using System.ComponentModel;

class Program
{
    static int r, c;
    static char[,] board;
    static bool[] used = new bool[26];
    static int awnser = 0;

    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };

    static void Dfs(int x, int y, int depth)
    {
        if (depth > awnser)
            awnser = depth;

        for (int dir = 0; dir < 4; dir++)
        {
            int nx = x + dx[dir];
            int ny = y + dy[dir];

            if (nx < 0 || nx >= r || ny < 0 || ny >= c)
                continue;

            int idx = board[nx, ny] - 'A';

            if (used[idx])
                continue;

            used[idx] = true;
            Dfs(nx, ny, depth + 1);
            used[idx] = false;
        }
    }

    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        r = int.Parse(input[0]);
        c = int.Parse(input[1]);

        board = new char[r, c];

        for (int i = 0; i < r; i++)
        {
            string line = Console.ReadLine()!;
            for (int j = 0; j < c; j++)
            {
                board[i, j] = line[j];
            }
        }

        used[board[0, 0] - 'A'] = true;
        Dfs(0, 0, 1);

        Console.WriteLine(awnser);
    }
}
