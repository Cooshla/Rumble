using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RumbleApp.Core.UI.Pages.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            try
            {
                BindingContext = App.ProfileViewModel;
                InitializeComponent();
            }
            catch(Exception ex)
            {
                string eee = ex.Message;
            }
        }
    }
}
