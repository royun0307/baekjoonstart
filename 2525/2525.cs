using System;
using System.Text;

class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();

        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(Console.ReadLine()!);

        int min = (b + c) % 60;
        int add_time = (b + c) / 60;

        int time = (a + add_time) % 24;

        Console.WriteLine(time + " " + min);
    }
}
