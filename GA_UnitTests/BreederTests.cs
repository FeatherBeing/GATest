using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GATest;
using System.Linq;

namespace GA_UnitTests
{
    [TestClass]
    public class BreederTests
    {
        [TestMethod]
        public void CrossoverTest()
        {
            var a = new Chromosome(0, "1+1");
            var b = new Chromosome(0, "2+2");
            var expected = new Chromosome[] 
            { 
                new Chromosome(0, "1+2"), 
                new Chromosome(0, "2+1") 
            };
            // Have to use the PrivateObject class here because the CrossOver() method is private
            var pBreeder = new PrivateObject(new Breeder());

            var actual = (Chromosome[])pBreeder.Invoke("CrossOver", a, b);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MutationTest()
        {
            var notExpected = new Chromosome(0, "1+1");
            var pBreeder = new PrivateObject(new Breeder());

            var actual = (Chromosome)pBreeder.Invoke("Mutate", notExpected);

            //Check if generated expression is a valid mathematical expression
            var validateExpr = new Func<Chromosome, bool>(
                x => 
                {
                    char[] operators = new char[] { '+', '-', '*', '/' };
                    char prev = '\0';
                    int ctr = 0;

                    foreach (char chr in x.Sequence.Text)
                    {
                        if (!char.IsDigit(prev) && char.IsDigit(chr))
                        {
                            ctr++;
                        }
                        else if(operators.Any(op => op == chr))
                        {
                            ctr++;
                        }
                        else if (chr == ' ')
                        {
                            ctr++;
                        }
                    }

                    return ctr == x.Sequence.Text.Length
                        ? true : false;
                }); 

            Assert.IsTrue(validateExpr(actual));
        }
    }
}
