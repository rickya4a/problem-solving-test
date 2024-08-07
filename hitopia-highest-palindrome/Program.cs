using System;

class HighestPalindrome
{
    public static string GetHighestPalindrome(string s, int k)
    {
        char[] number = s.ToCharArray();
        int n = number.Length;
        bool[] changed = new bool[n];
        int l = 0, r = n - 1;
        while (l < r)
        {
            if (number[l] != number[r])
            {
                if (number[l] > number[r])
                {
                    number[r] = number[l];
                }
                else
                {
                    number[l] = number[r];
                }
                changed[l] = changed[r] = true;
                k--;
            }
            l++;
            r--;
        }

        if (k < 0) return "-1";

        l = 0;
        r = n - 1;
        while (l <= r)
        {
            if (l == r && k > 0)
            {
                number[l] = '9';
            }
            if (number[l] < '9')
            {
                if (changed[l] || changed[r])
                {
                    if (number[l] != '9')
                    {
                        number[l] = number[r] = '9';
                        k--;
                    }
                }
                else if (k >= 2)
                {
                    number[l] = number[r] = '9';
                    k -= 2;
                }
            }
            l++;
            r--;
        }

        return new string(number);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("S:");
        string s = Console.ReadLine();

        Console.WriteLine("K:");
        int k = int.Parse(Console.ReadLine());

        string result = GetHighestPalindrome(s, k);
        Console.WriteLine("Highest palindrome: " + result);
    }
}
