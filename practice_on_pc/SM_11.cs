using System;
using System.IO;

namespace Sm11
{
    internal class Program
    {
        private static void Main()
        {
            var fileIn = new StreamReader(@"C:\Users\Recovery.txt");
            var text = fileIn.ReadToEnd();
            fileIn.Close();
            text = text.Replace(" ", "");
            var strings = text.Split(new[] { "\r\n" }, StringSplitOptions.None);
            var min = strings[1].Length;
            var num = 0;
            for (var i = 0; i < strings.Length; i++)
            {
                if (strings[i].Length >= min) continue;
                min = strings[i].Length;
                num = i + 1;
            }
            Console.WriteLine("Номер самой короткой строки: {0}", num);
        }
    }
}
