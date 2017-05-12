using Android.App;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;

namespace HockeyAppPoc
{
    [Activity(Label = "HockeyAppPoc", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            MetricsManager.Register(Application, "bb03a18ffefc47a8936d06961ceaa6d1");
            CheckForUpdates();
            Button button = FindViewById<Button>(Resource.Id.button);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnResume()
        {
            base.OnResume();
            CrashManager.Register(this, "bb03a18ffefc47a8936d06961ceaa6d1");
        }

        private void CheckForUpdates()
        {
            // Remove this for store builds!
            UpdateManager.Register(this, "bb03a18ffefc47a8936d06961ceaa6d1");
        }

    }
}

