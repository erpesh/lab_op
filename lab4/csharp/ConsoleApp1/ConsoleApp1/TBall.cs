using System;

namespace ConsoleApp1
{
    
    class TBall : TBody
    {
        public TBall(bool Key = false)
        {
            side3 = -1;
            side2 = -1;
            if (Key)
            {
                Random rand = new Random();
                side1 = rand.NextDouble() * 15 + 0.01;
            }
        }
        public override double CountS()
        {
            double S;
            S = 4 * Math.PI * Math.Pow(side1, 2);
            return S;
        }
        public override double CountV()
        {
            double V;
            V = 4 * Math.PI * Math.Pow(side1, 3) / 3;
            return V;
        }
    }
}