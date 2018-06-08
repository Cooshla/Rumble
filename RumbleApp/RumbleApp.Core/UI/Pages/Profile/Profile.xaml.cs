using JamnationApp.Core.Abstracts;
using JamnationApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace JamnationApp.Core.UI.Pages.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();


            MessagingCenter.Subscribe<ProfileViewModel, JamnationApp.Core.Models.Profile>(this, Messages.AddressLookupCalled, (sender, arg) => {
                var pos = new Position(arg.Latitude, arg.Longitude);
                MyMap.Pins.Clear();
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromMiles(5)));
                MyMap.Pins.Add(new Pin()
                {
                    Position = pos,
                    Label = arg.DisplayName,
                    Address=arg.Location,
                    Type = PinType.Generic
                });

                InterestsLabel.Text = arg.Interests;
                DescriptionLabel.Text = arg.Description;
                ProfileImage.Source = arg.FullImageUrl;
                ProfileName.Text = arg.DisplayName;
            });

            MessagingCenter.Subscribe<ProfileViewModel, HtmlWebViewSource>(this, Messages.SetWebViewSource, (sender, arg) => {
                SoundCloudEmbedLabel.Source = arg;
            });


        }
    }
}
