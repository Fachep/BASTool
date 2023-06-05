using CommunityToolkit.Mvvm.ComponentModel;

namespace BiligameAccountSwitchTool.Models
{
    public class GameAccount : ObservableObject
    {
        private string _Name;
        private string _UName;
        private string _Token;
        private readonly static DateTime startTime = new(1970, 1, 1);
        private DateTime _Time = DateTime.Now;

        public int GameId { get; set; }
        public string Time
        {
            get => _Time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            set => _Time = DateTime.Parse(value);
        }

        public long Timestamp
        {
            get => (long)(_Time - startTime).TotalMilliseconds;
            set => _Time = startTime.AddMilliseconds(value);
        }

        public DateTime LastLoginTime
        {
            get => _Time;
            set => _Time = value;
        }

        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        public string UName
        {
            get => _UName;
            set => SetProperty(ref _UName, value);
        }

        public string Token
        {
            get => _Token;
            set => SetProperty(ref _Token, value);
        }

        private readonly static GameAccount _newAccount = new(GameIdEnum.New.GetDescription(), GameIdEnum.New);
        private readonly static GameAccount _noneAccount = new(string.Empty, GameIdEnum.None);

        public static GameAccount newAccount => _newAccount;
        public static GameAccount noneAccount => _noneAccount;

        private GameAccount(string Name, GameIdEnum GameId)
        {
            this.GameId = (int)GameId;
            SetProperty(ref _Name, Name);
            SetProperty(ref _UName, string.Empty);
            SetProperty(ref _Token, string.Empty);
        }

        public GameAccount(int gameId, string e)
        {
            GameId = gameId;
            var strs = e.Split('|');
            SetProperty(ref _Name, strs[0]);
            SetProperty(ref _UName, strs[0]);
            SetProperty(ref _Token, strs[1]);
            _Time = startTime.AddMilliseconds(double.Parse(strs[2]));
        }

        public GameAccount(string Name, string UName, string Token, long GameId, string Time)
        {
            SetProperty(ref _Name, Name);
            SetProperty(ref _UName, UName);
            SetProperty(ref _Token, Token);
            this.GameId = (int)GameId;
            _Time = DateTime.Parse(Time);
        }

        public GameAccount(string UName, string Token, int GameId)
        {
            SetProperty(ref _Name, UName);
            SetProperty(ref _UName, UName);
            SetProperty(ref _Token, Token);
            this.GameId = GameId;
        }

        public override string ToString()
        {
            return string.Join('|', new { _UName, _Token, Timestamp });
        }
    }
}
