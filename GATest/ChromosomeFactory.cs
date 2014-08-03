using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    static class ChromosomeFactory
    {
        private static short genCtr = 0;

        public static Chromosome CreateChromosome(StringExpression expression)
        {
            return new Chromosome(genCtr, expression);
        }

        public static Chromosome CreateChromosome(string expression)
        {
            return new Chromosome(genCtr, expression);
        }

        public static void SetNewGeneration()
        {
            genCtr++;
        }
    }
}
