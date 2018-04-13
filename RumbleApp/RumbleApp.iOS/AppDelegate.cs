
using System;
using System.Reflection;
using Foundation;
using JamnationApp.Core;
using JamnationApp.iOS.Services;
using UIKit;
using Xamarin.Forms;
using Xamarin;
using XLabs.Forms;
using XLabs.Platform.Device;
using CoreLocation;
using XLabs.Ioc;
using System.IO;
using JamnationApp.Core.ViewModels;

namespace JamnationApp.iOS
{

    [Register("AppDelegate")]
    public partial class AppDelegate : XFormsApplicationDelegate
    {
        UIWindow window;

        public static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public IOSSetup setup;

        public static LocationManager Manager { get; set; }

        //todo - check this is correct event - https://developer.xamarin.com/guides/ios/application_fundamentals/backgrounding/part_2_application_lifecycle_demo/
        public override void DidEnterBackground(UIApplication application)
        {
            //this may error if long is too large (believe > 2.5h), so we default it
            long ms = 99;
            try
            {
                TimeSpan span = DateTime.UtcNow - App.AppLoadedDateTime;
                ms = span.Ticks;
            }
            catch (Exception ex)
            {
                //don't report   
            }
        
            base.DidEnterBackground(application);
        }


        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
		

            Insights.Initialize("085df48db4be333b9a97c2a7864f56a4b02d4d38");

            Forms.Init();
			FormsMaps.Init();
            Xamarin.Behaviors.Infrastructure.Init();
            //App.UserDialogService = new UserDialogService();


 
            //Native.Initialize();

            InitializeDatabase();
            //InitializeLocation();
            InitializeDevice(); 
            App.Init(new IOSSetup());
			setup = new IOSSetup();

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			App appClass = new App ();

			LoadApplication(appClass);
			//** Quick fix - need to be careful of this hardcoding if it stays in...
            App.Version = "1.2." + NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
			System.Diagnostics.Debug.WriteLine ("App Version:" + App.Version);
            App.AppLoadedDateTime = DateTime.UtcNow;
			//UIApplication.SharedApplication.IdleTimerDisabled = true;

			

			

			foreach(var item in app.Windows){
					item.WindowLevel = -250;
			}
				
            return base.FinishedLaunching(app, options);
        }
			

        public void InitializeDatabase()
        {
            const string dbName = "JamnationApp.db3"; 
            var libraryPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "..", "Library");
            var dbPath = Path.Combine (libraryPath, dbName); 

            var sourcePath = 
                Path.Combine(NSBundle.MainBundle.BundlePath,
                   "Assets/"+ dbName);
            if (!File.Exists(dbPath))
            {
                File.Copy(sourcePath, dbPath);
                NSFileManager.SetSkipBackupAttribute(dbPath, true);
            }
        }

		private void CopyFileInBundleToDocumentsFolder(String filename)
		{
			//---path to Documents folder---
			var documentsFolderPath =
				Environment.GetFolderPath(
					Environment.SpecialFolder.Personal);

			//---destination path for file in the Documents
			// folder---
			var destinationPath =
				Path.Combine(documentsFolderPath, filename);



			try {
				//---copy only if file does not exist---
				if (!File.Exists(destinationPath))
				{
					Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"JamnationApp.iPhone.Assets.JamnationApp.db3");

					var fileStream = File.Create(destinationPath);
					str.Seek(0, SeekOrigin.Begin);
					str.CopyTo(fileStream);
					fileStream.Close();

				}  else {
					Console.WriteLine("File already exists");
				}
			}  catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}



        private void InitializeDevice()
        {
            if (!Resolver.IsSet)
            {
                var resolver = new SimpleContainer().Register<IDevice>(device => AppleDevice.CurrentDevice); 
                Resolver.SetResolver(resolver.GetResolver());
            }
        }


      
    }
}