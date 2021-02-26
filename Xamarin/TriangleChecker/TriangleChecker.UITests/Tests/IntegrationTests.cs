using NUnit.Framework;
using TriangleChecker.Resources;
using Xamarin.UITest;

namespace TriangleChecker.UITests
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            AppManager.StartApp(platform);
        }

        [Test]
        public void HeaderIsDisplayed()
        {
            Assert.IsTrue(new Pages.MainPage().IsHeaderDisplayed());
        }

        [TestCase("5", "5", "5")]
        public void TestSimple(string sideA, string sideB, string sideC)
        {
            Pages.MainPage mainPage = new Pages.MainPage();
            mainPage.SetSideALength(sideA);
            mainPage.SetSideBLength(sideB);
            mainPage.SetSideCLength(sideC);
            mainPage.PressRunButton();
            Assert.AreEqual(ValidatorRes.ResultEquilateral, mainPage.GetResultText());
        }
    }
}
