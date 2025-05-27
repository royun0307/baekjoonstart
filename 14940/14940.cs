using System.Text;
using System.Xml;

namespace backjoonC_
{
    internal class Program
    {
        static void Main()
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            int n, m, startX, startY;
            int[,] grid, dist;
            bool[,] visited;

            var str = Console.ReadLine().Split();
            n = int.Parse(str[0]);
            m = int.Parse(str[1]);

            grid = new int[n, m];
            dist = new int[n, m];
            visited = new bool[n, m];

            startX = 0;
            startY = 0;

            for (int i = 0; i < n; i++)
            {
                var map = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    grid[i, j] = int.Parse(map[j]);
                    dist[i, j] = -1;

                    if (grid[i, j] == 2)
                    {
                        startX = i;
                        startY = j;
                    }
                }
            }

            var queue = new Queue<(int x, int y)>();
            queue.Enqueue((startX, startY));
            visited[startX, startY] = true;
            dist[startX, startY] = 0;

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = x + dx[dir];
                    int ny = y + dy[dir];
                    if (nx < 0 || nx >= n || ny < 0 || ny >= m) continue;

                    if (!visited[nx, ny] && grid[nx, ny] == 1)
                    {
                        visited[nx, ny] = true;
                        dist[nx, ny] = dist[x, y] + 1;
                        queue.Enqueue((nx, ny));
                    }
                }
            }

            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        sb.Append("0 ");
                    }
                    else if (grid[i, j] == 2)
                    {
                        sb.Append("0 ");
                    }
                    else
                    {
                        sb.Append(dist[i, j] >= 0 ? dist[i, j].ToString() + " " : "-1 ");
                    }
                }

                sb.Length--;
                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }
    }
}
