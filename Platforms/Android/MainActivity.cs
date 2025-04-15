using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace BeyondHana;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        //Make Statusbar to white 
        Window.SetStatusBarColor(Android.Graphics.Color.White);

        //Force Application to Lanscape Mode
        RequestedOrientation = ScreenOrientation.Landscape;

        //Force Application to Full Screen Mode
        Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);

        //Make Application use Notch Area
        if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
        {
            Window.Attributes.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.ShortEdges;

        }

        //Make Application Not Shwoing Safe Area to Distrub Gameplay
        Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.ImmersiveSticky | SystemUiFlags.LayoutStable 
            | SystemUiFlags.LayoutFullscreen | SystemUiFlags.Fullscreen | SystemUiFlags.HideNavigation);
    }
}
