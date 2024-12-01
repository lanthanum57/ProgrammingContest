using ProgrammingContest.lib;
using System;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        int N = int.Parse(input[0]);
        int X = int.Parse(input[1]);

        string[] AN = Console.ReadLine().Split(" ");

        Console.WriteLine(CommonArgorithm.BinarySearch(AN, X));
    }
}