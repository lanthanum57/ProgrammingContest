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
    }
}
