using BASTool.Helpers;
using BASTool.Models;
using BASTool.Services;
using BASTool.Views;
using System.ComponentModel;

namespace BASTool
{
    public partial class MainWindow : Form
    {
        private readonly GameService _gameService = AppConfig.GetService<GameService>();
        private readonly AccountService _accountService = AppConfig.GetService<AccountService>();
        private readonly ObservableWrapper<BindingList<GameAccount>> _accounts = new(new());
        private readonly ObservableWrapper<BindingList<Game>> _games;
        private readonly BindingSource _bsGames;
        private readonly BindingSource _bsAccounts;

        private ManageAccount? manageAccountWindow;
        private ManageGame? manageGameWindow;
        private HelpWindow? helpWindow;

        public MainWindow()
        {
            _games = new ObservableWrapper<BindingList<Game>>(new BindingList<Game>(_gameService.AllGamesList));
            InitializeComponent();
            _bsGames = new BindingSource(new BindingSource(_games, null), "Value");
            _bsAccounts = new BindingSource(new BindingSource(_accounts, null), "Value");
            comboBoxGame.DisplayMember = "Name";
            comboBoxGame.DataSource = _bsGames;
            comboBoxAccount.DisplayMember = "Name";
            comboBoxAccount.DataSource = _bsAccounts;
            if (IEVersionHelper.Version < new Version(9, 0, 0, 0))
            {
                MessageBox.Show("Internet Explorer 版本过低，仅支持 IE 9 以上版本", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void buttonChangeAccount_Click(object sender, EventArgs e)
        {
            if (comboBoxAccount.SelectedValue == null) return;
            if (comboBoxGame.SelectedValue == null) return;
            _accountService.ApplyAccount((GameAccount)comboBoxAccount.SelectedValue);
        }

        private void buttonManageAccount_Click(object sender, EventArgs e)
        {
            if (comboBoxGame.SelectedValue == null) return;
            manageAccountWindow ??= new ManageAccount(comboBoxGame, _accounts);
            manageAccountWindow.ShowDialog();
            _accounts.Value.Remove(GameAccount.newAccount);
        }

        private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGame.SelectedValue == null) return;
            _accounts.Value = new BindingList<GameAccount>(_accountService.GetAccountsFromDatabase(((Game)comboBoxGame.SelectedValue).Id));
        }

        private void buttonManageGame_Click(object sender, EventArgs e)
        {
            manageGameWindow ??= new ManageGame();
            manageGameWindow.ShowDialog();
            _games.Value = new BindingList<Game>(_gameService.AllGamesList);
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            if (helpWindow?.IsDisposed != false) helpWindow = new HelpWindow();
            helpWindow.Show();
            helpWindow.Focus();
        }
    }
}