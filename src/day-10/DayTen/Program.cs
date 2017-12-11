using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }

        static void Part2()
        {
            var currentIndex = 0;
            var skip = 0;
            var arrayLength = 256;

            byte[] array = Enumerable.Range(0, arrayLength).Select(x => (byte)x).ToArray();

            List<byte> pre = Encoding.ASCII.GetBytes("230,1,2,221,97,252,168,169,57,99,0,254,181,255,235,167").ToList();
            //List<byte> pre = Encoding.ASCII.GetBytes("1,2,4").ToList();

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
            StringBuilder sb = new StringBuilder();
            foreach (byte b in dense)
                sb.Append(b.ToString("X2"));

            string hexString = sb.ToString();
            Console.WriteLine(hexString.ToLower());
            Console.ReadLine();
        }

        static void Part1()
        {
            var currentIndex = 0;
            var skip = 0;
            var arrayLength = 256;

            int[] array = Enumerable.Range(0, arrayLength).ToArray();

            int[] input = { 230, 1, 2, 221, 97, 252, 168, 169, 57, 99, 0, 254, 181, 255, 235, 167 };
            int[] testInput = { 3, 4, 1, 5 };

            foreach (var step in input)
            {
                if (step != 1)
                {
                    if (currentIndex + step < (arrayLength - 1))
                    {
                        Array.Reverse(array, currentIndex, step);
                    }
                    else
                    {
                        var lengthToEnd = arrayLength - currentIndex;
                        var lengthFromBeginning = step - lengthToEnd;

                        var copy = new int[step];


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

            Console.WriteLine(array[0] * array[1]);
            Console.ReadLine();
        }
    }
}
