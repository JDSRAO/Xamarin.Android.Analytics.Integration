using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook;

namespace FacebookAnalyticsPoc
{
    [Activity(Label = "FacebookAnalyticsPoc", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            Xamarin.Facebook.FacebookSdk.ApplicationId = "133578600522256";
            FacebookSdk.SdkInitialize(this);
            Xamarin.Facebook.AppEvents.AppEventsLogger.ActivateApp(this);
            bool te = Xamarin.Facebook.FacebookSdk.IsInitialized;
        }
    }
}

