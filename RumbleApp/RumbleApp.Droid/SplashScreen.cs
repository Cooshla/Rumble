using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using Android.Util;
using System.Threading.Tasks;

namespace RumbleApp.Droid
{
    [Activity(Label = "Blank Xamarin App", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class SplashScreen : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashScreen).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }
        private Intent mainIntent { get; set; }

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => {
                Log.Debug(TAG, "Performing some startup work that takes a bit of time.");

                mainIntent = new Intent(this, typeof(MainActivity));
                Log.Debug(TAG, "Working in the background - important stuff.");
            });

            startupWork.ContinueWith(t => {
                Log.Debug(TAG, "Work is finished - start Activity1.");
                StartActivity(mainIntent);
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }

    }
}
