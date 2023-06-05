using Dapper;
using Microsoft.Data.Sqlite;

namespace BiligameAccountSwitchTool.Services
{
    internal class DatabaseService
    {
        private readonly SqliteConnection _con;
        public readonly int UserVersion;

        public SqliteConnection Con => _con;

        public DatabaseService(string databaseFolder)
        {
            var _databasePath = Path.Combine(databaseFolder, "data.db");
            _con = new SqliteConnection($"DataSource={_databasePath}");
            _con.Open();
            InitializeDatabase();
            UserVersion = _con.QueryFirstOrDefault<int>("PRAGMA USER_VERSION;");
        }

        ~DatabaseService()
        {
            _con.Close();
        }

        private void InitializeDatabase()
        {
            var version = _con.QueryFirstOrDefault<int>("PRAGMA USER_VERSION;");
            foreach (var sql in InitSqls.Skip(version))
            {
                _con.Execute(sql);
            }
        }

        private static List<string> InitSqls = new() { Sql_v1 };

        private const string Sql_v1 = """
            BEGIN TRANSACTION;

            CREATE TABLE IF NOT EXISTS Game
            (
                Name    TEXT    NOT NULL,
                Id      INTEGER NOT NULL PRIMARY KEY
            );

            CREATE TABLE IF NOT EXISTS Account
            (
                Name    TEXT    NOT NULL,
                UName   TEXT    NOT NULL,
                Token   TEXT    NOT NULL,
                GameId  INTGER  NOT NULL,
                Time    TEXT,
                PRIMARY KEY (UName, GameId)
            );
            CREATE INDEX IF NOT EXISTS IX_Account_GameId ON Account (GameId);

            PRAGMA USER_VERSION = 1;
            COMMIT TRANSACTION;
            """;
    }
}
