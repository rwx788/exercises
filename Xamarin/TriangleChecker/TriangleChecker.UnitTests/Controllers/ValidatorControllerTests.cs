using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleChecker.Controllers.Tests
{
    [TestClass()]
    public class ValidatorControllerTests
    {
        [TestMethod()]
        public void GetTriangleTypeTestNone()
        {
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(0, 0, 0));
            Assert.AreEqual(TriangleTypes.None, ValidatorController.GetTriangleType(-1, -5, -3));
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
            Assert.AreEqual(TriangleTypes.None,        ValidatorController.GetTriangleType(2147483647, 1000000000, 1000000000));
            Assert.AreEqual(TriangleTypes.Equilateral, ValidatorController.GetTriangleType(2147483647, 2147483647, 2147483647));
            Assert.AreEqual(TriangleTypes.Isosceles,   ValidatorController.GetTriangleType(2147483647, 13, 2147483647));
            Assert.AreEqual(TriangleTypes.Isosceles,   ValidatorController.GetTriangleType(2147483647, 2147483647, 2147483647));
            Assert.AreEqual(TriangleTypes.Scalene,     ValidatorController.GetTriangleType(2147483647, 2147400000, 2147312344));
        }

    }
}