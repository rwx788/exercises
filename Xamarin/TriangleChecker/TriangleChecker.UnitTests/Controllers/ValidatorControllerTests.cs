using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TriangleChecker.Controllers.Tests
{
    [TestClass()]
    public class ValidatorControllerTests
    {
        [TestMethod()]
        public void GetTriangleTypeTestNone()
        {
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(0, 0, 0));
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(1, 5, 3));
        }

        [TestMethod]
        public void GetTriangleTypeTestEquilateral()
        {
            Assert.AreEqual(TriangleTypes.Equilateral, ValidatorController.GetTriangleType(1, 1, 1));
        }

        [TestMethod]
        public void GetTriangleTypeTestIsosceles()
        {
            Assert.AreEqual(TriangleTypes.Isosceles, ValidatorController.GetTriangleType(4, 3, 3));
        }

        [TestMethod]
        public void GetTriangleTypeTestScalene()
        {
            Assert.AreEqual(TriangleTypes.Scalene, ValidatorController.GetTriangleType(3, 4, 5));
        }

        [TestMethod]
        public void GetTriangleTypeTestMaxValue()
        {
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(UInt32.MaxValue, 1000000000, 1000000000));
            Assert.AreEqual(TriangleTypes.Equilateral, ValidatorController.GetTriangleType(UInt32.MaxValue, UInt32.MaxValue, UInt32.MaxValue));
            Assert.AreEqual(TriangleTypes.Isosceles, ValidatorController.GetTriangleType(UInt32.MaxValue, 13, UInt32.MaxValue));
            Assert.AreEqual(TriangleTypes.Isosceles, ValidatorController.GetTriangleType(UInt32.MaxValue, UInt32.MaxValue - 5, UInt32.MaxValue));
            Assert.AreEqual(TriangleTypes.Scalene, ValidatorController.GetTriangleType(UInt32.MaxValue, UInt32.MaxValue - 10000, UInt32.MaxValue - 5000));
        }

    }
}