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
        public int Fitness { get; set; }
        public bool DoCross { get; set; }

        public Chromosome(int generation, string expression)
        {
            Generation = generation;
            Sequence = new SimpleExpression(expression);
        }

        public override string ToString()
        {
            return string.Format("Generation: {0}, Expression: {1}", Generation, Sequence.Text);
        }

        public override bool Equals(object obj)
        {
            var compareObj = (Chromosome)obj;

            bool compareGen = this.Generation == compareObj.Generation;
            bool compareSeq = this.Sequence.Equals(compareObj.Sequence);

            return (compareGen && compareSeq) ? true : false;
        }

        public string ToBinaryString()
        {
            StringBuilder sb = new StringBuilder();

            return "TO BE IMPLEMENTED";
        }

        public static Chromosome ConvertFromBinaryString(string binaryString)
        {       
            return new Chromosome(0, null);
        }
    }
}
