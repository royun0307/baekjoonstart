using System;
using System.Numerics;
using System.Text;

class Program
{
    static List<int> preorder = new List<int>();
    static StringBuilder sb = new StringBuilder();

    static void PostOrder(int start, int end)
    {
        if (start > end)
            return;

        int root = preorder[start];
        int split = end + 1;

        for (int i = start + 1; i <= end; i++)
        {
            if (preorder[i] > root)
            {
                split = i;
                break;
            }
        }

        PostOrder(start + 1, split - 1);

        PostOrder(split, end);

        sb.AppendLine(root.ToString());
    }

    public static void Main()
    {
        string line;
        while ((line = Console.ReadLine()) != null && line != "")
        {
            preorder.Add(int.Parse(line));
        }

        PostOrder(0, preorder.Count - 1);

        Console.Write(sb.ToString());
    }
}
