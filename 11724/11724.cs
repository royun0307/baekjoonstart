namespace backjoonC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parts = Console.ReadLine().Split();
            int n = int.Parse(parts[0]);
            int m = int.Parse(parts[1]);

            var adj = new List<int>[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                adj[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                parts = Console.ReadLine().Split();
                int u = int.Parse(parts[0]);
                int v = int.Parse(parts[1]);
                adj[u].Add(v);
                adj[v].Add(u);
            }

            int result = 0;
            var visited = new bool[n + 1];
            var stack = new Stack<int>();

            for (int i = 1; i < n + 1; i++)
            {
                if (!visited[i])
                {
                    result++;
                    visited[i] = true;
                    stack.Push(i);

                    while (stack.Count > 0) 
                    {
                        int top = stack.Pop();
                        foreach (int v in adj[top])
                        {
                            if (!visited[v])
                            {
                                visited[v] = true;
                                stack.Push((int)v);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
