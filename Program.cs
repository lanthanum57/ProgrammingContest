using System;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        int[] prints = new int[100000];
        input = Console.ReadLine().Split(" ");
        for (int i = 1; i <= N; i++)
        {
            prints[i] = int.Parse(input[i - 1]);
        }
        
        long left = 1;
        long right = 1000000000;

        while (left < right)
        {
            long mid = (left + right) / 2;
            if (check(N, K, prints, mid) == false)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        Console.WriteLine(right);
    }

    // 
    private static bool check(int N, int K, int[] input, long x)
    {
        long sum = 0;
        for (int i = 1; i <= N; i++)
        {
            sum += x / input[i];
        }

        if (sum >= K)
        {
            return true;
        }

        return false;
    }
}