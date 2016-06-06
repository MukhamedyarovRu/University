using System;
using System.IO;

namespace PR_11
{
    class Program
    {
        static void Main()
        {
            Console.Write("a= ");
            var a = double.Parse(Console.ReadLine());
            Console.Write("b= ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("h= ");
            var h = double.Parse(Console.ReadLine());
            var f = new FileStream("t.dat", FileMode.Open);
            var fOut = new BinaryWriter(f);
            for (double i = a; i <= b; i += h)
                fOut.Write(i);
            fOut.Close();
            f = new FileStream("t.dat", FileMode.Open);
            var fIn = new BinaryReader(f);
            var m = f.Length;
            for (long i = 0; i < m; i += 16)
            {
                f.Seek(i, SeekOrigin.Begin);
                a = fIn.ReadDouble();
                Console.Write("{0:f2} ", a);
            }
            fIn.Close();
            f.Close();
            Console.WriteLine();
        }
    }
