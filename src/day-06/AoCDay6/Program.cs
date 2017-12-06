namespace AoCDay6
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using MoreLinq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var currentBankState = new List<MemoryBank>
             {
                new MemoryBank { Index = 0, Blocks = 0 },
                new MemoryBank { Index = 1, Blocks = 5 },
                new MemoryBank { Index = 2, Blocks = 10 },
                new MemoryBank { Index = 3, Blocks = 0 },
                new MemoryBank { Index = 4, Blocks = 11 },
                new MemoryBank { Index = 5, Blocks = 14 },
                new MemoryBank { Index = 6, Blocks = 13 },
                new MemoryBank { Index = 7, Blocks = 4 },
                new MemoryBank { Index = 8, Blocks = 11 },
                new MemoryBank { Index = 9, Blocks = 8 },
                new MemoryBank { Index = 10, Blocks = 8 },
                new MemoryBank { Index = 11, Blocks = 7 },
                new MemoryBank { Index = 12, Blocks = 1 },
                new MemoryBank { Index = 13, Blocks = 4 },
                new MemoryBank { Index = 14, Blocks = 12 },
                new MemoryBank { Index = 15, Blocks = 11 }
             };

            var bankCount = currentBankState.Count();

            var pastStates = new List<string>
            {
                GetStateString(currentBankState)
            };

            var run = true;

            while (run)
            {
                // find first max
                var maxBlock = currentBankState.MaxBy(x => x.Blocks);
                var blocksToRedist = maxBlock.Blocks;
                maxBlock.Blocks = 0;

                // redistribute evenly starting with next block
                var startIndex = maxBlock.Index + 1;
                for (int i = startIndex; i < startIndex + blocksToRedist; i++)
                {
                    currentBankState[i % bankCount].Blocks++;
                }

                // break if state has been seen before
                var stateString = GetStateString(currentBankState);
                if (pastStates.Contains(stateString))
                {
                    run = false;
                }

                // store new state
                pastStates.Add(stateString);

                // Console.WriteLine(stateString);
            }

            Console.WriteLine(pastStates.Count() - 1);
            Console.WriteLine(pastStates.Count() - pastStates.IndexOf(pastStates.Last()) - 1);
            Console.ReadLine();
        }

        private static string GetStateString(List<MemoryBank> banks)
        {
            return string.Join(",", banks.Select(x => x.Blocks).ToArray());
        }
    }
}