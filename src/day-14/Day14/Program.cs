using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part1("flqrgnkx");
            //Part2("flqrgnkx");
            Part1("nbysizxe");            
            Part2("nbysizxe");
            //Console.ReadLine();
        }

        static void Part2(string input)
        {

            var rows = new List<bool[]>();

            for (int i = 0; i < 128; i++)
            {
                var bits = GetBoolArray(input + "-" + i);
                rows.Add(bits);
            }

            var bitmap = new bool[128, 128];

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    bitmap[i, j] = rows[j][i];
                }
            }

            var labels = new int[128, 128];

            var queue = new Queue<Coord>();

            var label = 0;

            for (int i = 0; i < 16384; i++)
            {                
                var x = i % 128;
                var y = i / 128;

                if (bitmap[x, y] && labels[x, y] == 0)
                {
                    label++;
                    labels[x, y] = label;
                    queue.Enqueue(new Coord(x, y));

                    while (queue.Count > 0)
                    {
                        var coord = queue.Dequeue();

                        //north
                        if (coord.Y > 0)
                        {
                            var n = new Coord(coord.X, coord.Y - 1);
                            if (bitmap[n.X, n.Y] && labels[n.X, n.Y] == 0)
                            {
                                labels[n.X, n.Y] = label;
                                queue.Enqueue(new Coord(n.X, n.Y));
                            }
                        }
                        //east
                        if (coord.X < 127)
                        {
                            var n = new Coord(coord.X + 1, coord.Y);
                            if (bitmap[n.X, n.Y] && labels[n.X, n.Y] == 0)
                            {
                                labels[n.X, n.Y] = label;
                                queue.Enqueue(new Coord(n.X, n.Y));
                            }
                        }
                        //south
                        if (coord.Y < 127)
                        {
                            var n = new Coord(coord.X, coord.Y + 1);
                            if (bitmap[n.X, n.Y] && labels[n.X, n.Y] == 0)
                            {
                                labels[n.X, n.Y] = label;
                                queue.Enqueue(new Coord(n.X, n.Y));
                            }
                        }
                        //west
                        if (coord.X > 0)
                        {
                            var n = new Coord(coord.X - 1, coord.Y);
                            if (bitmap[n.X, n.Y] && labels[n.X, n.Y] == 0)
                            {
                                labels[n.X, n.Y] = label;
                                queue.Enqueue(new Coord(n.X, n.Y));
                            }
                        }
                    }
                    
                }
            }
            
            Console.WriteLine(label);
        }


        static void Part1(string input)
        {

            var rows = new List<bool[]>();

            for (int i = 0; i < 128; i++)
            {
                var bits = GetBoolArray(input + "-" + i);
                rows.Add(bits);
            }

            var used = 0;
            foreach (var bitarray in rows)
            {
                foreach (bool bit in bitarray)
                {
                    if (bit)
                    {
                        used++;
                        //Console.Write("#");
                    }
                    else
                    {
                        //Console.Write(".");
                    }
                }
                //Console.Write(Environment.NewLine);
            }

            Console.WriteLine(used);
        }

        static bool[] GetBoolArray(string hashin)
        {
            var currentIndex = 0;
            var skip = 0;
            var arrayLength = 256;

            byte[] array = Enumerable.Range(0, arrayLength).Select(x => (byte)x).ToArray();

            List<byte> pre = Encoding.ASCII.GetBytes(hashin).ToList();

            pre.AddRange(new List<byte> { 17, 31, 73, 47, 23 });

            var input = pre.ToArray();

            for (int i = 0; i < 64; i++)
            {
                foreach (var step in input)
                {
                    if (step != 1)
                    {
                        if (currentIndex + step < (arrayLength))
                        {
                            Array.Reverse(array, currentIndex, step);
                        }
                        else
                        {
                            var lengthToEnd = arrayLength - currentIndex;
                            var lengthFromBeginning = step - lengthToEnd;

                            var copy = new byte[step];


                            Array.Copy(array, currentIndex, copy, 0, lengthToEnd);
                            Array.Copy(array, 0, copy, lengthToEnd, lengthFromBeginning);

                            Array.Reverse(copy);

                            Array.Copy(copy, 0, array, currentIndex, lengthToEnd);
                            Array.Copy(copy, lengthToEnd, array, 0, lengthFromBeginning);
                        }
                    }
                    currentIndex += step + skip;
                    currentIndex = currentIndex % arrayLength;
                    skip++;
                }
            }

            //array is now sparse hash

            //XOR 16 byte blocks.

            List<byte> dense = new List<byte>();

            for (int i = 0; i < array.Length; i += 16)
            {
                dense.Add(
                    (byte)(array[i + 0] ^
                    array[i + 1] ^
                    array[i + 2] ^
                    array[i + 3] ^
                    array[i + 4] ^
                    array[i + 5] ^
                    array[i + 6] ^
                    array[i + 7] ^
                    array[i + 8] ^
                    array[i + 9] ^
                    array[i + 10] ^
                    array[i + 11] ^
                    array[i + 12] ^
                    array[i + 13] ^
                    array[i + 14] ^
                    array[i + 15]));
            }
            var boolArray = new bool[128];
            for (int i = 0; i < dense.Count; i++)
            {
                BitArray b = new BitArray(new byte[] { dense[i] });
                bool[] bits = new bool[b.Count];
                b.CopyTo(bits, 0);
                bits.Reverse().ToArray().CopyTo(boolArray, i * 8);
            }

            return boolArray;
        }

    }
}
