using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class RouletteWheel<T>
    {
        private int size;
        private RouletteNumber<T>[] numbers;
        private Random rng;

        public RouletteWheel(params RouletteNumber<T>[] rouletteNumbers)
        {
            size = rouletteNumbers.Length;
            numbers = rouletteNumbers;
            rng = new Random();

            //Check if the roulette number sizes match the size of the wheel
            if (numbers.Sum(n => n.Size) != size)
            {
                throw new Exception("The roulette number sections are larger or smaller than the size of the wheel!");
            }
        }

        public T Spin()
        {
            // Keep spinning until we've returned a number
            while (true)
            {
                foreach (var entry in numbers)
                {
                    if (Math.Min(entry.Size, size * 0.9f) > rng.Next(size + 1))
                    {
                        return entry.Number;
                    }
                }
            }
        }
    }
}
