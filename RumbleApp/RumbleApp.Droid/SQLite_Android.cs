using System;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using RumbleApp.Droid;
using RumbleApp.Core;

namespace RumbleApp.Droid
{
    
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLiteConnection GetConnection()
        {
     
            var fileName = "RumbleApp.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine (documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
            
           
       
            // COMMENT OUT ABOVE AND UNCOMMENT BELOW TO RECREATE THE db ON YOUR ANDROIDS LOCAL FILE FOLDER
          /*
            var fileName = "RumbleApp.db3";
            // this line of code saves the DB to the MYFiles folder on your android which you can then go to to get the DB
            var documentsPath =Android.OS.Environment.ExternalStorageDirectory.Path;
            var path = Path.Combine (documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid ();
            var connection = new SQLite.Net.SQLiteConnection (platform, path);

            return connection;
 */
        }
    }
}

