using System;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] inputA = Console.ReadLine().Split(" ");

        int indexA1 = 0;
        int indexA2 = 0;
        int indexA3 = 0;

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