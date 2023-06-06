using BASTool.Helpers;
using BASTool.Models;
using BASTool.Services;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Text.Json;

namespace BASTool.Views
{
    public partial class ManageAccount : Form
    {
        private readonly AccountService _accountService = AppConfig.GetService<AccountService>();
        private readonly ObservableWrapper<GameAccount> _currentAccount = new(GameAccount.noneAccount);
        private Game? _game;
        private BindingList<GameAccount>? _accounts;
        private readonly ComboBox _comboBoxGame;
        private readonly ObservableWrapper<BindingList<GameAccount>> _accountsWrapped;
        private BindingSource? _bsAccounts;
        private SDKHelper? _sdkHelper;
        private string? _appKey;

        public ManageAccount(ComboBox comboBoxGame, ObservableWrapper<BindingList<GameAccount>> accounts)
        {
            _comboBoxGame = comboBoxGame;
            _accountsWrapped = accounts;
            InitializeComponent();
            listBoxAccounts.DisplayMember = "Name";
            textBoxNickName.DataBindings.Add("Text", _currentAccount, "Value.Name", false, DataSourceUpdateMode.Never, string.Empty);
            textBoxUName.DataBindings.Add("Text", _currentAccount, "Value.UName", false, DataSourceUpdateMode.Never, string.Empty);
            SDKHelper.DownloadSDK.OnError += DownloadError;
            SDKHelper.DownloadSDK.OnComplete += DownloadComplete;
        }

        private void ManageAccount_Load(object sender, EventArgs e)
        {
            _sdkHelper = null;
            _game = (Game)_comboBoxGame.SelectedItem;
            _accounts = _accountsWrapped.Value;
            _accounts.Add(GameAccount.newAccount);
            _bsAccounts = new BindingSource(_accounts, null);

            Text = $"管理账号：{_game.Name}";
            listBoxAccounts.DataSource = _bsAccounts;
            _appKey = ConfigurationManager.AppSettings[_game.Id.ToString()];
            _ = _appKey == null ? buttonOpenSDK.Enabled = false : buttonOpenSDK.Enabled = true;
        }

        private GameAccount? selectedAccount => (GameAccount?)listBoxAccounts.SelectedItem;

        private void GetAccountCallback(GameAccount? account)
        {
            if (account == null) return;
            var found = _accounts!.Where(x => x.UName == account.UName)?.FirstOrDefault((GameAccount?)null);
            if (found != null)
            {
                var i = _accounts!.IndexOf(found);
                listBoxAccounts.SelectedIndex = i;
                found.Token = account.Token;
                found.LastLoginTime = account.LastLoginTime;
            }
            else if (selectedAccount == GameAccount.newAccount)
            {
                _currentAccount.Value = account;
                buttonSaveAccount.Enabled = true;
            }
            else
            {
                listBoxAccounts.SelectedIndex = _accounts!.IndexOf(GameAccount.newAccount);
                _currentAccount.Value = account;
                buttonSaveAccount.Enabled = true;
            }
        }

        private void RefreshAccount()
        {
            _accountService.GetAccountFromIExplorer(_game!.Id, GetAccountCallback);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshAccount();
        }

        private void buttonSaveAccount_Click(object sender, EventArgs e)
        {

            if (_currentAccount.Value == GameAccount.noneAccount) return;
            if (_currentAccount.Value == GameAccount.newAccount) return;
            if (selectedAccount == GameAccount.newAccount)
            {
                _currentAccount.Value.Name = textBoxNickName.Text;
                _accountService.AddAccount(_currentAccount.Value);
                _accounts!.Insert(0, _currentAccount.Value);
                listBoxAccounts.SelectedIndex = 0;
            }
            else
            {
                _currentAccount.Value.Name = textBoxNickName.Text;
                _accountService.UpdateAccount(_currentAccount.Value);
            }
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentAccount.Value = selectedAccount ?? GameAccount.noneAccount;
            if (selectedAccount == null)
            {
                buttonDeleteAccount.Enabled = false;
                buttonSaveAccount.Enabled = false;
            }
            else if (selectedAccount == GameAccount.newAccount)
            {
                buttonDeleteAccount.Enabled = false;
                buttonSaveAccount.Enabled = false;
            }
            else
            {
                buttonSaveAccount.Enabled = true;
                buttonDeleteAccount.Enabled = true;
            }
        }

        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            if (_currentAccount.Value == GameAccount.noneAccount) return;
            if (selectedAccount == GameAccount.newAccount) return;
            var result = MessageBox.Show($"确定删除账号 {_currentAccount.Value.UName}？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                _accountService.RemoveAccount(_currentAccount.Value);
                _accounts!.Remove(_currentAccount.Value);
                listBoxAccounts.SelectedIndex = -1;
            }
        }

        private void LoginCallback(string buf, int _)
        {
            try
            {
                using var jsonDoc = JsonDocument.Parse(buf);
                var rootEle = jsonDoc.RootElement;
                var dataEle = rootEle.GetProperty("data");
                if (rootEle.GetProperty("code").GetInt32() == 0) RefreshAccount();
            }
            catch { }
        }

        private void buttonOpenSDK_Click(object sender, EventArgs e)
        {
            if (_appKey == null)
            {
                buttonOpenSDK.Enabled = false;
                return;
            }
            _sdkHelper ??= new SDKHelper(Handle, _game!.Id, _appKey);
            try
            {
                if (!_sdkHelper.Loaded) _sdkHelper.Load();
                _sdkHelper.ShowPanel(LoginCallback);
            }
            catch (FileNotFoundException)
            {
                var result = MessageBox.Show("找不到SDK文件，是否下载？", "继续", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    buttonOpenSDK.Visible = false;
                    buttonCancelDownload.Visible = true;
                    SDKHelper.DownloadSDK.Start();
                }
            }
        }

        private void buttonCancelDownload_Click(object sender, EventArgs e)
        {
            SDKHelper.DownloadSDK.Stop();
            buttonCancelDownload.Visible = false;
            buttonOpenSDK.Visible = true;
        }

        private void DownloadComplete()
        {
            Invoke(() =>
            {
                buttonCancelDownload.Visible = false;
                buttonOpenSDK.Visible = true;
            });
        }

        private void DownloadError(string message)
        {
            MessageBox.Show($"下载错误：{message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Invoke(() =>
            {
                buttonCancelDownload.Visible = false;
                buttonOpenSDK.Visible = true;
            });
        }
    }
}
