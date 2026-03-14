using System;
using System.Text;

class Program
{
    public static void Main()
    {
        string[] first = Console.ReadLine()!.Split();
        int n = int.Parse(first[0]);
        int m = int.Parse(first[1]);

        int[,] prefix = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine()!.Split();

            for (int j = 1; j <= n; j++)
            {
                int num = int.Parse(input[j - 1]);

                prefix[i, j] = prefix[i - 1, j]
                    + prefix[i, j - 1]
                    - prefix[i - 1, j - 1]
                    + num;
            }
        }

        StringBuilder sb = new StringBuilder();

        for (int k = 0; k < m; k++)
        {
            string[] query = Console.ReadLine()!.Split();

            int x1= int.Parse(query[0]);
            int y1= int.Parse(query[1]);
            int x2= int.Parse(query[2]);
            int y2= int.Parse(query[3]);

            int result = prefix[x2, y2]
                - prefix[x1 - 1, y2]
                - prefix[x2, y1 - 1]
                + prefix[x1 - 1, y1 - 1];

            sb.AppendLine(result.ToString());
        }
        Console.WriteLine(sb.ToString());
    }
}
