using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RumbleApp.Core.UI.Pages.Events
{
    public partial class EventDetail : ContentPage
    {
        public EventDetail()
        {
            BindingContext = App.EventDetailViewModel;
            InitializeComponent();
        }
    }
}
