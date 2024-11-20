using System;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        int H = int.Parse(input[0]);
        int W = int.Parse(input[1]);

        int[,] X = new int[H + 1, W + 1];

        // 初期化
        for (int i = 0; i <= H; i++)
        {
            for (int j = 0; j <= W; j++)
            {
                X[i, j] = 0;
            }
        }

        // 値の取得
        // 横方向の累積和
        for (int i = 1; i <= H; i++)
        {
            string[] inputX = Console.ReadLine().Split(" ");
            int beforeValue = 0;
            for (int j = 1; j <= W; j++)
            {
                X[i, j] = int.Parse(inputX[j - 1]) + beforeValue;

                // 次の値に加算する値
                beforeValue = X[i, j];
            }
        }

        // 縦方向の累積和
        for (int i = 1; i <= W; i++)
        {
            int beforeValue = 0;
            for (int j = 1; j <= H; j++)
            {
                X[j, i] += beforeValue;
                beforeValue = X[j, i];
            }
        }


        // 質問への回答
        int Q = int.Parse(Console.ReadLine());

        for (int i = 0; i < Q; i++)
        {
            string[] question = Console.ReadLine().Split(" ");
            int A = int.Parse(question[0]);
            int B = int.Parse(question[1]);
            int C = int.Parse(question[2]);
            int D = int.Parse(question[3]);

            int ans = X[C, D] + X[A - 1, B - 1] - X[A - 1, D] - X[C, B - 1];
            Console.WriteLine(ans);
        }
    }
}