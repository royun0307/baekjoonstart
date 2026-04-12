using System;

class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);
        int[] arr = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] inc = new int[n];
        int[] dec = new int[n];

        for (int i = 0; i < n; i++)
        {
            inc[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (arr[j] < arr[i])
                {
                    inc[i] = Math.Max(inc[i], inc[j] + 1);
                }
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            dec[i] = 1;
            for (int j = n - 1; j > i; j--)
            {
                if (arr[j] < arr[i])
                {
                    dec[i] = Math.Max(dec[i], dec[j] + 1); 
                }
            }
        }

        int awnser = 0;
        for (int i = 0; i < n; i++)
        {
            awnser = Math.Max(awnser, inc[i] + dec[i] - 1);
        }

        Console.WriteLine(awnser);
    }
}
