namespace AoCDay7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class AoCProgram
    {
        public AoCProgram()
        {
            this.Children = new List<AoCProgram>();
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int TotalWeight { get; set; }

        public string[] ChildrenNames { get; set; }

        public List<AoCProgram> Children { get; set; }
    }
}
