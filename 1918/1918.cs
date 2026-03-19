using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static int Priorty(char op)
    {
        if (op == '+' || op == '-')
            return 1;
        if (op == '*' || op == '/')
            return 2;
        return 0;
    }

    public static void Main()
    {
        string input = Console.ReadLine()!;
        Stack<char> stack = new Stack<char>();
        StringBuilder sb = new StringBuilder();

        foreach (char c in input)
        {
            if (c >= 'A' && c <= 'Z')
            {
                sb.Append(c);
            }
            else if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                { 
                    sb.Append(stack.Pop());
                }

                if (stack.Count > 0)
                    stack.Pop();
            }
            else
            {
                while (stack.Count > 0 && stack.Peek() != '('
                    && Priorty(stack.Peek()) >= Priorty(c))
                {
                    sb.Append(stack.Pop());
                }

                stack.Push(c);
            }
        }

        while (stack.Count > 0)
        {
            sb.Append(stack.Pop());
        }

        Console.Write(sb.ToString());
    }
}
