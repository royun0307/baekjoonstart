namespace backjoonC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, k;
            Stack<int> stack = new Stack<int>();
            string input = Console.ReadLine();
            string[] num = input.Split(' ');
            n = int.Parse(num[0]);
            k = int.Parse(num[1]);

            for (int i = 0; i < n; i++)
            { 
                int value = int.Parse(Console.ReadLine());
                stack.Push(value);
            }
            int count = 0;
            while(k != 0)
            {
                int coin = stack.Pop();
                while (k >= coin)
                {
                    k -= coin;
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
