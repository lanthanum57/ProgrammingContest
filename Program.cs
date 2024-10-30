using System;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        int n = int.Parse(input[0]); // 使う整数：1～3000
        int k = int.Parse(input[1]); // 合計：3～9000

        int count = 0;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                int l = k - i - j;
                if (l >= 1 && l <= n)
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}