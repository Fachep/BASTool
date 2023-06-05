using BiligameAccountSwitchTool.Views;

namespace BiligameAccountSwitchTool
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxGame = new ComboBox();
            labelGameName = new Label();
            labelGameAccount = new Label();
            comboBoxAccount = new ComboBox();
            buttonChangeAccount = new Button();
            buttonManageAccount = new Button();
            buttonManageGame = new Button();
            buttonHelp = new Button();
            SuspendLayout();
            // 
            // comboBoxGame
            // 
            comboBoxGame.Location = new Point(62, 6);
            comboBoxGame.Name = "comboBoxGame";
            comboBoxGame.Size = new Size(121, 25);
            comboBoxGame.TabIndex = 0;
            comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
            // 
            // labelGameName
            // 
            labelGameName.AutoSize = true;
            labelGameName.Location = new Point(12, 9);
            labelGameName.Name = "labelGameName";
            labelGameName.Size = new Size(44, 17);
            labelGameName.TabIndex = 1;
            labelGameName.Text = "游戏：";
            // 
            // labelGameAccount
            // 
            labelGameAccount.AutoSize = true;
            labelGameAccount.Location = new Point(207, 9);
            labelGameAccount.Name = "labelGameAccount";
            labelGameAccount.Size = new Size(44, 17);
            labelGameAccount.TabIndex = 2;
            labelGameAccount.Text = "账号：";
            // 
            // comboBoxAccount
            // 
            comboBoxAccount.Location = new Point(257, 6);
            comboBoxAccount.Name = "comboBoxAccount";
            comboBoxAccount.Size = new Size(121, 25);
            comboBoxAccount.TabIndex = 3;
            // 
            // buttonChangeAccount
            // 
            buttonChangeAccount.Location = new Point(12, 85);
            buttonChangeAccount.Name = "buttonChangeAccount";
            buttonChangeAccount.Size = new Size(75, 23);
            buttonChangeAccount.TabIndex = 4;
            buttonChangeAccount.Text = "切换账号";
            buttonChangeAccount.UseVisualStyleBackColor = true;
            buttonChangeAccount.Click += buttonChangeAccount_Click;
            // 
            // buttonManageAccount
            // 
            buttonManageAccount.Location = new Point(207, 85);
            buttonManageAccount.Name = "buttonManageAccount";
            buttonManageAccount.Size = new Size(75, 23);
            buttonManageAccount.TabIndex = 5;
            buttonManageAccount.Text = "管理账号...";
            buttonManageAccount.UseVisualStyleBackColor = true;
            buttonManageAccount.Click += buttonManageAccount_Click;
            // 
            // buttonManageGame
            // 
            buttonManageGame.Location = new Point(108, 85);
            buttonManageGame.Name = "buttonManageGame";
            buttonManageGame.Size = new Size(75, 23);
            buttonManageGame.TabIndex = 6;
            buttonManageGame.Text = "管理游戏...";
            buttonManageGame.UseVisualStyleBackColor = true;
            buttonManageGame.Click += buttonManageGame_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.Location = new Point(303, 85);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(75, 23);
            buttonHelp.TabIndex = 7;
            buttonHelp.Text = "帮助...";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // MainWindow
            // 
            AcceptButton = buttonChangeAccount;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 120);
            Controls.Add(buttonHelp);
            Controls.Add(buttonManageGame);
            Controls.Add(buttonManageAccount);
            Controls.Add(buttonChangeAccount);
            Controls.Add(comboBoxAccount);
            Controls.Add(labelGameAccount);
            Controls.Add(labelGameName);
            Controls.Add(comboBoxGame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BASTool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxGame;
        private Label labelGameName;
        private Label labelGameAccount;
        private ComboBox comboBoxAccount;
        private Button buttonChangeAccount;
        private Button buttonManageAccount;
        private Button buttonManageGame;
        private Button buttonHelp;
    }
}