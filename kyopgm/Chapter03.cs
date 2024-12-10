using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingContest.kyopgm
{
    internal class Chapter03
    {
        // 二分探索
        // 配列が昇順でソートされていることが前提。
        // ソートされていないと正しい値が得られないため、ソートする処理を追加する必要がある。
        // ※ C#には二分探索の以下の標準ライブラリが用意されている。
        //     Array.BinarySearch(numbers, 7); --> 見つからない場合は、目的の数字よりも小さいものの内の最大値のindex*-1が返る。
        //     例えば、3,5,7,10 で6を探す場合は、-1が返る。
        //                        7を探す場合は、2が返る。
        //
        private void A11()
        {
            string[] input = Console.ReadLine().Split(" ");
            int N = int.Parse(input[0]);
            int X = int.Parse(input[1]);

            string[] AN = Console.ReadLine().Split(" ");

            int beginIndex = 1;
            int endIndex = N;
            while (beginIndex < endIndex)
            {
                int centerIndex = (beginIndex + endIndex) / 2;

                int centerValue = int.Parse(AN[centerIndex - 1]);

                if (X == centerValue)
                {
                    beginIndex = centerIndex;
                    break;
                }
                else if (X > centerValue)
                {
                    beginIndex = centerIndex + 1;
                }
                else
                {
                    endIndex = centerIndex - 1;
                }
            }

            Console.WriteLine(beginIndex);
        }

        private void B11()
        {
            int N = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(" ");

            int[] numbers = new int[N];
            for (int i = 0; i < N; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            // Sort
            Array.Sort(numbers);

            int Q = int.Parse(Console.ReadLine());
            for (int i = 1; i <= Q; i++)
            {
                int X = int.Parse(Console.ReadLine());
                int XIndex = Array.BinarySearch(numbers, X);

                if (XIndex < 0)
                {
                    Console.WriteLine(XIndex * -1 - 1);
                }
                else
                {
                    Console.WriteLine(XIndex);
                }
            }
        }

        // 回答に対して二分探索を実施する手法。
        // 問題に含まれる回答の取り得る値に対して、二分探索して回答を絞り込んでいく。
        public void A12()
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

        public void B12()
        {
            int N = int.Parse(Console.ReadLine());

            double left = 0;
            double right = 100;
            double mid = 0;

            for (int i = 0; i < 20; i++)
            {
                mid = (left + right) / 2.0;
                double val = mid * mid * mid + mid;

                if (val > 1.0 * N)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            Console.WriteLine(mid);
        }
    }
}
