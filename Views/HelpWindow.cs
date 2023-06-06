using BASTool.Helpers;
using BASTool.Services;
using System.Diagnostics;

namespace BASTool.Views
{
    public partial class HelpWindow : Form
    {
        private readonly DatabaseService _databaseService = AppConfig.GetService<DatabaseService>();

        public HelpWindow()
        {
            InitializeComponent();
            labelVersionValue.Text = AppConfig.AppVersion?.ToString();
            textBoxDescription.Text = AppConfig.AppDescription;
            textBoxDescription.Text += $"""
                运行信息：
                    IE 版本 = {IEVersionHelper.Version}
                    数据库版本 = {_databaseService.UserVersion}
                    数据目录： {AppConfig.DataPath}
                打开脚本：
                    获取当前IE中存储的游戏ID列表

                """;
            linkLabelRepo.Text = "项目地址 提建议";
            linkLabelRepo.Links.Add(0, 4, AppConfig.RepoLink);
            linkLabelRepo.Links.Add(5, 3, AppConfig.RepoLink + "/issues");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link != null)
                Process.Start(new ProcessStartInfo((string)e.Link.LinkData) { UseShellExecute = true });
        }

        private void buttonOpenVBS_Click(object sender, EventArgs e)
        {
            try
            {
                var scriptPath = Path.Combine(AppConfig.DataPath, "GetGameId.vbs");
                if (!File.Exists(scriptPath))
                {
                    using var srcStream = GetType().Assembly.GetManifestResourceStream("BASTool.GetGameId.vbs")!;
                    int len = (int)srcStream.Length;
                    byte[] buffer = new byte[len];
                    srcStream.Read(buffer, 0, len);
                    File.WriteAllBytes(scriptPath, buffer);
                }
                Process.Start(new ProcessStartInfo("wscript", scriptPath) { UseShellExecute = true });
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
