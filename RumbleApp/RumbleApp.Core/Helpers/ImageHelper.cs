
using System.Threading.Tasks;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace JamnationApp.Core.Helpers
{

    public class ImageHelper
    {
        
        static async public Task<byte[]> GetPhoto()
        {

            bool cont = true;
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                App.UserDialogService.Alert("No Camera", ":( No camera available.", "OK");
                cont = false;
            }

            if (cont)
            {

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg",
                    AllowCropping =true,
                    PhotoSize =PhotoSize.Small,
                    CompressionQuality=50
                    
                });
                
                /*
                Stream returnValue = await App.MediaPicker.TakePhotoAsync(new CameraMediaStorageOptions {  DefaultCamera = CameraDevice.Front,  MaxPixelDimension = 200 }).ContinueWith(t =>
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
                }*/

                return ReadFully(file.GetStream());
            }
            else
                return null;


        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }
}
