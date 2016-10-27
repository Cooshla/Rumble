using Plugin.Media;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using System.Globalization;
using System.IO;
using XLabs.Platform.Services.Media;

namespace BlankXamarinApp.Core.Helpers
{

    public class ImageHelper
    {
        static async public Task<byte[]> GetPhoto()
        {

            Stream returnValue = await App.MediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var s = t.Exception.InnerException.ToString();
                }
                else if (t.IsCanceled)
                {
                    var canceled = true;
                }
                else
                {
                    var mediaFile = t.Result;

                    return mediaFile.Source;
                }

                return null;
            });

            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = returnValue.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
            }

            return buffer;



        }

    }
}
