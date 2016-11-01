using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RumbleApp.Core.UI.Pages.Profile
{
    public partial class MyProfile : ContentPage
    {
        public MyProfile()
        {
            BindingContext = App.ViewProfileViewModel;
            InitializeComponent();
        }
    }
}
