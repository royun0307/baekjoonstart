namespace backjoonC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            string input = Console.ReadLine();
            string[] num = input.Split(' ');
            n = int.Parse(num[0]);
            m = int.Parse(num[1]);

            Dictionary<string, string> map = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string memo = Console.ReadLine();
                string[] str = memo.Split(' ');
                string site = str[0];
                string password = str[1];
                map.Add(site, password);
            }

            for (int i = 0; i < m; i++) 
            { 
                string key = Console.ReadLine();
                Console.WriteLine(map[key]);
            }
        }
    }
}
