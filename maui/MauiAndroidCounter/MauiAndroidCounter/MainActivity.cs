using Android.Util;
using Android.Views;
using Java.Interop;

namespace MauiAndroidCounter;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    private int _count = 1;
    private TextView? _txt;
    private readonly string _tag = "myapp";
        
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        // Set our view from the "main" layout_ resource
        SetContentView(Resource.Layout.activity_main);
        _txt = FindViewById<TextView>(Resource.Id.textView);
    }

    [Export("OnBtnClick")]
    public void OnBtnClick(View v)
    {
        _txt.Text = $"{_count++} clicks!";
    }
    
    [Export("OnAddLogcatBtnClick")]
    public void OnAddLogcatBtnClick(View v)
    {
        Log.Info (_tag, "This is an info message");
        Log.Warn (_tag, "This is a warning message");
        Log.Error (_tag, "This is an error message");
    }
}