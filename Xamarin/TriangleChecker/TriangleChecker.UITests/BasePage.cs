using Xamarin.UITest;

namespace TriangleChecker.UITests.Pages
{
    public abstract class BasePage
    {
        protected IApp app => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;

        protected BasePage()
        {
        }

        protected void EnterText(string searchStr, string text)
        {
            app.WaitForElement(x => x.Marked(searchStr));
            // Workaround, as App.EnterText doesn't work with API version >= 29
            app.Query(x => x.Marked(searchStr).Invoke("setText", text));
        }
    }
}
