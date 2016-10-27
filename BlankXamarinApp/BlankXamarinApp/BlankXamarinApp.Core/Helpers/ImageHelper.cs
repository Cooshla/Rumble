using Plugin.Media;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using System.Globalization;
using System.IO;

namespace BlankXamarinApp.Core.Helpers
{

    public class ImageHelper
    {
        static async public Task<byte[]> GetPhoto()
        {

            var bytes = default(byte[]);
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.UserDialogService.AlertAsync("No Camera", ":( No camera avaialble.", "OK");
                return bytes;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "temp",
                Name = "temp.jpg"
            });

            if (file == null)
                return bytes;


            using (var streamReader = new StreamReader(file.GetStream()))
            {
                using (var memstream = new MemoryStream())
                {
                    streamReader.BaseStream.CopyTo(memstream);
                    bytes = memstream.ToArray();
                }
            }

            return bytes;


        }

    }
}
