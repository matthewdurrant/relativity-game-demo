using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelativityDemo.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oasis1.Tests
{
    [TestClass()]
    public class StarTests
    {
        [TestMethod()]
        public void TestDistances()
        {
            Star2D sol = Space2D.Sol;
            Star2D aCentaurai = Space2D.AlphaCentauri;
            Star2D wolf359 = Space2D.Wolf359;

            float solToAC = sol.DistanceTo(aCentaurai); //4.3441
            float solToWolf359 = sol.DistanceTo(wolf359); //5.555825
            float ACtoWolf359 = aCentaurai.DistanceTo(wolf359); //4.02969456

            Assert.AreEqual(4.3441, solToAC);
            Assert.AreEqual(5.555825, solToWolf359);
            Assert.AreEqual(4.02969456, ACtoWolf359);
        }


        private void AssertFloatsAreRoughlyEqual(double a, double b, int precision)
        {
            Assert.AreEqual(Math.Round(a, precision), Math.Round(b, precision));
        }
    }
}