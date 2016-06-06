//1_task

namespace NumberDecomposition
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            double b1 = 5;
            double n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("b{0} = {1}", i, rec(i));
            }
        }
        static double rec(double x)
        {
            if (x != 1)
            {
                return rec(x - 1) / (x * x + x + 1);
            }
            else
                return 5;
        }
    }
}


// 2_task

namespace NumberDecomposition
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            double n = Convert.ToInt32(Console.ReadLine());
            double x = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("b{0} = {1}", i, rec(i,x));
            }
        }
        static double rec(double x,double u)
        {
            if (x != 1)
            {
                return Math.Sin(rec(x-1,u)+Math.PI);
            }
            else
                return u;
        }
    }
}
