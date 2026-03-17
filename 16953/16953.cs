using System;

class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        long a = long.Parse(input[0]);
        long b = long.Parse(input[1]);

        int count = 1;

        while (b > a)
        {
            if ( b % 10 == 1)
            {
                b /= 10;
                count++;
            }
            else if (b % 2 == 0)
            {
                b /= 2;
                count++;
            }
            else
            {
                Console.WriteLine(-1);
                return;
            }
        }

        if (a == b)
            Console.WriteLine(count);
        else
            Console.WriteLine(-1);
    }
}
