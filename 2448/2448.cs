using System;
using System.Text;

class Program
{
    static char[,] board;

    static void Draw(int x, int y, int n)
    {
        if (n == 3)
        {
            board[x, y] = '*';
            board[x + 1, y - 1] = '*';
            board[x + 1, y + 1] = '*';

            for (int i = -2; i <= 2; i++)
                board[x + 2, y + i] = '*';

            return;
        }

        int half = n / 2;

        Draw(x, y, half);
        Draw(x + half, y - half, half);
        Draw(x + half, y + half, half);
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);

        board = new char[n, 2 * n - 1];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < 2 * n - 1; j++)
                board[i, j] = ' ';

        Draw(0, n - 1, n);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 2 * n - 1; j++)
                sb.Append(board[i, j]);
            sb.Append('\n');
        }

        Console.WriteLine(sb.ToString());
    }
}
