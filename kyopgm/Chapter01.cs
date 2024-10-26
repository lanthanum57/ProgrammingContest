using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingContest.kyopgm
{
    internal class Chapter01
    {
        /*
         家庭用PCの計算スペックは、毎秒10億回程度。
        このスペックを基準として、基準時間内に計算が終わるかどうか判定する。

        応用問題の解説ページ
        https://github.com/E869120/kyopro-tessoku
         */

        public void A01()
        {
            int n = int.Parse(Console.ReadLine());

            //出力
            Console.WriteLine(n * n);
        }

        public void B01()
        {
            string[] input = Console.ReadLine().Split(" ");
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            //出力
            Console.WriteLine(a + b);
        }

        public void A02()
        {
            string[] input = Console.ReadLine().Split(" ");
            string[] numbers = Console.ReadLine().Split(" ");

            // 書籍通りの全探索をする場合は、foreachで一致するものを探す。
            // 見つかったらCosoleに書き出してリターンすることで少し計算量少なくなる。
            if (numbers.Where(x => x == input[1]).Any())
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public void B02()
        {
            string[] input = Console.ReadLine().Split(" ");
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            for (int i = a; i <= b; i++)
            {
                if (100 % i == 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
            Console.WriteLine("No");
        }

        public void A03()
        {
            string[] input = Console.ReadLine().Split(" ");
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            string[] inputP = Console.ReadLine().Split(" ");
            string[] inputQ = Console.ReadLine().Split(" ");

            foreach (string ps in inputP)
            {
                int p = int.Parse(ps);
                foreach (string qs in inputQ)
                {
                    int q = int.Parse(qs);
                    if (p + q == k)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
            }
            Console.WriteLine("No");
        }

        public void B03()
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputA = Console.ReadLine().Split(" ");

            int indexA1 = 0;
            int indexA2 = 0;
            int indexA3 = 0;

            // forで、i,j,kの3つの変数を用意すると、jはi+1からループし、kはj+1からループすることで
            // 自身かどうかの判定が不要となる。
            // コードが簡潔になるので、以下よりもこちらの方が良い。
            foreach (string a1 in inputA)
            {
                foreach (string a2 in inputA)
                {
                    if (indexA1 == indexA2) continue;

                    foreach (string a3 in inputA)
                    {
                        if (indexA1 == indexA3 || indexA2 == indexA3) continue;

                        if (int.Parse(a1) + int.Parse(a2) + int.Parse(a3) == 1000)
                        {
                            Console.WriteLine("Yes");
                            return;
                        }

                        indexA3++;
                    }

                    indexA3 = 0;
                    indexA2++;
                }

                indexA2 = 0;
                indexA1++;
            }

            Console.WriteLine("No");
        }
    }
}
