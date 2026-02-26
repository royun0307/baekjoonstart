using System;
using System.Collections.Generic;

class Program 
{
    static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        char[,] campus = new char[n, m];
        bool[,] visited = new bool[n, m];

        int start_x = 0, start_y = 0;

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine()!;
            for (int j = 0; j < m; j++)
            {
                campus[i, j] = line[j];
                if (campus[i, j] == 'I')
                {
                    start_x = i;
                    start_y = j;
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
        queue.Enqueue((start_x, start_y));
        visited[start_x, start_y] = true;

        int count = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.x;
            int y = current.y;

            if (campus[x, y] == 'P')
                count++;

            for (int dir = 0; dir < 4; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];

                if (nx < 0 || nx >= n || ny < 0 || ny >= m)
                    continue;

                if (visited[nx, ny] || campus[nx, ny] == 'X')
                    continue;

                visited[nx, ny] = true;
                queue.Enqueue((nx, ny));
            }
        }

        Console.WriteLine(count == 0 ? "TT" : count.ToString());
    }
}
