using System;
using System.Globalization;
class Program
{
    static void Main(string[] args)
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