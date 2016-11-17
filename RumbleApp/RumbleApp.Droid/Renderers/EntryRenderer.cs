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
using RumbleApp.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.Text;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace RumbleApp.Droid.Renderers
{
    public class CustomEntryRenderer: EntryRenderer
    {
        #region Private fields and properties

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        #endregion

        #region Parent override

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;
            Control.Gravity = DefaultGravity;
            var entryEx = Element as Entry;
            UpdateBackground(entryEx);
            UpdatePadding(entryEx);
            UpdateTextAlighnment(entryEx);
        }

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);
        //    if (Element == null)
        //        return;
        //    var entryEx = Element as Entry;
        //    if (e.PropertyName == EntryEx.BorderWidthProperty.PropertyName ||
        //        e.PropertyName == EntryEx.BorderColorProperty.PropertyName ||
        //        e.PropertyName == EntryEx.BorderRadiusProperty.PropertyName ||
        //        e.PropertyName == EntryEx.BackgroundColorProperty.PropertyName)
        //    {
        //        UpdateBackground(entryEx);
        //    }
        //    else if (e.PropertyName == EntryEx.LeftPaddingProperty.PropertyName ||
        //        e.PropertyName == EntryEx.RightPaddingProperty.PropertyName)
        //    {
        //        UpdatePadding(entryEx);
        //    }
        //    else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
        //    {
        //        UpdateTextAlighnment(entryEx);
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_renderer != null)
                {
                    _renderer.Dispose();
                    _renderer = null;
                }
            }
        }

        #endregion

        #region Utility methods

        private void UpdateBackground(Entry entryEx)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(Color.FromHex("#e4e4e4"), Color.FromHex("#818181"),1, 30);
            Control.InputType = InputTypes.TextFlagNoSuggestions;
        }

        private void UpdatePadding(Entry entryEx)
        {
            Control.SetHeight((int)Forms.Context.ToPixels(40));
            Control.SetPadding(20,10,20,10);
            
        }

        private void UpdateTextAlighnment(Entry entryEx)
        {
            var gravity = DefaultGravity;
            switch (entryEx.HorizontalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
            }
            Control.Gravity = gravity;
        }

        #endregion
    }
}