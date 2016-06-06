//  1_task
namespace NumberDecomposition
{
    using System;
    using System.Collections.Generic;

    /*
        Все вынес в отдельный класс BigDecompositor
        По методам раскидал, но не идеально.
        Прога может только выводить в консоль, она не запоминает результат, хотя, если, захочет, можно и это запилить.
    */

    class Programy
    {
        static void Main(string[] args)
        {
            int f = Convert.ToInt32(Console.ReadLine());
            double r = Convert.ToDouble(Console.ReadLine());
            double s = 0,t;
            for (int i = 1; i <= f; i++)
            {
                t=1/(Math.Sqrt(i));
                s += t;
            }
            Console.WriteLine(s);
                Console.ReadLine();
        }
    }
}

// 2_task
namespace NumberDecomposition
{
    using System;
    using System.Collections.Generic;


    class Programy
    {
        static void Main(string[] args)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            int x = Convert.ToInt32(Console.ReadLine());
            double s = 1;
            int y = -1;
            int xx = x*x*x;
            int kk = 8;
            for (int i = 2; i <= k; i++)
            {
                y = y * (-1);
                s = s*(1+y*xx/(kk-1));
                xx = xx * x * x;
                kk = i * i * i;
            }
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}


// 3_task
namespace NumberDecomposition
{
    using System;
    using System.Collections.Generic;


    class Programy
    {
        static int integr(int u)
        {
            int f=1;
            int ii = 1;
            while(f<=u){
                f++;
                ii *= f;
            }
            return ii;
        }
        static void Main(string[] args)
        {
            double e = Convert.ToInt32(Console.ReadLine());
            double s = 0;
            int y = -1;
            int i = 1;
            double znach = -1;
            while (znach > e)
            {
                znach = y / integr(2 * i- 1);
                i++;
                y *= -1;
                s += znach;
            }
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
