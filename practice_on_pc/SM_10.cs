/*
Практическое задание
1. Шаблоны регулярных выражений для групп time, ip и site записаны в упрощенном виде. Преобразуйте их к такому виду, чтобы они соответствовали ограничениям, накладываемым на формат времени, ip-адреса и адреса web-сайта.
2. Используя дополнительную литературу и Интернет, более подробно изучите работу с классом Group и коллекцией Groups класса Match. 

*/


using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SM_10
{
    class Program
    {
        private static void Main(string[] args)
        {
            const string text = @"04:55:34 223.34.12.156 www.aaa.ru
                                     04:59:55 213.134.112.56 www.bbb.cc.com
                                     05:05:01 223.34.12.156 www.aaa.ru";
            var theReg = new Regex(@"(?<time>((0[0-9]|1[0-9]|2[0-3]):(?<min>[0-5][0-9]):(?<sec>[0-5][0-9]))+)\s" + @"(?<ip>(\d?\d?\d\.\d?\d?\d\.\d?\d?\d\.\d?\d?\d)+)\s" + @"(?<site>(([a-z1-9]+.)?[a-z1-9\-]+(\.[a-z]+){1,}/?)+)");
            var theMatches = theReg.Matches(text);
            foreach (var theMatch in theMatches.Cast<Match>().Where(theMatch => theMatch.Length != 0))
            {
                Console.WriteLine("\ntheMatch: {0}", theMatch);
                Console.WriteLine("time: {0}", theMatch.Groups["time"]);
                Console.WriteLine("ip: {0}", theMatch.Groups["ip"]);
                Console.WriteLine("site: {0}", theMatch.Groups["site"]);
            }
        }
    }
}
