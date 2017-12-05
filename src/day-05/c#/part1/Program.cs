using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            
            int[] ins = 
                File.ReadAllText(@"C:\git\AoC2017\src\day-05\input.txt").Split('\n').Select(Int32.Parse).ToArray();

            Console.WriteLine(sw.ElapsedMilliseconds);

            var curPos = 0;
            var count = 0;
            while (true)
            {
                if (curPos < 0 || curPos >= ins.Length)
                {
                    break;
                }
                var newPos = curPos + ins[curPos];
                if (ins[curPos] > 2)
                {
                    ins[curPos]--;
                }
                else
                {
                    ins[curPos]++;
                }
                count++;
                curPos = newPos;
            }
            Console.WriteLine(count);
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
