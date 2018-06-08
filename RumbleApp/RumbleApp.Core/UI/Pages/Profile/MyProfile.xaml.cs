using JamnationApp.Core.ViewModels.Profile;
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
    public partial class MyProfile : ContentPage
    {
        public MyProfile()
        {
            BindingContext = App.ViewModelLocator.ViewProfile;
            InitializeComponent();

            MessagingCenter.Subscribe<ViewProfileViewModel, JamnationApp.Core.Models.Profile>(this, Messages.AddressLookupCalled, (sender, arg) => {
                var pos = new Position(arg.Latitude, arg.Longitude);
                MyMap.Pins.Clear();
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromMiles(5)));
                MyMap.Pins.Add(new Pin()
                {
                    Position = pos,
                    Label = "This is you!", Address=arg.Location, Type=PinType.Generic
                });



            });

            MessagingCenter.Subscribe<ViewProfileViewModel, HtmlWebViewSource>(this, Messages.SetWebViewSource, (sender, arg) => {
                SoundCloudEmbedLabel.Source = arg;
            });

            MessagingCenter.Subscribe<ViewProfileViewModel, string>(this, Messages.SetProfile, (sender, arg) => {
                SetInterests(arg);
            });

            MessagingCenter.Subscribe<MainPage, bool>(this, Messages.ProfileClicked, async (sends, arg) =>
            {
                ToggleDesc(false);
                ToggleSoundcloud(false);
            });
        }

        protected async override void OnDisappearing()
        {


            if (App.ViewModelLocator.ViewProfile.IsDirty)
            {
                if (await App.UserDialogService.ConfirmAsync("Would you like to save your changes?"))
                {
                    App.ViewModelLocator.ViewProfile.Save();
                }
            }

            base.OnDisappearing();            
        }


        public void SetInterests (string Interests)
        {
            InterestsLabel.Text = Interests;
        }

        public  void ToggleDesc(bool show) {
            if (show)
            {

                this.DescriptionLabel.IsVisible = true;
                this.DescriptionEntry.IsVisible = false;
            }
            else
            {

                this.DescriptionLabel.IsVisible = false;
                this.DescriptionEntry.IsVisible = true;
            }
        }
        public void ToggleSoundcloud(bool show) {
            if (show)
            {

                this.SoundCloudEmbedLabel.IsVisible = true;
                this.SoundCloudEmbedEntry.IsVisible = false;

            }
            else
            {

                this.SoundCloudEmbedLabel.IsVisible = false;
                this.SoundCloudEmbedEntry.IsVisible = true;

            }
        }

       
        private void DescriptionTextChanged(object sender, TextChangedEventArgs e)
        {
            App.ViewModelLocator.ViewProfile.Description = DescriptionEntry.Text;
            DescriptionLabel.Text = DescriptionEntry.Text;
        }

        private void SoundCloudTextChanged(object sender, TextChangedEventArgs e)
        {
            HtmlWebViewSource src = new HtmlWebViewSource() { Html = SoundCloudEmbedEntry.Text };
            SoundCloudEmbedLabel.Source = src;
            App.ViewModelLocator.ViewProfile.SoundCloudEmbed = SoundCloudEmbedEntry.Text;
        }
        
    }
}
