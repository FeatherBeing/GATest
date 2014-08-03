using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class RouletteWheel
    {
        private int size;
        private RouletteNumber[] numbers;
        private Random rng;

        public RouletteWheel(params RouletteNumber[] rouletteNumbers)
        {
            size = rouletteNumbers.Length;
            numbers = rouletteNumbers;
            rng = new Random();

            //Check if the roulette number sizes match the size of the wheel
            //if (numbers.Sum(n => n.Size) != size)
            //{
            //    throw new Exception("The roulette number sections are larger or smaller than the size of the wheel!");
            //}
        }

        public Chromosome Spin()
        {
            // Keep spinning until we've returned a number
            while (true)
            {
                foreach (var entry in numbers)
                {
                    if (Math.Min(entry.Slice, size * 0.9f) > rng.Next(size + 1))
                    {
                        return entry.Number;
                    }
                }
            }
        }

        public class RouletteNumber
        {
            public readonly Chromosome Number;
            public readonly double Slice; // Determines how much "space" this number will occupy relative to the size of the wheel

            public RouletteNumber(Chromosome number, double slice)
            {
                this.Number = number;
                this.Slice = slice;
            }

            public static RouletteNumber[] CreateRange(Tuple<Chromosome, double>[] entries)
            {
                var rouletteNumbers = new RouletteNumber[entries.Length];

                for (int i = 0; i < entries.Length; i++)
                {
                    rouletteNumbers[i] = new RouletteNumber(entries[i].Item1, entries[i].Item2);
                }

                return rouletteNumbers;
            }

            public override string ToString()
            {
                return string.Format("SIZE: {0}, EXPRESSION: {1}", this.Slice, this.Number.ToString());
            }
        }
    }
}
