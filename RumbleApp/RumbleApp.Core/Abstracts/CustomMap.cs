using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace JamnationApp.Core.Abstracts
{
    public class CustomMap : Map
    {
        public static readonly BindableProperty PinsProperty = BindableProperty.Create<CustomMap, List<CustomPin>>(p => p.CustomPins, new List<CustomPin>());
        public List<CustomPin> CustomPins
        {
            get
            {
                return (List<CustomPin>)GetValue(PinsProperty);
            }
            set
            {
                if (CustomPins == value)
                    return;
                SetValue(PinsProperty, value);
                OnPropertyChanged("CustomPins");
            }
        }

    }
    public class CustomPin
    {
        public Pin Pin { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
    }
}
