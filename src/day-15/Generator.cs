using System;
using System.Collections.Generic;
using System.Text;

namespace day15
{
    class Generator
    {
        public UInt64 Value { get; set; }
        public UInt64 Factor { get; set; }
        public UInt64 Divisor { get; set; }

        public Generator(UInt64 factor, UInt64 value, UInt64 divisor)
        {
            this.Value = value;
            this.Factor = factor;
            this.Divisor = divisor;
        }

        public int Generate()
        {
            this.Value = (this.Factor * this.Value) % 2147483647;

            if (this.Value % this.Divisor == 0)
            {
                return (int)this.Value;
            }
            else
            {
                return Generate();
            }
        }
    }
}
