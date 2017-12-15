using System;
using System.Collections;
using System.Threading.Tasks;

namespace day15
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            var a = new Generator(16807, 703, 1);
            var b = new Generator(48271, 516, 1);
            var count = 0;
            for (int i = 0; i < 40000000; i++)
            {
                if ((a.Generate() & 0xffff) == (b.Generate() & 0xffff))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        static void Part2()
        {
            var a = new Generator(16807, 703, 4);
            var b = new Generator(48271, 516, 8);
            var count = 0;
            for (int i = 0; i < 5000000; i++)
            {
                if ((a.Generate() & 0xffff) == (b.Generate() & 0xffff))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
