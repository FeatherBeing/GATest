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
        public readonly StringExpression Sequence;
        public readonly int Generation;
        public readonly double Fitness;
        public bool DoCross { get; set; }
        public static Func<Chromosome, double> CalculateFitness;

        static Chromosome()
        {
            CalculateFitness = new Func<Chromosome,double>(a => 
            {
                try
                {
                    return Math.Round(1/(Program.TARGET_NUMBER - a.Sequence.Evaluate()), 2);
                }
                catch (DivideByZeroException)
                {
                    return 100;
                }
            });
        }

        public Chromosome(int generation, string expression)
        {
            Generation = generation;
            Sequence = new StringExpression(expression);
            Fitness = CalculateFitness(this);
        }

        public Chromosome(int generation, StringExpression expression)
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

            return compareGen && compareSeq;
        }
    }
}
