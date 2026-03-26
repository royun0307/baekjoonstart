using System;

class Program
{
    static int n;
    static int count = 0;

    static bool[] col_used;
    static bool[] diag1_used;
    static bool[] diag2_used;

    static void Dfs(int row)
    {
        if (row == n)
        {
            count++;
            return;
        }

        for (int col = 0; col < n; col++)
        {
            int diag1 = row - col + (n - 1);
            int diag2 = row + col;

            if (col_used[col] || diag1_used[diag1] || diag2_used[diag2])
                continue;

            col_used[col] = true;
            diag1_used[diag1] = true;
            diag2_used[diag2] = true;

            Dfs(row + 1);

            col_used[col] = false;
            diag1_used[diag1] = false;
            diag2_used[diag2] = false;
        }
    }

    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        
        col_used = new bool[n];
        diag1_used = new bool[2 * n - 1];
        diag2_used = new bool[2 * n - 1];

        Dfs(0);

        Console.WriteLine(count);
    }
}
