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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();            
        }

        private async void Step1_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
                App.UserDialogService.Alert("Please fill in all required fields");
            else
            {
                // Fade out over 1 seconds
                await Step1.FadeTo(0, 200);
                Step1.IsVisible = false;

                // Fade in over 1 second
                await Step2.FadeTo(0, 200);
                Step2.IsVisible = true;
                Step2.FadeTo(1, 200);

                Step3.IsVisible = false;
            }
            
        }


        private async void Step2_Clicked(object sender, EventArgs e)
        {
            Step1.IsVisible = false;

            // Fade out over 1 seconds
            await Step2.FadeTo(0, 200);
            Step2.IsVisible = false;

            // Fade in over 1 second
            await Step3.FadeTo(0, 200);
            Step3.IsVisible = true;
            Step3.FadeTo(1, 200);
        }

        private async void Step2Back(object sender, EventArgs e)
        {
            // Fade out over 1 seconds
            await Step2.FadeTo(0, 200);
            Step2.IsVisible = false;

            // Fade in over 1 second
            await Step1.FadeTo(0, 200);
            Step1.IsVisible = true;
            Step1.FadeTo(1, 200);

            Step3.IsVisible = false;
        }

        private async void Step3_Clicked(object sender, EventArgs e)
        {
            Step1.IsVisible = false;
            Step2.IsVisible = false;

            // Fade out over 1 seconds
            await Step3.FadeTo(0, 200);
            Step3.IsVisible = false;

            // Fade in over 1 second
            await Step4.FadeTo(0, 200);
            Step4.IsVisible = true;
            Step4.FadeTo(1, 200);
        }
        private async void Step3Back(object sender, EventArgs e)
        {

            Step1.IsVisible = false;
            Step4.IsVisible = false;

            // Fade out over 1 seconds
            await Step3.FadeTo(0, 200);
            Step3.IsVisible = false;

            // Fade in over 1 second
            await Step2.FadeTo(0, 200);
            Step2.IsVisible = true;
            Step2.FadeTo(1, 200);
        }

        private async void Step4Back(object sender, EventArgs e)
        {

            Step1.IsVisible = false;
            Step2.IsVisible = false;

            // Fade out over 1 seconds
            await Step4.FadeTo(0, 200);
            Step4.IsVisible = false;

            // Fade in over 1 second
            await Step3.FadeTo(0, 200);
            Step3.IsVisible = true;
            Step3.FadeTo(1, 200);
        }


    }
}
