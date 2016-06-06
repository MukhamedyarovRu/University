/*
1) Разработать рекурсивный метод для вывода на экран всех возможных разложений
натурального числа n на множители (без повторений).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laby_Galiullin_pr5_Sh
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n=");
            int n = Convert.ToInt32(Console.ReadLine());
            var dividors = GetDividors(n);
		Console.WriteLine("1*n = n");
            foreach (var dividor in dividors)
            {
                Console.WriteLine("{0} = {1}", dividor, n);
            }
        }

        private static IEnumerable<string> GetDividors(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i != 0)
                    continue;
                yield return string.Format("{0}*{1}", i, n / i);
                var moreDivirors = GetDividors(n / i);
                foreach (string diviror in moreDivirors)
                {
                    yield return string.Format("{0}*{1}", i, diviror);
                }
            }
        }
    }
}

/*
2) Разработать рекурсивный метод для вывода на экран всех возможных
 разложений натурального числа n на слагаемые (без повторений).
*/

namespace NumberDecomposition
{
    using System;
    using System.Collections.Generic;


    class Programy
    {
        static void Main(string[] args)
        {
            DecompositeValue(Convert.ToInt32(Console.ReadLine()));
            Console.ReadLine();
        }
        private static List<int> list;
        // Храним информацию о том, отрицательное число или нет
        private static bool Znak;


        /*
            Метод, который разбивает число по слагаемым и выводит разбиение (без повторений)
            Можно также запустить и от отрицательного числа
        */
        public static void DecompositeValue(int RazbChislo)
        {
            // Создаем экземпляр листа с одним элементом, который равен нулю
            // Чтобы прога не вылетала при обращении к несуществующему индексу
            list = new List<int>(new int[] { 0 });

            if (RazbChislo < 0)
            {
                Znak = false;
                RazbChislo *= -1;
            }
            else
                Znak = true;
            rec(RazbChislo, RazbChislo, 0, RazbChislo);
        }
        private static string Show()
        {
            string result;
            if (Znak)
                result = String.Format(String.Join("+", list));
            else
                result = String.Format(String.Join("-", list));
            return result;
        }

        private static void rec(int ES, int BS, int i, int Vyvod)
        {
            if (ES >= 0)
            {
                if (ES == 0) // Просьба разложить 0 означает, что раскладывать уже нечего и
                {
                    if (Znak)
                        Console.WriteLine(Vyvod + " = " + Show());
                    else
                        Console.WriteLine("-" + Vyvod + " = -" + Show());
                    while(list.IndexOf(1)>0)
                        list.Remove(1);

                    //программа работает так, что -
                    //каждый ра зкол-во слагаемых лбо на 1 больше, либо также
                    //но не всегда правльно так выводить, он будет выводить все отличные от 0 эл-ты что есть в лист
                    //поэтому каждый раз последнюю единичку удаляем, ведь при необходимости он будет туда добавлять
                }
                else
                {
                    if (ES - BS >= 0)
                    {
                        // Фиксируем i-ое слагаемое,
                        // проверея, имеется ли уже индекс в листе или его нужно добавить
                        if (i + 1 > list.Count)
                            list.Add(BS);
                        else
                            list[i] = BS;

                        rec(ES - BS, BS, i + 1, Vyvod);
                    }

                    if (BS > 1)
                        rec(ES, BS - 1, i, Vyvod);
                }
            }
        }
    }
}
