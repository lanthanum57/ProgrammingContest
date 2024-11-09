using System;
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
    }
}
