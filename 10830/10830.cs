using System;
using System.Text;

class Program
{
    static int n;
    static long b;
    static int[,] matrix;
    const int MOD = 1000;

    static int[,] MultiPly(int[,] a, int[,] b)
    {
        int[,] result = new int[n, n];

        for (int i = 0; i < n; i++) 
        {
            for (int j = 0; j < n; j++)
            {
                int sum = 0;
                for (int k = 0; k < n; k++)
                {
                    sum = (sum + a[i,  k] * b[k, j]) % MOD;
                }
                result[i, j] = sum;
            }
        }

        return result;
    }

    static int[,] Power(int[,] a, long exp)
    {
        if (exp == 1)
            return a;

        int[,] half = Power(a, exp / 2);
        int[,] result = MultiPly(half, half);

        if (exp % 2 == 1)
            result = MultiPly(result, a);

        return result;
    }

    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        n = int.Parse(input[0]);
        b = long.Parse(input[1]);

        matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine()!.Split();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(row[j]) % MOD;
            }
        }

        int[,] result = Power(matrix, b);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sb.Append(result[i, j] % MOD).Append(' ');
            }
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}
