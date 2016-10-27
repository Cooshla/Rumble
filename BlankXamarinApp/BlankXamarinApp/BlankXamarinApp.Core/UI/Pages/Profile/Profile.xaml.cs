using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlankXamarinApp.Core.UI.Pages.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            BindingContext = App.ProfileViewModel;
            InitializeComponent();
        }
    }
}
