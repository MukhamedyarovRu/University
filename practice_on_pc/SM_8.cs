/*
I. В одномерном массиве, элементы которого – целые числа, произвести следующие действия:
1.	Удалить из массива все четные числа.
2.	Вставить новый элемент после всех элементов, которые заканчиваются на данную цифру.
3.	Удалить из массива повторяющиеся элементы, оставив только их первые вхождения.
4.	Вставить новый элемент между всеми парами элементов, имеющими разные знаки.
5.	Уплотнить массив, удалив из него все нулевые значения.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltasks
{
    class Program
    {
        static int[] Input(out int n)
        {
            Console.WriteLine("введите размерность массива");
            n = int.Parse(Console.ReadLine());
            int[] a = new int[n*3];
            int u = 1;
            for (int i = 0; i < n; ++i)
            {
               // Console.Write("a[{0}]= ", i);
                a[i] =u* (i + 7) % 9;//int.Parse(Console.ReadLine());
                u *= -1;
            }
            return a;
        }

        static void Print(int[] a, int n)
        {
            for (int i = 0; i < n; ++i) Console.Write("{0} ", a[i]);
            Console.WriteLine();
            Console.WriteLine();
        }

        static void DeleteArray(int[] a, ref int n, int m)
        {
            for (int i = m; i < n - 1; ++i)
                a[i] = a[i + 1];
            --n;
            a[n] = 0;
        }

        static char hnya(string f)
        {
            Console.WriteLine(f);
            char z = Char.Parse(Console.ReadLine());
            return z;
        }

        static void AddArray(int[] a, ref int n, int m)
        {
            for (int i = n; i >= m; --i)
               // if(i!=0)
                    a[i] = a[i - 1];
            ++n;
            Console.WriteLine("Введите значение нового элемента");
            a[m] = int.Parse(Console.ReadLine());
        }

        static void Main()
        {
            int n;
            int[] myArray = Input(out n);
            Console.WriteLine("Исходный массив:");
            Print(myArray, n);
            Console.WriteLine("Надо ли выполнить следующие операции (если да, то ответтье \"y\"), если нет, то \"n\"");
            string z1 = "1.	Удалить из массива все четные числа?";
            string z2 = "2.	Вставить новый элемент после всех элементов, которые заканчиваются на данную цифру?";
            string z3 = "3.	Удалить из массива повторяющиеся элементы, оставив только их первые вхождения?";
            string z4 = "4.	Вставить новый элемент между всеми парами элементов, имеющими разные знаки?";
            string z5 = "5.	Уплотнить массив, удалив из него все нулевые значения?";
            if (hnya(z1) == 'y')
            {
                for (int i = 0; i < n; i++)
                    if (myArray[i] % 2 == 0)
                    {
                        DeleteArray(myArray, ref n, i);
                        i--;
                    }
                Console.WriteLine("Исходный массив:");
                Print(myArray, n);
            }

            if (hnya(z2) == 'y')
            {
                Console.WriteLine("Введите значеине элемента, после которых надо ввести новоый элемент:");
                int m = int.Parse(Console.ReadLine()); ;
                for (int i = 0; i < n; i++)
                    if (myArray[i] % 10 == m)
                    {
                        AddArray(myArray, ref n, i+1);
                        i=i+2;
                    }
                Console.WriteLine("Измененный массив:");
                Print(myArray, n);
            }

            if (hnya(z3) == 'y')
            {
                for (int i = 0; i < n-1; i++)
                    for (int j = i+1; j < n; j++)
                        if (myArray[i] == myArray[j])
                        {
                            DeleteArray(myArray, ref n, j);
                            j--;
                        }
                Console.WriteLine("Измененный массив:");
                Print(myArray, n);
            }

            if (hnya(z4) == 'y')
            {
                for (int i = 0; i < n-1; i++)
                    if (myArray[i] > 0 && myArray[i + 1] < 0 || myArray[i] < 0 && myArray[i + 1] > 0)
                    {
                        AddArray(myArray, ref n, i+1);
                        i=i+2;
                    }
                Console.WriteLine("Измененный массив:");
                Print(myArray, n);
            }

            if (hnya(z5) == 'y')
            {
                for (int i = 0; i < n; i++)
                    if (myArray[i] == 0)
                        DeleteArray(myArray, ref n, i);
                Console.WriteLine("Измененный массив:");
                Print(myArray, n);
            }

            //Console.WriteLine("Измененный массив:");
            //Print(myArray, n);
        }
    }
}

/*
II. В двумерном массиве, элементы которого – целые числа, произвести следующие действия:
1.	Вставить новую строку после строки, в которой находится первый встреченный минимальный элемент.
2.	Вставить новый столбец перед всеми столбцами, в которых встречается заданное число.
3.	Удалить все строки, в которых нет ни одного четного элемента.
4.	Удалить все столбцы, в которых все элементы положительны.
5.	Уплотнить массив, удалив из него все нулевые строки и столбцы.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laby_2_Kurs
{
    class Program
    {
        static int [,] Input (out int n, out int m)
		{
			Console.WriteLine("введите размерность массива");
			Console.Write("n = ");
            int u = 1;
			n=int.Parse(Console.ReadLine());
			Console.Write("m = ");
			m=int.Parse(Console.ReadLine());
			int [,]a=new int[n*2, m*2];
			for (int i = 0; i < n; ++i)
				for (int j = 0; j < m; ++j)
				{
                    u *= -1;
					//Console.Write("a[{0},{1}]= ", i, j);
                    a[i, j] = (i + 3) * (j + 13)*u%17;  //int.Parse(Console.ReadLine());
				}
			return a;
		}

        static void Print(int[,] a, int n,int m)
        {
            for (int i = 0; i < n; ++i,Console.WriteLine())
                for (int j = 0; j < m;j++)
                    Console.Write("{0} ", a[i, j]);
            Console.WriteLine();
            Console.WriteLine();
        }

        static void DeleteArray(int[] a, ref int n, int m)
        {
            for (int i = m; i < n - 1; ++i)
                a[i] = a[i + 1];
            --n;
            a[n] = 0;
        }

        static char hnya(string f)
        {
            Console.WriteLine(f);
            char z = Char.Parse(Console.ReadLine());
            return z;
        }

        static void AddLine(int[,] a, ref int n, int m, int z)
        {
            for (int i = n; i >= z; i--)
                for (int j = 0; j < m; j++)
                    a[i, j] = a[i - 1, j];
            ++n;
            Console.WriteLine("Введите значения элементов для новой строки");
            for (int i = 0; i < m; i++)
            {

                Console.Write("a[{0},{1}]=", z, i);
                a[z, i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void AddColumn(int[,] a,int n, ref int m, int z)
        {
            for (int i = m; i >= z; i--)
                for (int j = 0; j < n; j++)
                    if(i!=0)
                        a[j,i] = a[j,i-1];
            ++m;
            Console.WriteLine("Введите значения элементов для нового столбца");
            for (int i = 0; i < n; i++)
            {
                Console.Write("a[{0},{1}]=",i,z);
                a[i,z] = Convert.ToInt32(Console.ReadLine());

               // Console.Write("a[{0},{1}]=", z, i);
               // a[z, i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void DeleteArray(int[,] a, ref int n, int m, int k)
        {
            for (int i = k; i < n - 1; ++i)
                for (int j = 0; j < m; ++j)
                    a[i, j] = a[i + 1, j];
            --n;
        }

        static void DeleteColumn(int[,] a, int n, ref int m, int k)
        {
            for (int i =k; i <m-1; i++)
                for (int j =0; j <n; j++)
                    a[j,i]=a[j,i+1];
            m--;
        }


        static void Main()
        {
            int n,m,min,i,j,minI=0;
            int[,] myArray = Input(out n,out m);
            min=myArray[0,0];
            Console.WriteLine("Исходный массив:");
            Print(myArray, n,m);
            Console.WriteLine("Надо ли выполнить следующие операции (если да, то ответтье \"y\"), если нет, то \"n\"");
            string z1 = "1.	Вставить новую строку после строки, в которой находится первый встреченный минимальный элемент?";
            string z2 = "2.	Вставить новый столбец перед всеми столбцами, в которых встречается заданное число?";
            string z3 = "3.	Удалить все строки, в которых нет ни одного четного элемента?";
            string z4 = "4.	Удалить все столбцы, в которых все элементы положительны.?";
            string z5 = "5.	Уплотнить массив, удалив из него все нулевые строки и столбцы?";
            if (hnya(z1) == 'y')
            {
                for (i = 0; i < n; i++)
                    for (j = 0; j < m;j++)
                        if (min > myArray[i, j])
                        {
                            min = myArray[i, j];
                            minI = i;
                        }
                AddLine(myArray, ref n, m,minI+1);
                Console.WriteLine("Исходный массив: ");
                Print(myArray, n, m);
            }

            if (hnya(z2) == 'y')
            {
                Console.WriteLine("Введите число, до которого необходимо вставить столбец");
                int w = Convert.ToInt32(Console.ReadLine());
                for(i=0;i<m;i++)
                    for (j = 0; j < n; j++)
                        if (myArray[j, i] == w)
                        {
                            AddColumn(myArray, n, ref m, i);
                            i++;
                            j = n;
                        }
                Console.WriteLine("Исходный массив: ");
                Print(myArray, n, m);
            }

            if (hnya(z3) == 'y')
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m&&i<n; j++)
                        if (myArray[i, j] % 2 == 0)
                        {
                            j = -1;
                            i++;
                        }
                    if (j == m)
                    {
                        DeleteArray(myArray, ref n, m, i);
                        i--;
                    }
                }
                Console.WriteLine("Исходный массив: ");
                Print(myArray, n, m);
            }

            if (hnya(z4) == 'y')
            {
                for (i = 0; i < m; i++)
                {
                    for (j = 0; j < n && i < m; j++)
                        if (myArray[i, j] <= 0 )
                        {
                            i++;
                            j = -1;
                        }
                    if (j == n)
                    {
                        DeleteColumn(myArray, n, ref m, i);
                        i--;
                    }
                }
                Console.WriteLine("Исходный массив: ");
                Print(myArray, n, m);
            }

            if (hnya(z5) == 'y')
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m && i < n; j++)
                        if (myArray[i, j] != 0)
                        {
                            i++;
                            j = -1;
                        }
                    if (j == m)
                    {
                        DeleteArray(myArray, ref n, m, i);
                        i--;
                    }
                }

                for (i = 0; i <m; i++)
                {
                    for (j = 0; j < n && i < m; j++)
                        if (myArray[j,i] != 0 )
                        {
                            i++;
                            j = -1;
                        }
                    if (j == n)
                    {
                        DeleteColumn(myArray, n,ref m, i);
                        i--;
                    }
                }
                Console.WriteLine("Исходный массив: ");
                Print(myArray, n, m);


            }


        }
    }
}
