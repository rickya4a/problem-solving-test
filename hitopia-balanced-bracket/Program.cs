using System;
using System.Collections.Generic;

public class BalancedBrackets
{
    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in s)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}')
            {
                if (stack.Count == 0) return false;

                char top = stack.Pop();
                if (!IsMatchingPair(top, ch)) return false;
            }
        }

        return stack.Count == 0;
    }

    private static bool IsMatchingPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '[' && close == ']') ||
               (open == '{' && close == '}');
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter brackets: ");
        string input = Console.ReadLine();

        bool result = IsBalanced(input);
        Console.WriteLine(result ? "YES" : "NO");
    }
}
