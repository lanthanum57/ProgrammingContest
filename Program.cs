using System;
class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string[] inputA = Console.ReadLine().Split(" ");
        int[] maxBegin = new int[N];
        int[] maxEnd = new int[N];

        // 先頭からの最大値を格納
        int max = 0;
        for (int i = 0; i < N; i++)
        {
            if (max < int.Parse(inputA[i]))
            {
                max = int.Parse(inputA[i]);
            }

            maxBegin[i] = max;
        }

        // 末尾からの最大値を格納
        max = 0;
        for (int i = N - 1; i >= 0; i--)
        {
            if (max < int.Parse(inputA[i]))
            {
                max = int.Parse(inputA[i]);
            }

            maxEnd[i] = max;
        }

        int D = int.Parse(Console.ReadLine());

        for (int i = 0; i < D; i++)
        {
            string[] input = Console.ReadLine().Split(" ");
            int koujiBegin = int.Parse(input[0]) - 1;
            int koujiEnd = int.Parse(input[1]) - 1;

            int resultFrom = 0;
            if (koujiBegin - 1 >= 0)
            {
                resultFrom = maxBegin[koujiBegin - 1];
            }

            int resultTo = 0;
            if (koujiEnd + 1 <= maxEnd.Length - 1)
            {
                resultTo = maxEnd[koujiEnd + 1];
            }

            if (resultFrom < resultTo)
            {
                Console.WriteLine(resultTo);
            }
            else
            {
                Console.WriteLine(resultFrom);
            }
        }
    }
}