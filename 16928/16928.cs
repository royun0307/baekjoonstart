using System;
using System.Collections.Generic;

class Program 
{
    static void Main()
    {
        string[] nm = Console.ReadLine()!.Split();
        int n = int.Parse(nm[0]); //사다리 수
        int m = int.Parse(nm[1]); //뱀 수

        int[] move = new int[101]; //사다리/뱀
        bool[] visitied = new bool[101]; //방문 여부
        int[] dist = new int[101]; //최소 주사위 횟수

        //사다리/뱀 정보 입력
        for (int i = 0; i < n + m; i++) 
        {
            string[] input = Console.ReadLine()!.Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            move[x] = y;
        }

        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        visitied[1] = true;
        dist[1] = 0;

        while (q.Count > 0)
        {
            int cur = q.Dequeue();
            
            //도착
            if (cur == 100)
            {
                Console.WriteLine(dist[cur]);
                return;
            }

            for (int dice = 1; dice <= 6; dice++)
            {
                int next = cur + dice;
                if (next > 100)
                    continue;

                //사다리/뱀
                if (move[next] != 0)
                    next = move[next];

                if (!visitied[next])
                {
                    visitied[next] = true;
                    dist[next] = dist[cur] + 1;
                    q.Enqueue(next);
                }
            }
        }
    }
}
