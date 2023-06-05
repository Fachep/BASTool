using BiligameAccountSwitchTool.Models;
using Dapper;

namespace BiligameAccountSwitchTool.Services
{
    internal class GameService
    {
        private Dictionary<int, string> _gamesPreset = new();
        private Dictionary<int, string> _gamesCustom = new();
        private readonly DatabaseService _database;
        private readonly AccountService _accountService;

        public GameService(DatabaseService database, AccountService accountService)
        {
            _database = database;
            _accountService = accountService;
            foreach (GameIdEnum gid in Enum.GetValues(typeof(GameIdEnum)))
            {
                if (gid == GameIdEnum.New || gid == GameIdEnum.None) continue;
                _gamesPreset.Add((int)gid, gid.GetDescription());
            }
            foreach (Game game in _database.Con.Query<Game>("SELECT * FROM Game;"))
            {
                _gamesCustom.Add(game.Id, game.Name);
            }
        }

        public List<Game> AllGamesList => _gamesPreset.Concat(_gamesCustom).Select(e => new Game { Id = e.Key, Name = e.Value }).OrderBy(e => e.Id).ToList();
        public List<Game> CustomGamesList => _gamesCustom.Select(e => new Game { Id = e.Key, Name = e.Value }).OrderBy(e => e.Id).ToList();

        public bool AddGame(Game game)
        {
            if (game.Id == (int)GameIdEnum.New || game.Id == (int)GameIdEnum.None) return false;
            if (_gamesCustom.ContainsKey(game.Id)) return false;
            _database.Con.Query("INSERT INTO Game (Name, Id) VALUES (@Name, @Id);", game);
            _gamesCustom.Add(game.Id, game.Name);
            return true;
        }

        public bool UpdateGame(Game game)
        {
            if (game.Id == (int)GameIdEnum.New || game.Id == (int)GameIdEnum.None) return false;
            if (!_gamesCustom.ContainsKey(game.Id)) return false;
            _database.Con.Query("UPDATE Game SET Name = @Name WHERE Id = @Id;", game);
            _gamesCustom[game.Id] = game.Name;
            return true;
        }

        public bool RemoveGame(Game game, bool keepAccounts)
        {
            return RemoveGame(game.Id, keepAccounts);
        }

        public bool RemoveGame(int Id, bool keepAccounts)
        {
            if (Id == (int)GameIdEnum.New || Id == (int)GameIdEnum.None) return false;
            if (!_gamesCustom.ContainsKey(Id)) return false;
            _database.Con.Query("DELETE FROM Game WHERE Id = @Id;", new { Id });
            if (!keepAccounts) _accountService.RemoveAccountsByGameId(Id);
            return _gamesCustom.Remove(Id);
        }

    }
}
