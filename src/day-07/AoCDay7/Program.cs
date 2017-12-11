namespace AoCDay7
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    internal class Program
    {
        private static List<AoCProgram> programs;

        private static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\git\AoC2017\src\day-07\input.txt");
            programs = new List<AoCProgram>();
            AoCProgram bottomProg = null;

            // parse all program names and weight
            foreach (var prog in lines)
            {
                programs.Add(DeserialiseProgram(prog));
            }

            // parse children
            foreach (var prog in programs)
            {
                foreach (var name in prog.ChildrenNames)
                {
                    prog.Children.Add(programs.Single(x => x.Name == name));
                }
            }

            // parse total weights
            foreach (var prog in programs)
            {
                prog.TotalWeight = GetTotalWeight(prog);
            }

            // find program with no parent
            foreach (var prog in programs)
            {
                var hasParent = false;

                foreach (var progj in programs)
                {
                    if (progj.ChildrenNames.Contains(prog.Name))
                    {
                        hasParent = true;
                        break;
                    }
                }

                if (!hasParent)
                {
                    bottomProg = prog;
                    Console.WriteLine(prog.Name);
                }
            }

            // find all unbalanced progs
            var unbalanced = new List<AoCProgram>();
            foreach (var prog in programs)
            {
                if (!IsBalanced(prog))
                {
                    unbalanced.Add(prog);
                }
            }

            var lightestUnbalanced = unbalanced.OrderBy(x => x.TotalWeight).First();

            foreach (var child in lightestUnbalanced.Children)
            {
                Console.WriteLine($"{child.Name} - {IsBalanced(child)} - {child.Weight} - {child.TotalWeight}");
                Console.WriteLine(string.Join(",", child.Children.Select(x => x.TotalWeight)));
            }

            Console.WriteLine("\n\nPress any Key...");
            Console.ReadLine();
        }

        private static AoCProgram DeserialiseProgram(string line)
        {
            var prog = new AoCProgram
            {
                Name = Regex.Match(line, @"(^.*?)\s").Groups[1].Value,
                Weight = int.Parse(Regex.Match(line, @"\d+").Value),
                ChildrenNames = Regex.Replace(
                    Regex.Match(line, @"-\>\s(.*?)$").Groups[1].Value,
                    @"\s+",
                    string.Empty)
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            };
            return prog;
        }

        private static int GetTotalWeight(AoCProgram prog)
        {
            if (prog.Children.Count == 0)
            {
                return prog.Weight;
            }
            else
            {
                return prog.Weight + prog.Children.Sum(x => GetTotalWeight(x));
            }
        }

        private static bool IsBalanced(AoCProgram prog)
        {
            if (prog.Children.Count == 0)
            {
                return true;
            }

            return prog.Children.Max(x => x.TotalWeight) == prog.Children.Min(x => x.TotalWeight);
        }
    }
}
