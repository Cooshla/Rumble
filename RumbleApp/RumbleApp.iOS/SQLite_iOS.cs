using System;
using JamnationApp.Core;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using JamnationApp.iOS;


[assembly: Dependency (typeof (SQLite_iOS))]
namespace JamnationApp.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        public SQLiteConnection GetConnection ()
        {
            var fileName = "JamnationApp.db3";
            var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine (documentsPath, "..", "Library");
            var path = Path.Combine (libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS ();
            var connection = new SQLite.Net.SQLiteConnection (platform, path);

            return connection;
        }

    }
}

