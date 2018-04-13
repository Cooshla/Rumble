using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Foundation;
using UIKit;

namespace JamnationApp.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			//Xamarin.Insights.Initialize (global::JamnationApp.iOS.XamarinInsights.ApiKey);
			NSUserDefaults.StandardUserDefaults ["AppleLanguages"] = NSArray.FromStrings ("en");
			NSUserDefaults.StandardUserDefaults.Synchronize ();
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture ("en-GB");
			UIApplication.Main (args, null, "AppDelegate");
		}

		public static void HandleIosException (object sender, UnhandledExceptionEventArgs e)
		{
			Exception excep = (Exception)e.ExceptionObject;
			System.Console.Write ("YOU'VE JUST BEEN HANDLED!");
		}
	}
}
