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
    }
}
