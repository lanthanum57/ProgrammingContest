using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingContest.atcorder
{
    internal class BeginnerContest373
    {
        private void A()
        {
            int count = 0;

            string[] input = new string[12];
            for (int i = 1; i <= 12; i++)
            {
                input[i - 1] = Console.ReadLine();
                if (input[i - 1].Length == i)
                {
                    count++;
                }
            }

            //出力
            Console.WriteLine(count);
        }

        private void B()
        {
            string key = Console.ReadLine();
            List<string> keys = new List<string>();

            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < 26; i++)
            {
                keys.Add(key.Substring(i, 1));
            }

            int distance = 0;
            int beforeIndex = 0;
            for (int i = 0; i < 26; i++)
            {
                string a = input.Substring(i, 1);
                int index = keys.IndexOf(a);

                if (i > 0)
                {
                    distance += Math.Abs(index - beforeIndex);
                }

                beforeIndex = index;
            }

            //出力
            Console.WriteLine(distance);
        }

        private void C()
        {
            int len = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(" ");
            string[] b = Console.ReadLine().Split(" ");

            int maxA = 0;
            int maxB = 0;
            for (int i = 0; i < len; i++)
            {
                if (i == 0)
                {
                    maxA = int.Parse(a[i]);
                    maxB = int.Parse(b[i]);
                }
                else
                {
                    if (int.Parse(a[i]) > maxA) maxA = int.Parse(a[i]);
                    if (int.Parse(b[i]) > maxB) maxB = int.Parse(b[i]);
                }

            }

            //出力
            Console.WriteLine((maxA + maxB));
        }
    }
}
