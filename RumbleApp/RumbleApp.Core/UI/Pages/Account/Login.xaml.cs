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

        private async  void LoginLink_Tapped(object sender, EventArgs e)
        {

            // Fade out over 1 seconds
            await Start.FadeTo(0, 200);
            Start.IsVisible = false;

            // Fade in over 1 second
            await LoginSelection.FadeTo(0, 200);
            LoginSelection.IsVisible = true;
            LoginSelection.FadeTo(1, 200);

            LoginEmail.IsVisible = false;
        }

        private async void Email_Clicked(object sender, EventArgs e)
        {

            Start.IsVisible = false;
            
            // Fade out over 1 seconds
            await LoginSelection.FadeTo(0, 200);
            LoginSelection.IsVisible = false;

            // Fade in over 1 second
            await LoginEmail.FadeTo(0, 200);
            LoginEmail.IsVisible = true;
            LoginEmail.FadeTo(1, 200);
            
            
        }

        private async void Facebook_Clicked(object sender, EventArgs e)
        {

        }

        private async void BackStep1_Clicked(object sender, EventArgs e)
        {

            // Fade out over 1 seconds
            await LoginSelection.FadeTo(0, 200);
            LoginSelection.IsVisible = false;

            // Fade in over 1 second
            await Start.FadeTo(0, 200);
            Start.IsVisible = true;
            Start.FadeTo(1, 200);


            
            LoginEmail.IsVisible = false;
        }

        private async void BackStep2_Clicked(object sender, EventArgs e)
        {


            // Fade out over 1 seconds
            await LoginEmail.FadeTo(0, 200);
            LoginEmail.IsVisible = false;

            // Fade in over 1 second
            await LoginSelection.FadeTo(0, 200);
            LoginSelection.IsVisible = true;
            LoginSelection.FadeTo(1, 200);
            
            Start.IsVisible = false;
        }

        
    }
}
