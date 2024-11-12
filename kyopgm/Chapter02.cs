﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
