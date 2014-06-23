using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class ChromosomeBank
    {
        private List<Chromosome[]> _bank;
        public readonly Breeder Breeder;

        public ChromosomeBank()
        {
            // Initialize bank and generate the first generations of chromosomes
            _bank = new List<Chromosome[]>();
            Breeder = new Breeder();
            _bank.Add(Breeder.GenerateInitialChromosomes());
        }

        public Chromosome[] GetLatestGeneration()
        {
            return _bank.Last();
        }

        public void AddGeneration(Chromosome[] generation)
        {
            _bank.Add(generation);
        }
    }
}
