using System;
class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[,] points = new int[1501, 1501];

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(" ");
            int X = int.Parse(input[0]);
            int Y = int.Parse(input[1]);

            points[X, Y] += 1;
        }

        // 横の合計
        for (int i = 1; i <= 1500; i++)
        {
            int beforePoint = 0;
            for (int j = 1; j <= 1500; j++)
            {
                points[i, j] += beforePoint;
                beforePoint = points[i, j];
            }
        }

        // 縦の合計
        for (int i = 1; i <= 1500; i++)
        {
            int beforePoint = 0;
            for (int j = 1; j <= 1500; j++)
            {
                points[j, i] += beforePoint;
                beforePoint = points[j, i];
            }
        }

        int Q = int.Parse(Console.ReadLine());
        List<int> sums = new List<int>();
        for (int i = 0; i < Q; i++)
        {
            string[] input = Console.ReadLine().Split(" ");
            int a1 = int.Parse(input[0]);
            int b1 = int.Parse(input[1]);
            int a2 = int.Parse(input[2]);
            int b2 = int.Parse(input[3]);

            //int point1 = points[a1, b1];
            //int point2 = points[a2, b2];

            int sum = points[a2, b2] - points[a2, b1 - 1] - points[a1 - 1, b2] + points[a1 - 1, b1 - 1];
            sums.Add(sum);
        }

        foreach (int sum in sums)
        {
            Console.WriteLine(sum);
        }
    }
}