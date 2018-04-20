using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamnationApp.Core.Objects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JamnationApp.Core.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MasterPage()
        {
            BindingContext = App.ViewModelLocator.MasterPage;
            InitializeComponent();
        }
    }
}
