using System;
using BlankXamarinApp.Core;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using BlankXamarinApp.iOS;


[assembly: Dependency (typeof (SQLite_iOS))]
namespace BlankXamarinApp.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        public SQLiteConnection GetConnection ()
        {
            var fileName = "BlankXamarinApp.db3";
            var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine (documentsPath, "..", "Library");
            var path = Path.Combine (libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS ();
            var connection = new SQLite.Net.SQLiteConnection (platform, path);

            return connection;
        }

    }
}

