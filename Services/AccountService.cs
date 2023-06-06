using BASTool.Helpers;
using BASTool.Models;
using Dapper;
using Microsoft.Win32;

namespace BASTool.Services
{
    internal class AccountService
    {
        private const string _url = "https://sdk.biligame.com/";
        private const string _getString =
            "(function(){{" +
                "return [localStorage[\"{0}-uname\"]," +
                "localStorage[\"{0}-token\"]," +
                "localStorage[\"{0}-lastLoginTime\"]].join(\"|\")" +
            "}})()";
        private const string _setString =
            "(function(){{" +
                "localStorage[\"{0}-uname\"]=\"{1}\";" +
                "localStorage[\"{0}-token\"]=\"{2}\";" +
            "}})()";
        private readonly DatabaseService _database;

        public AccountService(DatabaseService database)
        {
            _database = database;
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION")
                .SetValue(Path.GetFileName(Application.ExecutablePath), IEVersionHelper.lastOverrideEmulationMode, RegistryValueKind.DWord);
        }

        public void GetAccountFromIExplorer(int gameId, Action<GameAccount?> callback)
        {
            var webBrowser = new WebBrowser();
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler((s, e) =>
            {
                if (webBrowser.ReadyState != WebBrowserReadyState.Complete) return;
                var result = webBrowser.Document.InvokeScript("eval", new object[] { string.Format(_getString, gameId) })?.ToString();
                if (result == null || result.IndexOf("||") != -1)
                    callback(null);
                else
                    callback(new GameAccount(gameId, result.ToString()));
                webBrowser.Dispose();
            });
            webBrowser.Navigate(_url);
        }

        public void ApplyAccount(GameAccount account)
        {
            var webBrowser = new WebBrowser();
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler((s, e) =>
            {
                if (webBrowser.ReadyState != WebBrowserReadyState.Complete) return;
                var qs = string.Format(_setString, (int)account.GameId, account.UName, account.Token);
                var result = webBrowser.Document.InvokeScript("eval", new object[] { qs });
                webBrowser.Dispose();
            });
            webBrowser.Navigate(_url);
        }

        public List<GameAccount> GetAccountsFromDatabase(int gameId)
        {
            return _database.Con.Query<GameAccount>("SELECT * FROM Account WHERE GameId = @gameId;", new { gameId }).ToList();
        }

        public void UpdateAccount(GameAccount account)
        {
            _database.Con.Query("UPDATE Account SET Name = @Name, Token = @Token, Time = @Time WHERE UName = @UName AND GameId = @GameId;", account);
        }

        public void AddAccount(GameAccount account)
        {
            _database.Con.Query("INSERT INTO Account (Name, UName, Token, GameId, Time) VALUES (@Name, @UName, @Token, @GameId, @Time);", account);
        }

        public void RemoveAccount(GameAccount account)
        {
            _database.Con.Query("DELETE FROM Account WHERE UName = @UName AND GameId = @GameId;", account);
        }

        public void RemoveAccountsByGameId(int gameId)
        {
            _database.Con.Query("DELETE FROM Account WHERE GameId = @GameId;", new { gameId });
        }
    }
}
