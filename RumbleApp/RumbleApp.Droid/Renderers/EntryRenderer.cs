using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using JamnationApp.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.Text;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace JamnationApp.Droid.Renderers
{
    public class CustomEntryRenderer: EntryRenderer
    {
        
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {

            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = this.Resources.GetDrawable(Resource.Layout.RoundedCornerEntry);
                Control.SetPadding(20, 10, 20, 5);
            }
        }
    }
}