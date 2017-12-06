namespace AoCDay6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MoreLinq;

    public class MemoryBank
    {
        public int Index { get; set; }

        public int Blocks { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
