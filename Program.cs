using System;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        string[] input2 = Console.ReadLine().Split(" ");
        int[] A = new int[100010];
        for (int i = 1; i <= N; i++)
        {
            A[i] = int.Parse(input2[i - 1]);
        }

        int[] R = new int[100010];

        for (int i = 1; i <= N - 1; i++)
        {
            if (i == 1)
            {
                R[i] = 1;
            }
            else
            {
                R[i] = R[i - 1];
            }

            while (R[i] < N && A[R[i] + 1] - A[i] <= K)
            {
                R[i] += 1;
            }
        }

        long ans = 0;

        for (int i = 1; i <= N - 1; i++)
        {
            ans += R[i] - i;
        }

        Console.WriteLine(ans);
    }
}