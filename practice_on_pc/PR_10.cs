//Выведите на экран все слова сообщения, записанные с заглавной буквы.
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
            string s = Console.ReadLine();
            string[] words = s.Split(' ');
            foreach (string word in words)
                if (word[0] == word.ToUpper()[0])
                    Console.WriteLine(word);
            Console.ReadLine();


        }

    }
}
