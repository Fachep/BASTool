namespace BiligameAccountSwitchTool.Views
{
    partial class ManageAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxNickName = new TextBox();
            labelNickName = new Label();
            labelUName = new Label();
            textBoxUName = new TextBox();
            buttonSaveAccount = new Button();
            buttonOpenSDK = new Button();
            buttonRefresh = new Button();
            listBoxAccounts = new ListBox();
            buttonDeleteAccount = new Button();
            buttonCancelDownload = new Button();
            SuspendLayout();
            // 
            // textBoxNickName
            // 
            textBoxNickName.Location = new Point(75, 6);
            textBoxNickName.Name = "textBoxNickName";
            textBoxNickName.Size = new Size(200, 23);
            textBoxNickName.TabIndex = 0;
            // 
            // labelNickName
            // 
            labelNickName.AutoSize = true;
            labelNickName.Location = new Point(25, 9);
            labelNickName.Name = "labelNickName";
            labelNickName.Size = new Size(44, 17);
            labelNickName.TabIndex = 1;
            labelNickName.Text = "昵称：";
            // 
            // labelUName
            // 
            labelUName.AutoSize = true;
            labelUName.Location = new Point(25, 46);
            labelUName.Name = "labelUName";
            labelUName.Size = new Size(44, 17);
            labelUName.TabIndex = 2;
            labelUName.Text = "账号：";
            // 
            // textBoxUName
            // 
            textBoxUName.Location = new Point(75, 43);
            textBoxUName.Name = "textBoxUName";
            textBoxUName.ReadOnly = true;
            textBoxUName.Size = new Size(200, 23);
            textBoxUName.TabIndex = 3;
            // 
            // buttonSaveAccount
            // 
            buttonSaveAccount.Location = new Point(25, 140);
            buttonSaveAccount.Name = "buttonSaveAccount";
            buttonSaveAccount.Size = new Size(100, 23);
            buttonSaveAccount.TabIndex = 4;
            buttonSaveAccount.Text = "添加/更新";
            buttonSaveAccount.UseVisualStyleBackColor = true;
            buttonSaveAccount.Click += buttonSaveAccount_Click;
            // 
            // buttonOpenSDK
            // 
            buttonOpenSDK.Location = new Point(25, 111);
            buttonOpenSDK.Name = "buttonOpenSDK";
            buttonOpenSDK.Size = new Size(100, 23);
            buttonOpenSDK.TabIndex = 5;
            buttonOpenSDK.Text = "打开登录窗口...";
            buttonOpenSDK.UseVisualStyleBackColor = true;
            buttonOpenSDK.Click += buttonOpenSDK_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(200, 111);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 6;
            buttonRefresh.Text = "读取";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // listBoxAccounts
            // 
            listBoxAccounts.ItemHeight = 17;
            listBoxAccounts.Location = new Point(300, 6);
            listBoxAccounts.Name = "listBoxAccounts";
            listBoxAccounts.Size = new Size(224, 157);
            listBoxAccounts.TabIndex = 7;
            listBoxAccounts.SelectedIndexChanged += listBoxAccounts_SelectedIndexChanged;
            // 
            // buttonDeleteAccount
            // 
            buttonDeleteAccount.Location = new Point(200, 140);
            buttonDeleteAccount.Name = "buttonDeleteAccount";
            buttonDeleteAccount.Size = new Size(75, 23);
            buttonDeleteAccount.TabIndex = 9;
            buttonDeleteAccount.Text = "删除";
            buttonDeleteAccount.UseVisualStyleBackColor = true;
            buttonDeleteAccount.Click += buttonDeleteAccount_Click;
            // 
            // buttonCancelDownload
            // 
            buttonCancelDownload.Location = new Point(25, 111);
            buttonCancelDownload.Name = "buttonCancelDownload";
            buttonCancelDownload.Size = new Size(100, 23);
            buttonCancelDownload.TabIndex = 10;
            buttonCancelDownload.Text = "取消下载";
            buttonCancelDownload.UseVisualStyleBackColor = true;
            buttonCancelDownload.Visible = false;
            buttonCancelDownload.Click += buttonCancelDownload_Click;
            // 
            // ManageAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 180);
            Controls.Add(buttonCancelDownload);
            Controls.Add(buttonDeleteAccount);
            Controls.Add(listBoxAccounts);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonOpenSDK);
            Controls.Add(buttonSaveAccount);
            Controls.Add(textBoxUName);
            Controls.Add(labelUName);
            Controls.Add(labelNickName);
            Controls.Add(textBoxNickName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageAccount";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "管理账号";
            Load += ManageAccount_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNickName;
        private Label labelNickName;
        private Label labelUName;
        private TextBox textBoxUName;
        private Button buttonSaveAccount;
        private Button buttonOpenSDK;
        private Button buttonRefresh;
        private ListBox listBoxAccounts;
        private Button buttonDeleteAccount;
        private Button buttonCancelDownload;
    }
}