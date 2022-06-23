using System;

namespace ConsoleApp1
{
    class TBody
    {
        private double Side1, Side2, Side3;
        
        public double side1
        {
            get { return Side1; }
            set { Side1 = value; }
        }
        public double side2
        {
            get { return Side2; }
            set { Side2 = value; }
        }
        public double side3
        {
            get { return Side3; }
            set { Side3 = value; }
        }

        public virtual double CountS()
        {
            Console.WriteLine("Program is not able to count area of this figure!");
            return -1;
        }
        public virtual double CountV()
        {
            Console.WriteLine("Program is not able to count volume of this figure!");
            return -1;
        }
    }
}