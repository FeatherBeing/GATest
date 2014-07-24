using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    // Given the digits 0 through 9 and the operators +, -, * and /,  find a Sequence that will represent a given target Number. 
    // The operators will be applied sequentially from left to right as you read.
    class Program
    {
        // Number to generate sequence for
        private const int TARGET_NUMBER = 24;

     
        static void Main(string[] args)
        {
            var genSolver = new GeneticSolver();
            genSolver.GenerateSolution(TARGET_NUMBER);
        }
    }
}
