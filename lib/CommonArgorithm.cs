using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingContest.lib
{
    internal class CommonArgorithm
    {
        /// <summary>
        /// 与えられた配列(targetList)のどこに指定の値(targetValue)が存在するか
        /// 二分探索手法で検索して、一致するindexを返します。
        /// 計算量はlogNとなります。
        /// </summary>
        /// <param name="targetList">検索対象の配列</param>
        /// <param name="targetValue">検索対象の値</param>
        /// <returns></returns>
        public static int BinarySearch(string[] targetList, int targetValue)
        {
            int beginIndex = 1;
            int endIndex = targetList.Length;
            while (beginIndex < endIndex)
            {
                int centerIndex = (beginIndex + endIndex) / 2;

                int centerValue = int.Parse(targetList[centerIndex - 1]);

                if (targetValue == centerValue)
                {
                    beginIndex = centerIndex;
                    break;
                }
                else if (targetValue > centerValue)
                {
                    beginIndex = centerIndex + 1;
                }
                else
                {
                    endIndex = centerIndex - 1;
                }
            }

            return beginIndex;
        }
    }
}
