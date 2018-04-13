using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JamnationApp.Core.UI.Pages.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

        }

        private void LoginLink_Tapped(object sender, EventArgs e)
        {

            Start.IsVisible = false;
            LoginSelection.IsVisible = true;
            LoginEmail.IsVisible = false;
        }

        private void Email_Clicked(object sender, EventArgs e)
        {

            Start.IsVisible = false;
            LoginSelection.IsVisible = false;
            LoginEmail.IsVisible = true;
        }

        private void Facebook_Clicked(object sender, EventArgs e)
        {

        }
    }
}
