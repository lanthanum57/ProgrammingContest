using System;
class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string[] A = Console.ReadLine().Split(" ");

        int[] sumA = new int[A.Length];
        int beforeA = 0;
        for (int i = 0; i < N; i++)
        {
            sumA[i] = int.Parse(A[i]) + beforeA;
            beforeA = sumA[i];
        }

        int Q = int.Parse(Console.ReadLine());
        string[] answer = new string[Q];

        for (int i = 0; i < Q; i++)
        {
            string[] L = Console.ReadLine().Split(" ");

            int begin = int.Parse(L[0]) - 1;
            int end = int.Parse(L[1]) - 1;

            int num = sumA[end] - sumA[begin];
            if (begin > 0)
            {
                num = sumA[end] - sumA[begin - 1];
            }
            int cnt = end - begin + 1;

            if (num * 2 > cnt)
            {
                answer[i] = "win";
            }
            else if (num * 2 < cnt)
            {
                answer[i] = "lose";
            }
            else
            {
                answer[i] = "draw";
            }
        }

        foreach (string ans in answer)
        {
            Console.WriteLine(ans);
        }

    }
}