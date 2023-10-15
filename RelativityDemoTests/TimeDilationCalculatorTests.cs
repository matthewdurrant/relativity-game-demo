using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oasis1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oasis1.Tests
{
    [TestClass()]
    public class TimeDilationCalculatorTests
    {
        private const long expectedCoordinateTime = 325702407482659;
        private const long expectedProperTime = 315360000000000;
        private const float velocity = 0.25f;
        private const float c = 1;
        private const float expectedFactor = 0.96824583655185426f;

        [TestMethod()]
        public void GetCoordinateTimeTest()
        {
            TimeSpan shipTime = TimeSpan.FromTicks(expectedProperTime);
            TimeSpan earthTime = TimeDilationCalculator.GetCoordinateTime(shipTime, velocity);

            Assert.IsTrue(earthTime > shipTime);
            Assert.AreEqual(expectedCoordinateTime, earthTime.Ticks);
        }

        [TestMethod()]
        public void GetProperTimeTest()
        {
            TimeSpan earthTime = TimeSpan.FromTicks(expectedCoordinateTime);
            TimeSpan shipTime = TimeDilationCalculator.GetProperTime(earthTime, velocity);

            Assert.IsTrue(earthTime > shipTime);

            Assert.AreEqual(expectedProperTime, shipTime.Ticks);
        }

        [TestMethod()]
        public void GetRelativeVelocityTest()
        {
            TimeSpan earthTime = TimeSpan.FromTicks(expectedCoordinateTime);
            TimeSpan shipTime = TimeSpan.FromTicks(expectedProperTime);

            double v = TimeDilationCalculator.GetRelativeVelocity(shipTime, earthTime);

            AssertFloatsAreRoughlyEqual(velocity, v, 5);
        }

        [TestMethod]
        public void CalculateFactorFromVelocityTest()
        {
            double result = TimeDilationCalculator.CalculateFactorFromVelocity(velocity, c);
            AssertFloatsAreRoughlyEqual(expectedFactor, result, 5);
        }

        [TestMethod]
        public void CalculateFactorFromFTLVelocityTest()
        {
            double ftlV = 1.0001;
            double result = TimeDilationCalculator.CalculateFactorFromVelocity(ftlV, c);
        }


        [TestMethod]
        public void CalculateFactorFromTimeTest()
        {
            TimeSpan earthTime = TimeSpan.FromTicks(expectedCoordinateTime);
            TimeSpan shipTime = TimeSpan.FromTicks(expectedProperTime);

            double result = TimeDilationCalculator.CalculateFactorFromTime(shipTime, earthTime);
            AssertFloatsAreRoughlyEqual(expectedFactor, result, 5);
        }

        [TestMethod]
        public void CalculateFactorsShouldMatchTest()
        {
            TimeSpan earthTime = TimeSpan.FromTicks(expectedCoordinateTime);
            TimeSpan shipTime = TimeSpan.FromTicks(expectedProperTime);

            double fromTime = TimeDilationCalculator.CalculateFactorFromTime(shipTime, earthTime);
            double fromVelocity = TimeDilationCalculator.CalculateFactorFromVelocity(velocity, c);
            AssertFloatsAreRoughlyEqual(fromTime, fromVelocity, 5);
        }

        private void AssertFloatsAreRoughlyEqual(double a, double b, int precision)
        {
            Assert.AreEqual(Math.Round(a, precision), Math.Round(b, precision));
        }
    }
}