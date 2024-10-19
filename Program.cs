using System;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[] args)
    {
        string[] a = Console.ReadLine().Split(" ");
        int n = int.Parse(a[0]);
        int m = int.Parse(a[1]);

        int[] peaks = new int[n];
        List<Point> points = new List<Point>();

        for (int i = 1; i <= m; i++)
        {
            Point p = new Point();
            string[] row = Console.ReadLine().Split(" ");
            p.U = int.Parse(row[0]);
            p.V = int.Parse(row[1]);
            p.W = int.Parse(row[2]);
            p.Done = false;
            points.Add(p);
        }

        Point target = points[0];
        points[0].Done = true;
        while(true)
        {
            target.U
        }

        //出力
        Console.WriteLine();
    }
}

class Point
{
    public int U { get; set; }
    public int V { get; set; }
    public int W { get; set; }
    public bool Done { get; set; }
}