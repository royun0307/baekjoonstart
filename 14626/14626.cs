using System;

class Program
{
    public static void Main()
    {
        string s = Console.ReadLine()!;
        int sum = 0;
        int star_index = -1;

        for (int i = 0; i < 13; i++)
        {
            if (s[i] == '*')
            {
                star_index = i;
                continue;
            }

            int digit = s[i] - '0';
            int weight = (i % 2 == 0) ? 1 : 3;
            sum += digit * weight;
        }

        int star_weight = (star_index % 2 == 0) ? 1 : 3;

        for (int x = 0; x <= 9; x++)
        {
            if ((sum + x * star_weight) % 10 == 0)
            {
                Console.WriteLine(x);
                break;
            }
        }
    }
}
