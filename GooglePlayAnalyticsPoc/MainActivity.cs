using Android.App;
using Android.Widget;
using Android.OS;

namespace GooglePlayAnalyticsPoc
{
    [Activity(Label = "GooglePlayAnalyticsPoc", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            GPAService.GetGASInstance().Initialize(this);
            // Track a page
            GPAService.GetGASInstance().Track_App_Page("Home Page");

            // Track an event
            GPAService.GetGASInstance().Track_App_Event("GPAService.Category1", "hey ! Category 1 type event ocurred !");

            //// Track an Exception
            //GPAService.GetGASInstance().Track_App_Exception( , false);
        }
    }
}

