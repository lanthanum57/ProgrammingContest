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

        AtCorder自動採点
        https://atcoder.jp/contests/tessoku-book

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

        public void A04()
        {
             // 10進数→2進数
            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;

            for (int i = 9; i >= 0; i--)
            {
                int wari = Convert.ToInt32(Math.Pow(2, i)); // 2のi乗を求める。
                result += (n / wari).ToString();
                n = n % wari;
            }

            Console.WriteLine(result);
        }

        public void B04()
        {
            // 2進数→10進数
            string n = Console.ReadLine();
            double result = 0;

            int x = 0;
            for (int i = n.Length; i > 0; i--)
            {
                if (n[i - 1] == '1')
                {
                    result += Math.Pow(2, x);
                }

                x++;
            }

            Console.WriteLine(result);
        }

        public void A05()
        {
            /*
            愚直に3つの変数をループさせると10億回を余裕で超えてしまう。
            ここでは、3つ目の変数は、2つの変数が決まると自ずと決まるという性質を利用することで
            2つの変数をループするだけでパターンを求めることができる。
            */
            string[] input = Console.ReadLine().Split(" ");
            int n = int.Parse(input[0]); // 使う整数：1～3000
            int k = int.Parse(input[1]); // 合計：3～9000

            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    int l = k - i - j;
                    if (l >= 1 && l <= n)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        /* ビット全探索
         *
         * N枚のカードから任意のカードを選び、合計がSとなる組み合わせは何通りあるか。
         * NAがカードの数字である。
         * 
         * N枚のカードを選ぶすべての組み合わせは、N重ループすれば求められるが、Nが大きくなると計算量が大きくなりすぎる。
         * こういう場合に、ビット全探索を使用すると効率の良いアルゴリズムとなる。
         * 
         * 例えば、N=3の場合で考える
         * 組み合わせは、ビット(0:選ばない、1:選ぶ)で表すと、以下の通りとなる。
         * （右側の数字はビットを10進数で表した場合の数字）
         * [0, 0, 0] = 0
         * [0, 0 ,1] = 1
         * [0, 1 ,0] = 2
         * [0, 1 ,1] = 3
         * [1, 0 ,0] = 4
         * [1, 0 ,1] = 5
         * [1, 1 ,0] = 6
         * [1, 1 ,1] = 7
         * 
         * よって、8通りとなる。
         * このことから、0以上、(1<<3)未満でループすることで、全パターン網羅できることが分かる。
         * このときのループ変数をiとする。
         * 1を3bit左シフトすると、[1, 0, 0, 0] = 8
         * 
         * 後は、3枚のカードの1枚1枚に対して、bitが立っているか確認し、立っていれば、合計に数字を足す。
         * よって更に内側で、0以上3未満でループする。
         * このときのループ変数をjとする。
         * 
         * そして、iと1<<jの部分和(AND)を取ると、bitが立っていない場合は、0になるので、0以外ならbitが立っている。
         * [0, 1, 1] & [0, 0. 1] = 1 => bit立っているので合計に数字を足す 
         * [0, 1, 0] & [0, 0, 1] = 0 => bit立っていないので何もしない
         * 
         */
        public void BitBruteForce()
        {
            int N = int.Parse(Console.ReadLine());
            string[] NA = Console.ReadLine().Split(" ");
            int S = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < 1 << N; i++)
            {
                int sum = 0;
                for (int j = 0; j < N; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        sum += int.Parse(NA[j]);
                    }
                }

                if (sum == S)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
