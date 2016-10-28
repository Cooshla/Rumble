using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RumbleApp.Core.UI.Pages.Guide
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuidePage : ContentPage
    {
        public GuidePage()
        {
            BindingContext = App.GuideViewModel;
            InitializeComponent();
            
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                GuideWrapper.Padding = new Thickness(80, 80, 80, 80);
                GuideWrapper2.Padding = new Thickness(80, 210, 80, 80);
                GuideWrapper3.Padding = new Thickness(80, 210, 80, 80);
                GuideWrapper4.Padding = new Thickness(80, 210, 80, 80);
                //GuideWrapper5.Padding = new Thickness (80, 210, 80, 80);
                LogoSpacing.HeightRequest = 20;
                //Logo.Source = "logoLarge.png";
                LargeTextPage2.FontSize = 24;
                LargeTextPage3.FontSize = 24;
                LargeTextPage4.FontSize = 24;
                //LargeTextPage5.FontSize = 24;
            }

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
