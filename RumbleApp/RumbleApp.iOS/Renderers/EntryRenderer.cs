using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using RumbleApp.iPhone.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntryRenderer), typeof(EntryRenderer))]
namespace RumbleApp.iPhone.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = 5;
                Control.Layer.BorderColor = ToCGColor(Color.FromHex("#666666"));

                Control.LeftView = new UIView(new CGRect(0, 0, 20, 0));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIView(new CGRect(0, 0, 20, 0));
                Control.RightViewMode = UITextFieldViewMode.Always;
                //Control.SetPadding(20, 10, 20, 5);
            }
        }

        CoreGraphics.CGColor ToCGColor(Color color)
        {
            UIKit.UIColor uicolor = new UIKit.UIColor(
            (System.nfloat)color.R,
            (System.nfloat)color.G,
            (System.nfloat)color.B,
            (System.nfloat)color.A);
            return uicolor.CGColor;
        }
    }
}