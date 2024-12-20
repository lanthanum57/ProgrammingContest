﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingContest.kyopgm
{
    internal class Chapter02
    {
        public void A06()
        {
            string[] input = Console.ReadLine().Split(" ");
            int N = int.Parse(input[0]);
            int Q = int.Parse(input[1]);

            string[] A = Console.ReadLine().Split(" ");

            // 累積和を作成
            int[] SumA = new int[N];
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                SumA[i] = sum + int.Parse(A[i]);
                sum += int.Parse(A[i]);
            }

            int[] result = new int[Q];
            for (int i = 0; i < Q; i++)
            {
                input = Console.ReadLine().Split(" ");
                int begin = int.Parse(input[0]);
                int end = int.Parse(input[1]);

                if (begin >= 2)
                {
                    result[i] = SumA[end - 1] - SumA[begin - 2];
                }
                else
                {
                    result[i] = SumA[end - 1];
                }
            }

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }

        /*
         * ここでは当たりとハズレの累積和をそれぞれ求めておいた方が分かりやすくなる。
         * いまの回答だと少し無理矢理感があり、複雑になると考えが追いつかなくなる可能性がある。
         */
        public void B06()
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

        // 差分を取ってから累積和を計算する手法
        // 通称「いもす法」。
        public void A07()
        {
            int D = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            int[] countDiff = new int[D + 1];

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                int L = int.Parse(input[0]);
                int R = int.Parse(input[1]);

                countDiff[L - 1] += 1;
                countDiff[R] -= 1;
            }

            int before = 0;
            for (int i = 0; i < D; i++)
            {
                int count = countDiff[i] + before;
                Console.WriteLine(count);
                before = count;
            }
        }

        public void B07()
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

        // 2次元の累積和
        // 縦横でそれぞれ累積和を計算
        // -1の場所の値を引くので、予め1つ多く配列を用意しておく。
        public void A08()
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

        // 2次元の累積和
        // 考え方はA08と同じ
        private void B08()
        {
            int N = int.Parse(Console.ReadLine());
            int[,] points = new int[1501, 1501];

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                int X = int.Parse(input[0]);
                int Y = int.Parse(input[1]);

                // 同じ座標に複数の点が存在することもあるので
                // ビットではなく、1ずつ足していく
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

        // 2次元の差分取得後に累積和を計算する手法
        private void A09()
        {
            string[] input = Console.ReadLine().Split(" ");
            int H = int.Parse(input[0]);
            int W = int.Parse(input[1]);
            int N = int.Parse(input[2]);

            int[,] output = new int[H + 2, W + 2];

            for (int i = 0; i < N; i++)
            {
                string[] input2 = Console.ReadLine().Split(" ");
                int AX = int.Parse(input2[0]);
                int AY = int.Parse(input2[1]);
                int BX = int.Parse(input2[2]);
                int BY = int.Parse(input2[3]);

                output[AX, AY] += 1;
                output[BX + 1, BY + 1] += 1;
                output[AX, BY + 1] -= 1;
                output[BX + 1, AY] -= 1;
            }

            // 横の合計
            for (int i = 0; i <= H + 1; i++)
            {
                int before = 0;
                for (int j = 0; j <= W + 1; j++)
                {
                    output[i, j] += before;
                    before = output[i, j];
                }
            }

            // 縦の合計
            for (int i = 0; i <= W + 1; i++)
            {
                int before = 0;
                for (int j = 0; j <= H + 1; j++)
                {
                    output[j, i] += before;
                    before = output[j, i];
                }
            }

            for (int i = 1; i <= H; i++)
            {
                string outStr = string.Empty;
                for (int j = 1; j <= W; j++)
                {
                    {
                        outStr += output[i, j] + " ";
                    }
                }

                Console.WriteLine(outStr.TrimEnd());
            }
        }

        // 配列の間を除外した場合のMAX値を求める
        // 前側の最大値は左から最大値を格納していき、逆に後側の最大値は右から最大値を格納していく。
        // 前側の最大値と、後側の最大値を求め、どちらか大きい方が全体の最大値となる。
        // 累積和の応用となる。
        private void A10()
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
}
