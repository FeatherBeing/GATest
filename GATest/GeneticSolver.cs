using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class GeneticSolver
    {
        private Stack<Chromosome> currentGen;
        private readonly Breeder breeder;

        public GeneticSolver()
        {
            breeder = new Breeder();
            currentGen = new Stack<Chromosome>(breeder.GenerateInitialChromosomes());
        }

        public void GenerateSolution(double targetNumber) 
        {
            while (!currentGen.Any(chromosome => chromosome.Fitness == 100))
            {
                currentGen = new Stack<Chromosome>(breeder.CreateGenerationFrom(currentGen));
            }

            var solution = currentGen.First(c => c.Fitness == 100);

            Console.WriteLine("Solution found!\nGeneration: {0}\nExpression: {1}", solution.Generation, solution.Sequence);
        }
    }
}
