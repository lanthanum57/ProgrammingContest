using System;
class Program
{
    static void Main(string[] args)
    {
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
}