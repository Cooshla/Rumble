using System;
using System.Reflection;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Locations;
using Android.Content;
using JamnationApp.Core;
using Xamarin;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using Android.Runtime;
using System.IO;
using Acr.UserDialogs;
using JamnationApp.Core.ViewModels;
using XLabs.Platform.Services.Geolocation;
using ImageCircle.Forms.Plugin.Droid;
using RoundedBoxView.Forms.Plugin.Droid;

namespace JamnationApp.Droid
{
    [Activity(Label = "Jamnation", 
        Theme = "@android:style/Theme.Holo.Light", 
        Icon = "@android:color/transparent",
        MainLauncher = false,
		ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait
	)]


    public class MainActivity : XFormsApplicationDroid, ILocationListener
    {
        public LocationManager locMgr;		
        public string locationProvider;

        protected override void OnCreate(Bundle bundle)
        { 
			AndroidEnvironment.UnhandledExceptionRaiser += HandleAndroidException;

           
			base.OnCreate(bundle);
			Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            App.Version = ApplicationContext.PackageManager.GetPackageInfo(ApplicationContext.PackageName, 0).VersionName;
			UserDialogs.Init (this);
            RoundedBoxViewRenderer.Init();
            ImageCircleRenderer.Init();
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            //this is needed for UI testing
            Forms.ViewInitialized += (sender, e) =>
            {
                if (!String.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };

			// App.UserDialogService = new UserDialogService(); - OLD
			// COMMENT OUT TO CREATE NEW DB
			//InitializeDatabase ();
            InitializeDevice();
            App.Init(new AppSetup());
            LoadApplication(new App());

            var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;

            App.ScreenWidth = (width - 0.5f) / density;
            App.ScreenHeight = (height - 0.5f) / density;

            App.AppLoadedDateTime = DateTime.UtcNow;


            var x = typeof(Xamarin.Forms.Themes.LightThemeResources);
            x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
        }

        public void InitializeDatabase()
		{
			
			string dbName = "JamnationApp.db3";
            
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            //string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, dbName);


			if (!File.Exists (dbPath)) {
				using (BinaryReader br = new BinaryReader (Assets.Open (dbName))) {
					using (BinaryWriter bw = new BinaryWriter (new FileStream (dbPath, FileMode.Create))) {
						byte[] buffer = new byte[2048];
						int len = 0;
						while ((len = br.Read (buffer, 0, buffer.Length)) > 0) {
							bw.Write (buffer, 0, len);
						}
					}
				}
			}

		}

		void HandleAndroidException(object sender, RaiseThrowableEventArgs e)
		{
			string s = e.Exception.StackTrace;

			//Device.BeginInvokeOnMainThread(() => App.UserDialogService.HideLoading());

			e.Handled = true;
			System.Console.Write("YOU'VE JUST BEEN HANDLED!");
          
		}

        private void InitializeDevice()
        {
            if (!Resolver.IsSet)
            {
                var resolver = new SimpleContainer().Register<IDevice>(device => AndroidDevice.CurrentDevice); 
                Resolver.SetResolver(resolver.GetResolver());
            }
        }


        protected override void OnPause()
        {
			base.OnPause();

        }

        protected override void OnResume()
         {		
             base.OnResume();	
           
         }

      protected override void OnDestroy()
		{
			base.OnDestroy();
			
        }

                #region ILocationListiner		
 		
         public void OnProviderEnabled(string provider)
         {		
         }		
 		
         public void OnProviderDisabled(string provider)
         {		
         }		
 		
         public void OnStatusChanged(string provider, Android.Locations.Availability status, Bundle extras)
         {		
         }		
 		
 		
         public void OnLocationChanged(Android.Locations.Location location)
         {		/*
             System.Diagnostics.Debug.WriteLine("Localisation change");		
             App.MyLocation.Longitude = location.Longitude;		
             App.MyLocation.Latitude = location.Latitude;		
             App.MyLocation.LocationFound = true;		
             locMgr.RemoveUpdates(this);
             */		
         }		
 		
         #endregion		
 		
         private readonly long UPDATE_TIME = 30000;		
 		
         private readonly long UPDATE_DISTANCE = 100;		
 		
        void InitializeLocation()
         {		
 					/*
             locMgr = GetSystemService(Context.LocationService) as LocationManager;		
             Criteria locationCriteria = new Criteria()
             {		
                 Accuracy = Accuracy.Coarse,		
                 PowerRequirement = Power.Medium		
             }; 		
 		
             locationProvider = locMgr.GetBestProvider(locationCriteria, true);		
 		
 			if (locationProvider != null) {		
 				locMgr.RequestSingleUpdate (locationProvider, this,null);		
 				locMgr.RequestLocationUpdates (locationProvider, UPDATE_TIME, UPDATE_DISTANCE, this);		
 			}		
            */
         }
    }
}