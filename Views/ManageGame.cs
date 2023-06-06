using BASTool.Models;
using BASTool.Services;
using System.ComponentModel;

namespace BASTool.Views
{
    public partial class ManageGame : Form
    {
        private readonly ObservableWrapper<BindingList<Game>> _games;
        private readonly ObservableWrapper<Game> _currentGame = new(Game.noneGame);
        private readonly BindingSource _bsGames;
        private readonly GameService _gameService = AppConfig.GetService<GameService>();

        private Game? selectedGame => (Game?)listBoxGames.SelectedItem;

        public ManageGame()
        {
            _games = new ObservableWrapper<BindingList<Game>>(new BindingList<Game>());
            _bsGames = new BindingSource(new BindingSource(_games, null), "Value");
            InitializeComponent();
            listBoxGames.DisplayMember = "Name";
            listBoxGames.DataSource = _bsGames;
            textBoxGameId.DataBindings.Add("Text", _currentGame, "Value.Id", false, DataSourceUpdateMode.Never);
            textBoxGameName.DataBindings.Add("Text", _currentGame, "Value.Name", false, DataSourceUpdateMode.Never);
        }

        private void ManageGame_Load(object sender, EventArgs e)
        {
            var gamesList = _gameService.CustomGamesList;
            gamesList.Add(Game.newGame);
            _games.Value = new BindingList<Game>(gamesList);
        }

        private void textBoxGameName_Validating(object sender, CancelEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            if (text == null || text == string.Empty)
            {
                buttonUpdateGame.Enabled = false;
            }
            else
            {
                buttonUpdateGame.Enabled = true;
            }
        }

        private void listBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedGame == null)
            {
                _currentGame.Value = Game.noneGame;
                buttonUpdateGame.Enabled = false;
                buttonDeleteGame.Enabled = false;
                textBoxGameId.Enabled = false;
            }
            else if (selectedGame == Game.newGame)
            {
                _currentGame.Value = Game.noneGame;
                buttonUpdateGame.Enabled = true;
                buttonDeleteGame.Enabled = false;
                textBoxGameId.Enabled = true;
            }
            else
            {
                _currentGame.Value = selectedGame;
                buttonUpdateGame.Enabled = true;
                buttonDeleteGame.Enabled = true;
                textBoxGameId.Enabled = false;
            }
        }

        private void buttonDeleteGame_Click(object sender, EventArgs e)
        {
            if (_currentGame.Value == Game.noneGame) return;
            var result = MessageBox.Show($"确定删除游戏 {selectedGame!.Name}？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                result = MessageBox.Show("是否保留账号数据？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                _gameService.RemoveGame(selectedGame, result == DialogResult.Yes);
                _games.Value.Remove(selectedGame);
                listBoxGames.SelectedIndex = -1;
            }
        }

        private void buttonUpdateGame_Click(object sender, EventArgs e)
        {
            if (selectedGame == null) return;
            if (textBoxGameName.Text == string.Empty)
            {
                textBoxGameName.Focus();
                return;
            }
            if (!uint.TryParse(textBoxGameId.Text, out _))
            {
                textBoxGameId.Focus();
                textBoxGameId.SelectAll();
                return;
            }
            if (selectedGame == Game.newGame)
            {
                var newGame = new Game { Id = int.Parse(textBoxGameId.Text), Name = textBoxGameName.Text };
                _gameService.AddGame(newGame);
                _games.Value.Insert(0, newGame);
                listBoxGames.SelectedIndex = 0;
            }
            else
            {
                _currentGame.Value.Name = textBoxGameName.Text;
                _gameService.UpdateGame(_currentGame.Value);
            }
        }
    }
}
