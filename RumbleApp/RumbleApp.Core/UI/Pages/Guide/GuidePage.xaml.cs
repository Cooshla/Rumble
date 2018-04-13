using JamnationApp.Core.ViewModels.Guide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JamnationApp.Core.UI.Pages.Guide
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuidePage : ContentPage
    {
        public GuidePage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<GuideViewModel, int>(this, Messages.Walkthrough, (sender, arg) => {
                Carousel.Position = arg;
            });
        }
    }
}
