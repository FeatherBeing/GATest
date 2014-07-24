using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class Breeder
    {
        const int POPULATION_SIZE = 100; // Defines how many chrosomes to breed per generation
        const int SEQUENCE_LENGTH = 9; // Defines maximum amount of terms in a supplied expression
        const float MUTATION_RATE = 0.07f;
        const float CROSSOVER_RATE = 10;
        private static Random rng = new Random();
        private int generationCtr = 1;

        public Chromosome[] GenerateInitialChromosomes()
        {
            var chromosomes = new Chromosome[POPULATION_SIZE];
            var rng = new Random();

            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                chromosomes[i] = new Chromosome(generationCtr, SimpleExpression.Random(SEQUENCE_LENGTH, rng));
            }

            return chromosomes;
        }

        public Chromosome[] CreateGenerationFrom(Stack<Chromosome> inGen)
        {
            var outGen = new HashSet<Chromosome>();

            // Select two chromosomes to cross using roulette wheel selection
            var rouletteNums = Enumerable.Range(0, inGen.Count)
                .Select(n => Tuple.Create(inGen.ElementAt(n), inGen.ElementAt(n).Fitness))
                .ToArray();            
            var rouletteWheel = new RouletteWheel(RouletteWheel.RouletteNumber.CreateRange(rouletteNums));

            while (outGen.Count < POPULATION_SIZE)
            {
                Chromosome a = rouletteWheel.Spin();
                Chromosome b = rouletteWheel.Spin();

                if (rng.Next(100) < CROSSOVER_RATE)
                {
                    var crossedPair = CrossOver(a, b);
                    crossedPair[0] = Mutate(crossedPair[0]);
                    crossedPair[1] = Mutate(crossedPair[1]);
                    outGen.Add(crossedPair[0]);
                    outGen.Add(crossedPair[1]);
                }
                else // If we're not going to cross anything then we can just set it to the same reference
                {
                    outGen.Add(inGen.Pop());
                }
            }

            return outGen.ToArray();
        }

        private Chromosome[] CrossOver(Chromosome a, Chromosome b)
        {
            var crossed = new Chromosome[2];
            string binaryStr = BinaryTranslator.ToBinaryString(a);
            string binaryStr2 = BinaryTranslator.ToBinaryString(b);

            int cutOffAt = rng.Next(1, binaryStr.Length);
            //int cutOffAt = 8; THIS IS FOR UNIT TESTING ONLY
            string crossedBinaryStr = binaryStr.Substring(0, cutOffAt) + binaryStr2.Substring(cutOffAt);
            string crossedBinaryStr2 = binaryStr2.Substring(0, cutOffAt) + binaryStr.Substring(cutOffAt);

            crossed[0] = BinaryTranslator.ToChrosomosome(crossedBinaryStr);
            crossed[1] = BinaryTranslator.ToChrosomosome(crossedBinaryStr2);
            
            return crossed;
        }

        private Chromosome Mutate(Chromosome a)
        {
            var mutatedExpr = BinaryTranslator.ToBinaryString(a).ToCharArray();
            var flipBits = new Func<char, char>(bit => char.GetNumericValue(bit) != 0 ? '0' : '1'); 

            for (int i = 0; i < mutatedExpr.Length; i++)
            {
                if (rng.NextDouble() < MUTATION_RATE)
                {
                    mutatedExpr[i] = flipBits(mutatedExpr[i]);
                }
            }

            return BinaryTranslator.ToChrosomosome(new string(mutatedExpr));
        }
    }
}
