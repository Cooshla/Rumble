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

        private void Step1_Clicked(object sender, EventArgs e)
        {
            Step1.IsVisible = false;
            Step2.IsVisible = true;
            Step3.IsVisible = false;
        }

        private void Step2_Clicked(object sender, EventArgs e)
        {
            Step1.IsVisible = false;
            Step2.IsVisible = false;
            Step3.IsVisible = true;
        }

        private void Step3_Clicked(object sender, EventArgs e)
        {
            Step1.IsVisible = false;
            Step2.IsVisible = false;
            Step3.IsVisible = false;
        }
    }
}
