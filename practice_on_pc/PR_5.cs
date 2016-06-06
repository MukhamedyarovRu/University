//Разработать метод min(a,b) для нахождения минимального из двух чисел. Вычислить с помощью него минимальное значение из четырех чисел x, y, z, v.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltasks
{
    class Program
    {
        static int FindMinimal(int a, int b)
        {
            if (a > b) return b;
            else return a;
        }

        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = Int32.Parse(Console.ReadLine());

            Console.Write("b = ");
            int b = Int32.Parse(Console.ReadLine());
            Console.Write("c = ");

            int c = Int32.Parse(Console.ReadLine());

            Console.Write("d = ");
            int d = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("min = {0}",FindMinimal(FindMinimal(a, b), FindMinimal(c, d)));
            Console.ReadLine();
        }
    }
}

//вторая задача

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  namespace alltasks
  {
      class Program
      {
          static double f (double x)
          {
              double y;
              if (x < 3) y = Math.Sin(x);
              else if (x >= 3 && x <= 9) y = (Math.Sqrt((x*x + 1) / (x*x + 5))) ;
              else y = Math.Sqrt(x*x - 1) - Math.Sqrt (x*x - 5);
              return y;
          }

          static void Main(string[] args)
          {
              Console.Write("a=");
              double a = double.Parse(Console.ReadLine());
              Console.Write("b=");
              double b = double.Parse(Console.ReadLine());
              Console.Write("h=");
              double h = double.Parse(Console.ReadLine());
              for (double i = a; i <= b; i += h)
                  Console.WriteLine("f({0:f2})={1:f4}", i, f(i));

              Console.ReadLine();
          }

      }
  }


// Перегрузите метод f из предыдущего раздела так, чтобы его сигнатура (заголовок) соответствовала виду static void f (double x, out double y).
// Продемонстрируйте работу перегруженных методов.

using System;
namespace Hello
{
    class Program
    {
         static double f(double x, out double yy)
        {
            double yy;
            if (x < 3) yy = Math.Sin(x);
            else if (x >= 3 && x <= 9) yy = (Math.Sqrt((x*x + 1) / (x*x + 5))) ;
            else yy = Math.Sqrt(x*x - 1) - Math.Sqrt (x*x - 5);
            y = yy;
            return yy;
        }

        static void Main()
        {

            Console.Write("a=");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b=");
            double b = double.Parse(Console.ReadLine());
            Console.Write("h=");
            double h = double.Parse(Console.ReadLine());
            Program ob =new Program();
            double yy,ii;
            for (double i = a; i <= b; i += h)
            {
                ii = f(i, out yy);
                Console.WriteLine("f({0:f2})={1:f4}, {2}",i, ii, yy);
            }
            Console.ReadKey();
        }
    }
}
