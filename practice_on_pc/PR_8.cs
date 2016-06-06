/*
I.Дана последовательность целых чисел.
Замечание. Задачи из данного пункта решить двумя способами, используя одномерный массив, а затем двумерный.
Размерность массива вводится с клавиатуры.
*/

// Заменить все элементы, попадающие в интервал [a, b], нулем.
// Одномерный массив.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltasks
{
    class Program
    {


        static int[] Input()
        {
            Console.Write("Введите размерность массива: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Console.Write("a[{0}]= ", i);
                a[i] = int.Parse(Console.ReadLine());
            }
            return a;
        }

        static void Print(int[] a)
        {
            for (int i = 0; i < a.Length; ++i) Console.Write("{0} ", a[i]);
            Console.WriteLine();
        }

        static void Change(int[] a)
        {
            Console.Write("Введите начало диапазона: ");
            int aa = Int32.Parse(Console.ReadLine());

            Console.Write("Введите конец диапазона: ");
            int bb = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < a.Length; ++i)
                if (a[i] <= bb && a[i] >= aa) a[i] = 0;
        }

        static void Main()
        {
            int[] myArray = Input();
            Console.WriteLine("Исходный массив:");
            Print(myArray);
            Change(myArray);
            Console.WriteLine("Измененный массив:");
            Print(myArray);
            Console.ReadKey();
        }


    }
}
// двумерный массив

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltasks
{
  class Program
  {


      static int[,] Input(out int n, out int m)
      {
          Console.WriteLine("Введите размерность массива.");
          Console.Write("n = ");
          n = int.Parse(Console.ReadLine());
          Console.Write("m = ");
          m = int.Parse(Console.ReadLine());
          int[,] a = new int[n, m];
          for (int i = 0; i < n; ++i)
              for (int j = 0; j < m; ++j)
              {
                  Console.Write("a[{0},{1}]= ", i, j);
                  a[i, j] = int.Parse(Console.ReadLine());
              }
          return a;
      }

      static void Print(int[,] a)
      {
          for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
              for (int j = 0; j < a.GetLength(1); ++j)
                  Console.Write("{0,5} ", a[i, j]);
      }

      static void Change(int[,] a)
      {

          Console.Write("Введите начало диапазона: ");
          int aa = Int32.Parse(Console.ReadLine());

          Console.Write("Введите конец диапазона: ");
          int bb = Int32.Parse(Console.ReadLine());

          for (int i = 0; i < a.GetLength(0); ++i)
              for (int j = 0; j < a.GetLength(1); ++j)
                  if (a[i, j] >= aa && a[i, j] <= bb) a[i, j] = 0;
      }

      static void Main()
      {
          int n, m;
          int[,] myArray = Input(out n, out m);
          Console.WriteLine("Исходный массив:");
          Print(myArray);
          Change(myArray);
          Console.WriteLine("Измененный массив:");
          Print(myArray);
          Console.ReadKey();
      }



  }
}


/*
II. Дана последовательность из n действительных чисел.
Замечание. Задачи из данного пункта решить, используя одномерный массив
*/

// Заменить все максимальные элементы нулями.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltasks
{
    class Program
    {


        static int[] Input()
        {
            Console.Write("Введите размерность массива: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Console.Write("a[{0}]= ", i);
                a[i] = int.Parse(Console.ReadLine());
            }
            return a;
        }

        static void Print(int[] a)
        {
            for (int i = 0; i < a.Length; ++i) Console.Write("{0} ", a[i]);
            Console.WriteLine();
        }

        static void Change(int[] a)
        {

            int max = a[0];
            for (int i = 1; i < a.Length; ++i)
                if (a[i] > max) max = a[i];
            Console.WriteLine("max is {0}",max);

            for (int i = 1; i < a.Length; ++i)
                if (a[i] == max) a[i] = 0;


        }

        static void Main()
        {
            int[] myArray = Input();
            Console.WriteLine("Исходный массив:");
            Print(myArray);
            Change(myArray);
            Console.WriteLine("Измененный массив:");
            Print(myArray);
            Console.ReadKey();
        }


    }
}

/*
III. Дан массив размером  n×n, элементы которого целые числа.
Замечание. При решении задач из данного пункта использовать двумерный массив.
*/

//Подсчитать сумму элементов, расположенных на побочной диагонали.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltasks
{
    class Program
    {


        static int[,] Input(out int n)
        {
            Console.WriteLine("Введите размерность массива:");
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("a[{0},{1}]= ", i, j);
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            return a;
        }

        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < a.GetLength(1); ++j)
                    Console.Write("{0,5} ", a[i, j]);
        }

        static int Sum(int[,] a, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i + j == n - 1)
                        sum += a[i, j];
                }
            }
            return sum;
        }

            static void Main()
        {
                int n;
                int[,] myArray = Input(out n);
                Console.WriteLine("Исходный массив:");
                Print(myArray);

                Console.WriteLine("сумма = {0}", Sum(myArray, n));
            Console.ReadLine();
            }



        }
    }
/*

IV. Дан массив размером  n×n, элементы которого целые числа.
Замечание. Для хранения массив n×n использовать ступенчатый массив.

*/

//Нечетные строки таблицы заменить на вектор Х.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltasks
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите размерность: ");
            int n = Int32.Parse(Console.ReadLine());
            int[][] M = new int[n][];
            Console.WriteLine("Вводим массив: ");
            for (int i = 0; i < n; i++)
                //вводим массив

                M[i] = (Console.ReadLine()).Split(' ').Select(x => Int32.Parse(x)).ToArray();


            //ввод вектора
            Console.Write("Ввод вектора");
            int[] X = (Console.ReadLine()).Split(' ').Select(x => Int32.Parse(x)).ToArray();

            for (int i = 1; i < M.Length; i += 2)//Если нумерация с 0... либо поставить i = 0 изначально
                M[i] = X;

            foreach (var x in M)
            {
                foreach (var Item in x)
                {
                    Console.Write("{0} ", Item);
                }
                Console.WriteLine();
            }


            Console.ReadLine();
        }




    }
}
