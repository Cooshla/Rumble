using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumbleApp.Core.Objects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RumbleApp.Core.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MasterPage()
        {
            BindingContext = App.MasterPageViewModel;
            InitializeComponent();
        }
    }
}
