using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

class Program
{
    struct State
    {
        public int x;
        public int y;
        public int broken;
        public int dist;

        public State(int x, int y, int broken, int dist)
        {
            this.x = x;
            this.y = y;
            this.broken = broken;
            this.dist = dist;
        }
    }

    public static void Main()
    {
        string[] nm = Console.ReadLine()!.Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        int[,] map = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine()!;
            for (int j = 0; j < m; j++)
            {
                map[i, j] = line[j] - '0';
            }
        }

        bool[,,] visited = new bool[n, m, 2];
        Queue<State> q = new Queue<State>();

        q.Enqueue(new State(0, 0, 0, 1));
        visited[0, 0, 0] = true;

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        while (q.Count > 0)
        {
            State cur = q.Dequeue();

            if(cur.x == n - 1 && cur.y == m - 1)
            {
                Console.WriteLine(cur.dist);
                return;
            }

            for (int dir = 0; dir < 4; dir++)
            {
                int nx = cur.x + dx[dir];
                int ny = cur.y + dy[dir];

                if (nx < 0 || ny < 0 || nx >= n || ny >= m)
                    continue;

                if (map[nx, ny] == 0)
                {
                    if (!visited[nx, ny, cur.broken])
                    {
                        visited[nx, ny, cur.broken] = true;
                        q.Enqueue(new State(nx, ny, cur.broken, cur.dist + 1));
                    }
                }
                else
                {
                    if (cur.broken == 0 && !visited[nx, ny, 1])
                    {
                        visited[nx, ny, 1] = true;
                        q.Enqueue(new State(nx, ny, 1, cur.dist + 1));
                    }
                }
            }
        }
        Console.WriteLine(-1);
    }
}
