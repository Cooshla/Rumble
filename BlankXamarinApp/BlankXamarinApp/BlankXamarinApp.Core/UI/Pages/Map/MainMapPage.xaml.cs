using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BlankXamarinApp.Core.UI.Pages.Map
{
    public partial class MainMapPage : ContentPage
    {
        public MainMapPage()
        {
            BindingContext = App.MainMapPageViewModel;
            InitializeComponent();
        }
    }
}
