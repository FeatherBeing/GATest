using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class Breeder
    {
        const int POPULATION_SIZE = 100; // Defines how many chrosomes to breed initially
        const int MAX_TERMS = 8; // Defines maximum amount of terms in a supplied expression
        const int MUTATION_RATE = 1;
        const int CROSSOVER_RATE = 1;
        private static Random rng = new Random();
        private int generationCtr = 1;

        public Chromosome[] GenerateInitialChromosomes()
        {
            var chromosomes = new Chromosome[POPULATION_SIZE];

            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                chromosomes[i] = new Chromosome(generationCtr, GetRandomExpression());
            }

            return chromosomes;
        }

        public Chromosome[] CreateGenerationFrom(Chromosome[] inGen, Func<SimpleExpression, int> fitnessFunc)
        {
            int popCount = inGen.Length;
            inGen.Select(c => c.Fitness = fitnessFunc(c.Sequence));

            // Select two chromosomes to cross using roulette wheel selection
            var rouletteNums = new Tuple<Chromosome, int>[inGen.Length];

            for (int i = 0; i < inGen.Length; i++)
            {
                rouletteNums[i] = Tuple.Create(inGen[i], inGen[i].Fitness);
            }

            var rouletteWheel = new RouletteWheel<Chromosome>(RouletteNumber<Chromosome>.CreateRange(rouletteNums));
            Chromosome a = rouletteWheel.Spin();
            Chromosome b = rouletteWheel.Spin();



            return null;
        }

        private Chromosome[] CrossOver(Chromosome a, Chromosome b)
        {
            var crossed = new Chromosome[2];
            string binaryStr1 = BinaryTranslator.ToBinaryString(a);
            string binaryStr2 = BinaryTranslator.ToBinaryString(b);

            int cutOffAt = rng.Next(binaryStr1.Length);
            string crossedBinaryStr = binaryStr1.Substring(0, cutOffAt) + binaryStr2.Substring(cutOffAt);
            string crossedBinaryStr2 = binaryStr2.Substring(0, cutOffAt) + binaryStr1.Substring(cutOffAt);
            //TODO: finish this
            return null;
        }

        private Chromosome Mutate(Chromosome a)
        {
            //TODO: finish this 
            return null;
        }

        private string GetRandomExpression()
        {
            var sb = new StringBuilder();
            char[] allowedNumbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] allowedOperators = new char[] { '+', '-', '*', '/' };
            int terms = rng.Next(2, MAX_TERMS);

            if (terms % 2 == 0)
            {
                terms++;
            }

            for (int i = 0; i < terms; i++)
            {
                if (i % 2 == 0)
                {
                    // Append Number
                    sb.Append(allowedNumbers[rng.Next(allowedNumbers.Length)]);
                }
                else
                {
                    // Append operator
                    sb.Append(allowedOperators[rng.Next(allowedOperators.Length)]);
                }
            }

            return sb.ToString();
        }
    }
}
