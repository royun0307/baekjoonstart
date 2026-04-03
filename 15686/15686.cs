using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

class Program
{
    static int n, m;
    static List<(int r, int c)> houses = new List<(int r, int c)> ();
    static List<(int r, int c)> chickens = new List<(int r, int c)> ();

    static int awnser = int.MaxValue;
    static List<int> selected = new List<int>();

    static void DFS(int start, int depth)
    {
        if (depth == m)
        {
            int city_chicken_distance = GetCityChickenDistance();
            awnser = Math.Min(awnser, city_chicken_distance);
            return;
        }

        for (int i = start; i < chickens.Count; i++)
        {
            selected.Add(i);
            DFS(i + 1, depth + 1);
            selected.RemoveAt(selected.Count - 1);
        }
    }

    static int GetCityChickenDistance()
    {
        int sum = 0;

        foreach (var house in houses)
        {
            int min_dist = int.MaxValue;

            foreach (int idx in selected)
            {
                var chicken = chickens[idx];
                int dist = Math.Abs(house.r - chicken.r) + Math.Abs(house.c - chicken.c);
                min_dist = Math.Min(min_dist, dist);
            }

            sum += min_dist;
        }

        return sum;
    }

    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split();
        n = int.Parse(input[0]);
        m = int.Parse(input[1]);

        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine()!.Split();
            for (int j = 0; j < n; j++)
            {
                int value = int.Parse(row[j]);

                if (value == 1)
                    houses.Add((i, j));
                else if (value == 2)
                    chickens.Add((i, j));
            }
        }

        DFS(0, 0);

        Console.WriteLine(awnser);
    }
}
