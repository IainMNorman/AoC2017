using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetScore(@"<random characters>"));
            //Console.WriteLine(GetScore("<{o\"i!a,<{i<a>"));
            Console.WriteLine(GetScore(File.ReadAllText("input.txt")));
        }

        static int GetScore(string stream)
        {
            var score = 0;
            var level = 0;

            var clean = Regex.Replace(stream, @"!.", "");

            Console.WriteLine($"Garbage count: {Regex.Matches(clean, @"\<.*?\>").ToList().Sum(x => x.Length - 2)}");

            clean = Regex.Replace(clean, @"\<.*?\>", "");
            clean = Regex.Replace(clean, ",", "");



            Console.WriteLine(clean);

            // calculate score
            foreach (var character in clean.ToCharArray())
            {
                if (character == '{')
                {
                    level++;
                    score += level;
                }
                if (character == '}')
                {
                    level--;
                }
            }

            return score;
        }
    }
}
