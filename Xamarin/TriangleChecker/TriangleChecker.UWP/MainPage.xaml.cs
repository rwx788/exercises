namespace TriangleChecker.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TriangleChecker.App());
        }
    }
}
