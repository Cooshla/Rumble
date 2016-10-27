using System;
using Akavache.Sqlite3;
using BlankXamarinApp.Core;

// Note: This class file is *required* for iOS to work correctly, and is 
// also a good idea for Android if you enable "Link All Assemblies".
namespace BlankXamarinApp.Droid
{
    [Preserve]
    public static class LinkerPreserve
    {
        static LinkerPreserve()
        {
            throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
        }
    }
}
