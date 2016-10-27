using SQLite.Net;

namespace RumbleApp.Core
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

