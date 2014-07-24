using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GATest
{       
    public class Chromosome
    {
        public readonly SimpleExpression Sequence;
        public readonly int Generation;
        public readonly int Fitness;
        public bool DoCross { get; set; }
        public static Func<Chromosome, int> CalculateFitness;

        static Chromosome()
        {
            // TODO: Implement this
            CalculateFitness = new Func<Chromosome,int>(a => 1);
        }

        public Chromosome(int generation, string expression)
        {
            Generation = generation;
            Sequence = new SimpleExpression(expression);
            Fitness = CalculateFitness(this);
        }

        public Chromosome(int generation, SimpleExpression expression)
        {
            Generation = generation;
            Sequence = expression;
            Fitness = CalculateFitness(this);
        }

        public override string ToString()
        {
            return string.Format("Generation: {0}, Expression: {1}", Generation, Sequence.ToString());
        }

        public override bool Equals(object obj)
        {
            var compareObj = (Chromosome)obj;

            bool compareGen = this.Generation == compareObj.Generation;
            bool compareSeq = this.Sequence.Equals(compareObj.Sequence);

            return (compareGen && compareSeq) ? true : false;
        }
    }
}
