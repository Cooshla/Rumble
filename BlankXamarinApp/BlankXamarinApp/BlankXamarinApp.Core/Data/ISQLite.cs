using SQLite.Net;

namespace BlankXamarinApp.Core
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

