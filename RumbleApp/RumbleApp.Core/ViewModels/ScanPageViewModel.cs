using RumbleApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace RumbleApp.Core.ViewModels
{
    public class ScanPageViewModel
    {
        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }


        public ICommand ScanCommand { get { return new Command(Scan); } }

        public ScanPageViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            PageFac = _page;
            Navi = _navi;
        }
        

        public async void Scan()
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navi.PopModal();
                    App.UserDialogService.AlertAsync( result.Text, "Scanned Barcode", "OK");
                });
            };

            // Navigate to our scanner page
            await Navi.PushPage(scanPage);

        }
    }
}
