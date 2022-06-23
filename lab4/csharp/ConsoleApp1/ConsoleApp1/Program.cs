using System;

namespace ConsoleApp1
{
    
    internal class Program
    {
        static double SumV(TBall[] balls, int n)
        {
            double result = 0;
            for(int i = 0; i < n; i++)
            {
                result += balls[i].CountV();
            }
            return result;
        }

        static double SumS(TParallelepiped[] parallelepipeds, int n)
        {
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                result += parallelepipeds[i].CountS();
            }
            return result;
        }
        static void InfoBalls(TBall[] balls, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Ball number {i + 1}");
                Console.WriteLine($"R = {balls[i].side1} , S = {balls[i].CountS()}, V = {balls[i].CountV()}");
                Console.WriteLine();
            }
        }

        static void InfoParallelepipeds(TParallelepiped[] parallelepipeds, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Parallelepiped number {i + 1}");
                Console.WriteLine($"a = {parallelepipeds[i].side1} , b = {parallelepipeds[i].side2} , c = {parallelepipeds[i].side3} , S = {parallelepipeds[i].CountS()}, V = {parallelepipeds[i].CountV()}");
                Console.WriteLine();
            }
        }

        static TBall[] setBalls(int n)
        {
            TBall[] balls = new TBall[n];
            for(int i = 0; i < n; i++)
            {
                Console.Write("Do you want to generate ball automatically (yes/no)?");
                if(Console.ReadLine() == "yes")
                {
                    balls[i] = new TBall(true);
                }
                else
                {
                    balls[i] = new TBall();
                    Console.Write("Input radius:");
                    double R = double.Parse(Console.ReadLine());
                    balls[i].side1 = R;
                }
            }
            return balls;
        }
        static TParallelepiped[] setParallelepipeds(int m)
        {
            TParallelepiped[] parallelepipeds = new TParallelepiped[m];
            for (int i = 0; i < m; i++)
            {
                Console.Write("Do you want to generate parallelepiped automatically (yes/no)?");
                if (Console.ReadLine() == "yes")
                {
                    parallelepipeds[i] = new TParallelepiped(true);
                }
                else
                {
                    parallelepipeds[i] = new TParallelepiped();
                    Console.Write("Input side1:");
                    double a = double.Parse(Console.ReadLine());
                    parallelepipeds[i].side1 = a;
                    Console.Write("Input side2:");
                    double b = double.Parse(Console.ReadLine());
                    parallelepipeds[i].side2 = b;
                    Console.Write("Input side3:");
                    double c = double.Parse(Console.ReadLine());
                    parallelepipeds[i].side3 = c;
                }
            }
            return parallelepipeds;
        } 
        static void Main(string[] args)
        {
            int n;
            Console.Write("Input number of figures:");
            n = int.Parse(Console.ReadLine());
            Random rand = new Random();
            int m = rand.Next(1, n-1);
            n -= m;
            Console.WriteLine($"We will create {n} ball and {m} parallelepipeds!");
            TBall[] balls = setBalls(n);
            TParallelepiped[] parallelepipeds = setParallelepipeds(m);
            Console.WriteLine();
            InfoBalls(balls, n);
            InfoParallelepipeds(parallelepipeds, m);
            Console.WriteLine($"Sum of balls' volumes = {SumV(balls, n)}");
            Console.WriteLine($"Sum of parallelepipeds' areas = {SumS(parallelepipeds, m)}");
        }
    }
}
