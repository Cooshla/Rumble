using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BlankXamarinApp.Core.UI.Pages.Events
{
    public partial class Events : ContentPage
    {
        public Events()
        {
            BindingContext = App.EventsViewModel;
            InitializeComponent();
        }
    }
}
