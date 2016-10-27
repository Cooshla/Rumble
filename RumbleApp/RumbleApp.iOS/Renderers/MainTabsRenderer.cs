using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;
using TheCaravanClub.Core;
using TheCaravanClub.Core.Abstracts;
using TheCaravanClub.iOS;
using TheCaravanClub.Core.ViewModels;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;


[assembly: ExportRenderer (typeof(MainTabs), typeof(MainTabsRenderer))]
namespace TheCaravanClub.iOS
{
	public class MainTabsRenderer : TabbedRenderer
	{

		public override void ViewDidLoad()
		{
			
			UIImageView imgView1;
			UIImage img1;

			//if the screen height is larger than 480, we're on an 4" screen. Show
			//the largest image. Otherwise pull the 3.5" screen image for retina or not.
			//if ((UserInterfaceIdiomIsPhone) && (UIScreen.MainScreen.Bounds.Height > 480)) {
				//img1 = UIImage.FromFile("images/splashimage@568.png");
			//} else {
				//img1 = UIImage.FromBundle("images/splashimage");
			//}

			img1 = UIImage.FromBundle("splashimage320");
			imgView1 = new UIImageView(new RectangleF(0,-20,float.Parse(UIScreen.MainScreen.Bounds.Width.ToString()),float.Parse(UIScreen.MainScreen.Bounds.Height.ToString())));
			imgView1.Image = img1;
			this.View.AddSubview(imgView1);
			Debug.WriteLine ("sleep");
			base.ViewDidLoad ();
			Task.Delay (5000);
			Debug.WriteLine ("wake");
			this.View.WillRemoveSubview (imgView1);


		}


	}
}

