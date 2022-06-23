using System;

namespace ConsoleApp1
{
    class TParallelepiped : TBody
    {
        public TParallelepiped(bool Key = false)
        {
            if (Key)
            {
                Random rand = new Random();
                var maxValue = 15; // Max rand value
                side1 = rand.NextDouble() * maxValue + 0.01;
                side2 = rand.NextDouble() * maxValue + 0.01;
                side3 = rand.NextDouble() * maxValue + 0.01;
            }
        }

        public override double CountS()
        {
            double S = 0;
            S = 2 * (side1 * side2 + side2 * side3 + side3 * side1);
            return S;
        }

        public override double CountV()
        {
            double V;
            V = side1 * side2 * side3;
            return V;
        }
    }

}