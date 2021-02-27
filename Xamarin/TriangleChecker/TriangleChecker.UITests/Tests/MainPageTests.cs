using NUnit.Framework;
using TriangleChecker.Resources;
using Xamarin.UITest;

namespace TriangleChecker.UITests
{
    [TestFixture(Platform.Android)]
    public class MainPageTests
    {
        readonly Platform platform;
        Pages.MainPage mainPage;

        public MainPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void RunBeforeEachTests()
        {
            AppManager.StartApp(platform);
            mainPage = new Pages.MainPage();
        }

        [TestCase]
        public void TestHeaderIsDisplayed()
        {
            Assert.IsTrue(mainPage.IsHeaderDisplayed());
        }

        [TestCase("5", "5", "5")]
        public void TestEquilateral(string sideA, string sideB, string sideC)
        {
            mainPage.EnterSideLengths(sideA: sideA, sideB: sideB, sideC: sideC);
            mainPage.PressRunButton();
            Assert.AreEqual(ValidatorRes.ResultEquilateral, mainPage.GetResultText());
        }

        [TestCase("5", "7", "7")]
        public void TestIsosceles(string sideA, string sideB, string sideC)
        {
            mainPage.EnterSideLengths(sideA: sideA, sideB: sideB, sideC: sideC);
            mainPage.PressRunButton();
            Assert.AreEqual(ValidatorRes.ResultIsosceles, mainPage.GetResultText());
        }

        [TestCase("5", "7", "3")]
        public void TestScalene(string sideA, string sideB, string sideC)
        {
            mainPage.EnterSideLengths(sideA: sideA, sideB: sideB, sideC: sideC);
            mainPage.PressRunButton();
            Assert.AreEqual(ValidatorRes.ResultScalene, mainPage.GetResultText());
        }

        [TestCase("7", "4", "3")]
        [TestCase("20 ", " 7", "13 ")]
        public void TestNotTriangle(string sideA, string sideB, string sideC)
        {
            mainPage.EnterSideLengths(sideA: sideA, sideB: sideB, sideC: sideC);
            mainPage.PressRunButton();
            Assert.AreEqual(ValidatorRes.ResultNone, mainPage.GetResultText());
        }

        [TestCase("5.0", "1 7", "-9223372036854775808")]
        [TestCase("18446744073709551615", "𐐷", "")]
        public void TesInvalidInput(string sideA, string sideB, string sideC)
        {
            mainPage.EnterSideLengths(sideA: sideA, sideB: sideB, sideC: sideC);
            mainPage.PressRunButton();
            Assert.AreEqual(ValidatorRes.InvalidInput, mainPage.GetResultText());
        }

        [TestCase(Description = "Test output when Run button is pressed without any input")]
        public void TestNoInput()
        {
            mainPage.PressRunButton();
            Assert.AreEqual(ValidatorRes.InvalidInput, mainPage.GetResultText());
        }
    }
}
