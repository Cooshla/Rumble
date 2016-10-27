using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;


namespace RumbleApp.Api.Helpers
{

    public static class ImageHelper
    {
        /// <summary>
        /// save an image with a guid as its name.  so each iteration of an image would be unique.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="subFolder"></param>
        /// <returns></returns>
        public static string SaveImageAsGuid(byte[] image, string subFolder)
        {
            return SaveImage(image, subFolder, Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Save image locally and return remote URL
        /// </summary>
        /// <param name="image"></param>
        /// <param name="subFolder"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string SaveImage(byte[] image, string subFolder, string fileName)
        {



            string[] paths = { "images", subFolder, fileName + ".png" };
            string file = Path.Combine(paths);
            var localPath = Path.Combine(HttpContext.Current.Server.MapPath("~/"), file);

            try
            {
                //System.IO.MemoryStream myMemStream = new System.IO.MemoryStream(image);
                //System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
                //fullsizeImage.Save(localPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                //APS New way 
                var fs = new BinaryWriter(new FileStream(localPath, FileMode.Append, FileAccess.Write));
                fs.Write(image);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
            // TO DO 
            // var remotePath = Path.Combine(ServerSettings.ServerUrl, file).Replace("\\", "/");
            //return remotePath;

            return null;
        }
    }
}