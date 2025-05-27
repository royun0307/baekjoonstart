using System.Text;

class Program 
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

        List<long> sorted = arr.Distinct().ToList();
        sorted.Sort();

        var map = new Dictionary<long, int>(sorted.Count);
        for (int i = 0; i < sorted.Count; i++)
        {
            map[sorted[i]] = i;
        }

        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(map[arr[i]]);
            if (i < n - 1)
            {
                sb.Append(" ");
            }
        }
        Console.WriteLine(sb);
    }
}
