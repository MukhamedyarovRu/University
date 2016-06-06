/*

I. Разработать программу, которая для заданной строки s:

*/
//определяет, какой из двух заданных символов встречается чаще в строке;


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
         {
                Console.Write("Введите строку: ");
                string line = Console.ReadLine();
                Console.WriteLine("Исходная строка: " + line);
                Console.WriteLine("Введите символ x: ");
                char x = char.Parse(Console.ReadLine());
                Console.WriteLine("Введите символ y: ");
                char y = char.Parse(Console.ReadLine());

                int countX = line.Where(a => a == x).Count();
                int countY = line.Where(a => a == y).Count();
                string result = "Символ '{0}' встречается чаще в строке.";

                if (countX > countY)
                    Console.WriteLine(result, x);
                else if (countY > countX)
                    Console.WriteLine(result, y);
                else
                    Console.WriteLine("Символы '{0}' и '{1}' встречаются одинаковое количество раз в строке.", x, y);

                Console.ReadKey();
            }
        }
    }
}

/*
II. Дана строка, в которой содержится осмысленное текстовое сообщение. Слова сообщения разделяются пробелами и знаками препинания.
*/
// Вывести только те слова сообщения,  которые начинаются с прописной буквы.

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
         {
                string s = Console.ReadLine();
                string[] words = s.Split(' ');
                foreach (string word in words)
                    if (word[0] == word.ToLower()[0])
                        Console.WriteLine(word);
                Console.ReadLine();
            }
        }
    }
}
