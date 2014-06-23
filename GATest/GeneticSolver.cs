using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class GeneticSolver
    {
        private Func<SimpleExpression, int> fitnessFunc;

        public GeneticSolver(Func<SimpleExpression, int> fitnessCalc)
        {
            fitnessFunc = fitnessCalc;
        }

        public void GenerateSolution(int targetNumber) 
        {
            var bank = new ChromosomeBank();
            Chromosome[] currentGen;

            do
            {
                currentGen = bank.GetLatestGeneration();
                bank.AddGeneration(bank.Breeder.CreateGenerationFrom(currentGen, fitnessFunc));
                
            } while (!currentGen.Any(chromosome => chromosome.Fitness == 100));
        }
    }
}
