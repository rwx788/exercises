using NUnit.Framework;
using System;
using TriangleChecker.Controllers;

namespace TriangleChecked.UnitTests
{
    public class ValidatorControllerTests
    {
  
        [TestCase((UInt32)1, (UInt32)1, (UInt32)1, Description = "Test equilateral triangle using min possible length value")]
        [TestCase(UInt32.MaxValue, UInt32.MaxValue, UInt32.MaxValue, Description = "Test equilateral triangle using max possible length value")]
        public void GetTriangleTypeTestEquilateral(UInt32 sideA, UInt32 sideB, UInt32 sideC)
        {
            Assert.AreEqual(TriangleTypes.Equilateral, ValidatorController.GetTriangleType(sideA: sideA, sideB: sideB, sideC: sideC));
        }

        [TestCase((UInt32)4, (UInt32)3, (UInt32)3, Description = "Simple input for the isoscele triangle")]
        [TestCase(UInt32.MaxValue, (UInt32)13, UInt32.MaxValue, Description = "Test isosceles triangle using max possible length value")]
        public void GetTriangleTypeTestIsosceles(UInt32 sideA, UInt32 sideB, UInt32 sideC)
        {
            Assert.AreEqual(TriangleTypes.Isosceles, ValidatorController.GetTriangleType(sideA: sideA, sideB: sideB, sideC: sideC));
        }

        [TestCase((UInt32)4, (UInt32)3, (UInt32)5, Description = "Simple input for the scalene triangle")]
        [TestCase(UInt32.MaxValue, UInt32.MaxValue - 10000, UInt32.MaxValue - 5000, Description = "Test scalene triangle using max possible length value")]
        public void GetTriangleTypeTestScalene(UInt32 sideA, UInt32 sideB, UInt32 sideC)
        {
            Assert.AreEqual(TriangleTypes.Scalene, ValidatorController.GetTriangleType(sideA: sideA, sideB: sideB, sideC: sideC));
        }

        [TestCase((UInt32)5, (UInt32)1, (UInt32)3, Description = "Test simple input when triangle with given sides doesn't exist")]
        [TestCase(UInt32.MaxValue, (UInt32)1000000000, (UInt32)1000000000, Description = "Test input when triangle with given sides doesn't exist using max value")]
        [TestCase((UInt32)0, (UInt32)1, (UInt32)1, Description = "Test 0 length side as an input to the side A")]
        [TestCase((UInt32)1, (UInt32)0, (UInt32)1, Description = "Test 0 length side as an input to the side B")]
        [TestCase((UInt32)1, (UInt32)1, (UInt32)0, Description = "Test 0 length side as an input to the side C")]
        public void GetTriangleTypeTestNotTriangle(UInt32 sideA, UInt32 sideB, UInt32 sideC)
        {
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(sideA: sideA, sideB: sideB, sideC: sideC));
        }

        [TestCase(Description = "Test unsigned integer parsing using random integer from the valid range")]
        public void ParseInputTestRandomValidInput()
        {
            Random rand = new Random();
            // Add +1 as valid range is from [1:UInt32.MaxValue]
            UInt32 rndmInput = (UInt32)(rand.Next(int.MaxValue) + 1);
            Assert.AreEqual(rndmInput, ValidatorController.ParseInput(rndmInput.ToString()));
        }

        [TestCase(Description = "Test parsing maximal allowed value")]
        public void ParseInputTestMaxInput()
        {
            Assert.AreEqual(UInt32.MaxValue, ValidatorController.ParseInput(UInt32.MaxValue.ToString()));
        }

        // Storing UInt32 zero as a constant, as return type is UInt32
        private const UInt32 ZERO = 0;

        [TestCase("𐐷", ExpectedResult = ZERO,Description = "Test invalid symbolic input")]
        [TestCase("1 7", ExpectedResult = ZERO, Description = "Test space between symbols")]
        [TestCase("9999999999999999999999999999999999999999999999999999", ExpectedResult = ZERO, Description = "Test integer out of range")]
        [TestCase("", ExpectedResult = ZERO, Description = "Test parsing empty string")]
        [TestCase("1.0", ExpectedResult = ZERO, Description = "Test parsing float number")]
        [TestCase("-1", ExpectedResult = ZERO, Description = "Test parsing negative integer")]
        [TestCase(" 555 ", ExpectedResult = (UInt32)555, Description = "Test parsing non trimmed input")]
        public UInt32 ParseInputTestInvalidInput(string input)
        {
            return ValidatorController.ParseInput(input);
        }

    }
}