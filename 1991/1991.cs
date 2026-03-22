using System.Text;

class Program
{
    static char[] left = new char[26];
    static char[] right = new char[26];
    static StringBuilder sb = new StringBuilder();

    static void Preorder(char node)
    {
        if (node == '.')
            return;

        sb.Append(node);
        Preorder(left[node - 'A']);
        Preorder(right[node - 'A']);
    }

    static void Inorder(char node)
    {
        if (node == '.')
            return;

        Inorder(left[node - 'A']);
        sb.Append(node);
        Inorder(right[node - 'A']);
    }

    static void Postorder(char node)
    {
        if (node == '.')
            return;

        Postorder(left[node - 'A']);
        Postorder(right[node - 'A']);
        sb.Append(node);
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < 26; i++)
        {
            left[i] = '.';
            right[i] = '.';
        }

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            char parent = input[0][0];
            char l = input[1][0];
            char r = input[2][0];

            left[parent - 'A'] = l;
            right[parent - 'A'] = r;
        }

        Preorder('A');
        Console.WriteLine(sb.ToString());

        sb.Clear();
        Inorder('A');
        Console.WriteLine(sb.ToString());

        sb.Clear();
        Postorder('A');
        Console.WriteLine(sb.ToString());

    }
}
