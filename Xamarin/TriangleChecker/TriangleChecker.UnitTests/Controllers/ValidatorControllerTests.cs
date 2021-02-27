using NUnit.Framework;
using System;

namespace TriangleChecker.Controllers.Tests
{
    [TestClass()]
    public class ValidatorControllerTests
    {
        private static Random rand = new Random();
        // Storing UInt32 zero as a constant, as return type is UInt32
        private const UInt32 ZERO = 0;

        [TestMethod]
        [Description("Test cases when triangle cannot be built")]
        public void GetTriangleTypeTestNone()
        {
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(1, 5, 3));
        }

        [TestMethod]
        [Description("Test cases when triangle is Equilateral")]
        public void GetTriangleTypeTestEquilateral()
        {
            Assert.AreEqual(TriangleTypes.Equilateral, ValidatorController.GetTriangleType(1, 1, 1));
        }

        [TestMethod]
        [Description("Test cases when triangle is Isosceles")]
        public void GetTriangleTypeTestIsosceles()
        {
            Assert.AreEqual(TriangleTypes.Isosceles, ValidatorController.GetTriangleType(4, 3, 3));
        }

        [TestMethod]
        [Description("Test cases when triangle is Scalene")]
        public void GetTriangleTypeTestScalene()
        {
            Assert.AreEqual(TriangleTypes.Scalene, ValidatorController.GetTriangleType(3, 4, 5));
        }

        [TestMethod]
        [Description("Test results for the upper limit of the input")]
        public void GetTriangleTypeTestMaxValue()
        {
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(UInt32.MaxValue, 1000000000, 1000000000));
            Assert.AreEqual(TriangleTypes.Equilateral, ValidatorController.GetTriangleType(UInt32.MaxValue, UInt32.MaxValue, UInt32.MaxValue));
            Assert.AreEqual(TriangleTypes.Isosceles, ValidatorController.GetTriangleType(UInt32.MaxValue, 13, UInt32.MaxValue));
            Assert.AreEqual(TriangleTypes.Isosceles, ValidatorController.GetTriangleType(UInt32.MaxValue, UInt32.MaxValue - 5, UInt32.MaxValue));
            Assert.AreEqual(TriangleTypes.Scalene, ValidatorController.GetTriangleType(UInt32.MaxValue, UInt32.MaxValue - 10000, UInt32.MaxValue - 5000));
        }

        [TestMethod]
        [Description("Test results for the low limit of the input")]
        public void GetTriangleTypeTestMinValue()
        {
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(0, 1, 1));
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(1, 0, 1));
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(1, 1, 0));
        }

        [TestMethod]
        [Description("Test unsigned integer parsing using random integer from the valid range")]
        public void ParseInputTestValidInput()
        {

            // Add +1 as valid range is from [1:UInt32.MaxValue]
            UInt32 rndmInput = (UInt32)(rand.Next(int.MaxValue) + 1);
            Assert.AreEqual(rndmInput, ValidatorController.ParseInput(rndmInput.ToString()));
            Assert.AreEqual(UInt32.MaxValue, ValidatorController.ParseInput(UInt32.MaxValue.ToString()));
        }

        [TestMethod]
        [Description("Test unsigned integer parsing using random integer from the valid range")]
        public void ParseInputTestMaxInput()
        {
            Assert.AreEqual(UInt32.MaxValue, ValidatorController.ParseInput(UInt32.MaxValue.ToString()));
        }

        [TestMethod]
        [Description("Test parsing negative integer")]
        public void ParseInputTestNegativeInteger()
        {
            Assert.AreEqual(ZERO, ValidatorController.ParseInput("-1"));
        }

        [TestMethod]
        [Description("Test parsing float number")]
        public void ParseInputTestFloat()
        {
            Assert.AreEqual(ZERO, ValidatorController.ParseInput("1.0"));
        }

        [TestMethod]
        [Description("Test parsing non trimmed input")]
        public void ParseInputTestNonTrimmed()
        {
            Assert.AreEqual((UInt32)555, ValidatorController.ParseInput(" 555"));
        }

        [TestMethod]
        [Description("Test parsing empty string")]
        public void ParseInputTestEmpty()
        {
            Assert.AreEqual(ZERO, ValidatorController.ParseInput(""));
        }

        [TestMethod]
        [Description("Test invalid symbolic input")]
        public void ParseInputTestInvalidInput()
        {
            Assert.AreEqual(ZERO, ValidatorController.ParseInput("𐐷"));
            Assert.AreEqual(ZERO, ValidatorController.ParseInput("1 7"));
            Assert.AreEqual(ZERO, ValidatorController.ParseInput(UInt64.MaxValue.ToString()));
        }
    }
}