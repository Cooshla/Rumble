using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;

namespace BlankXamarinApp.Core.UI.Pages.Map
{
    public partial class AddEvent : ContentPage
    {
        public AddEvent()
        {
            BindingContext = App.AddEventViewModel;
            InitializeComponent();
        }
    }
}
