using System;
class Program
{
    static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        // 0～T時の増減
        int[] zougen = new int[T + 1];

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(" ");
            int beginTime = int.Parse(input[0]);
            int endTime = int.Parse(input[1]);

            zougen[beginTime] += 1;
            zougen[endTime] -= 1;
        }

        int before = 0;
        for (int i = 0; i < T; i++)
        {
            int sum = zougen[i] + before;
            Console.WriteLine(sum);
            before = sum;
        }
    }
}