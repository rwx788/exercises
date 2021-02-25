using Xamarin.UITest;

namespace TriangleChecker.UITests
{
    public class AppManager
    {
        public static IApp App
        { get; set; }

        public static Platform Platform
        { get; set; }

        public static void StartApp(Platform platform)
        {
            App = ConfigureApp.Android.InstalledApp("com.companyname.trianglechecker").StartApp();
            Platform = platform;
        }
    }
}