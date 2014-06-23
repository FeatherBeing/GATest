using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GATest;
using System.Linq;
using System.Collections.Generic;

namespace GA_UnitTests
{
    [TestClass]
    public class RouletteWheelTests
    {
        [TestMethod]
        public void IntRouletteWheelTest()
        {
            var entries = new Tuple<string, int>[] 
            {
                Tuple.Create("Cat", 0),
                Tuple.Create("Dog", 0),
                Tuple.Create("Bird", 0),
                Tuple.Create("Fish", 0),
                Tuple.Create("Raptor", 0),
                Tuple.Create("Robot", 6)
            };
            var rouletteWheel = new RouletteWheel<string>(RouletteNumber<string>.CreateRange(entries));
            var expected = "Robot";

            var actual = rouletteWheel.Spin();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CoinTossRouletteWheelTest()
        {
            double expected = 0.5;
            var entries = new Tuple<string, int>[] 
            {
                Tuple.Create("Heads", 1),
                Tuple.Create("Tails", 1),
            };
            var rouletteWheel = new RouletteWheel<string>(RouletteNumber<string>.CreateRange(entries));
            var results = new List<int>();

            for (int i = 0; i < 10000000; i++)
            {
                var spinResults = (rouletteWheel.Spin().Equals("Heads")) ? 0 : 1;
                results.Add(spinResults);
            }

            double actual = results.Average();

            Assert.AreEqual(expected, actual);
        }
    }
}
