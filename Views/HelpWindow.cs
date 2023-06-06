using BASTool.Helpers;
using BASTool.Services;
using System.Diagnostics;

namespace BASTool.Views
{
    public partial class HelpWindow : Form
    {
        private readonly DatabaseService _databaseService = AppConfig.GetService<DatabaseService>();
        private const string vbs = """
            Function event_DocumentComplete(s, e)
                Set win = objIE.Document.parentWindow
                MsgBox win.eval("a=[];for(key in localStorage){r=/([0-9]+)-uname/.exec(key);if(r)a.push(r[1])};a.join()"),vbOKOnly,"(按Ctrl+C复制)"
                objIE.Quit
            End Function

            Set objIE = Wscript.CreateObject("InternetExplorer.Application","event_")
            objIE.Visible = True
            objIE.navigate "https://sdk.biligame.com/"
            Wscript.Sleep 5000
            """;

        public HelpWindow()
        {
            InitializeComponent();
            labelVersionValue.Text = AppConfig.AppVersion?.ToString();
            textBoxDescription.Text = AppConfig.AppDescription;
            textBoxDescription.Text += $"""
                运行信息：
                    IE 版本 = {IEVersionHelper.Version}
                    数据库版本 = {_databaseService.UserVersion}
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
            if (!File.Exists("GetGameId.vbs")) File.WriteAllText("GetGameId.vbs", vbs);
            Process.Start(new ProcessStartInfo("wscript", "GetGameId.vbs") { UseShellExecute = true });
        }
    }
}
