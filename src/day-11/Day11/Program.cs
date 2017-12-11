using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        static void Part1()
        {
            var route = File.ReadAllText("input.txt");
            var instructions = route.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var x = 0;
            var y = 0;
            var z = 0;

            var maxD = 0;

            foreach (var step in instructions)
            {
                switch (step)
                {
                    case "n":
                        z--;
                        y++;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "s":
                        z++;
                        y--;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                    default:
                        break;
                }
                var d = Distance(0, 0, 0, x, y, z);
                if (d > maxD) maxD = d;
            }

            Console.WriteLine($"{x},{y},{z}");
            Console.WriteLine(Distance(0, 0, 0, x, y, z));
            Console.WriteLine(maxD);
        }

        static int Distance(int ax, int ay, int az, int bx, int by, int bz)
        {
            return (Math.Abs(ax - bx) + Math.Abs(ay - by) + Math.Abs(az - bz)) / 2;
        }

        static int DistanceFromZero(int x, int y, int z)
        {
            return (new int[] { Math.Abs(x), Math.Abs(y), Math.Abs(z) }).Max();
        }
    }
}
