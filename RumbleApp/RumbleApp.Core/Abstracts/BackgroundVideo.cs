using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XLabs;
using XLabs.Forms.Controls;

namespace JamnationApp.Core.Abstracts
{
	public class BackgroundVideo :  View
    {
        public static readonly BindableProperty SourceProperty =
        BindableProperty.Create(
        nameof(Source),
        typeof(string),
        typeof(BackgroundVideo),
        string.Empty,
        BindingMode.TwoWay);

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty LoopProperty =
        BindableProperty.Create(
        nameof(Loop),
        typeof(bool),
        typeof(BackgroundVideo),
        true,
        BindingMode.TwoWay);

        public bool Loop
        {
            get { return (bool)GetValue(LoopProperty); }
            set { SetValue(LoopProperty, value); }
        }

        public Action OnFinishedPlaying { get; set; }
    }
}
