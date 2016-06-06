//I. Разработать рекурсивный метод (возвращающий значение):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltasks
{
    class Program
    {


        static double B(int n)
        {
            return n == 1 ? 5 : B(n - 1) * (n * n + n + 1);
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; ++i)
            {
                Console.WriteLine("b{0,-2} = {1}", i, B(i));
            }
            Console.ReadLine();
        }

    }

    }

    //2.	Даны первый член и знаменатель геометрической прогрессии. Написать рекурсивный метод для нахождения n-го члена
    // и суммы n первых членов прогрессии.

    using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.ComponentModel;
  using System.Data;
  using System.Drawing;

  using System.IO;
  namespace alltasks
  {
      class Program
      {
          static void Main()
          {
              int u = 0;
              int sum = 2;
              Console.WriteLine(rec(4,2,2,ref u,ref sum));
              Console.WriteLine(sum);

          }
          static int rec(int n,int f,int z,ref int i,ref int sum)//n-ый член, предыдущий член, знаменатель, индекс для рекметода, сумма
          {
              f *= z;
              sum += f;
              if(i< n)
              {
                  i++;
                  f=rec(n, f, z, ref i,ref sum);

              }
              return f;
          }
      }
  }
