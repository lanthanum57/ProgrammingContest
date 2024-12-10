using System;
class Program
{
    static void Main(string[] args)
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