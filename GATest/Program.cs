﻿using System;
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
        static Random RNG = new Random();

        static void Main(string[] args)
        {
            var binaryStr = BinaryTranslator.ToBinaryString(new Chromosome(0, "1 + 1"));
            var binaryStr2 = BinaryTranslator.ToBinaryString(new Chromosome(0, "2 + 2"));
            Console.WriteLine("Binary Sequence: {0}", binaryStr);
            Console.WriteLine("Binary Sequence: {0}", binaryStr2);
            //Console.WriteLine("Translated Sequence: {0}", BinaryTranslator.ToChrosomosome(binaryStr).Sequence.Text);
            Console.ReadKey();

            //var breeder = new Breeder();
            //var somes = breeder.GenerateInitialChromosomes();
        }
    }
}
