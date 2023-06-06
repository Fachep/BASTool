namespace BASTool.Views
{
    partial class ManageGame
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
            labelGameName = new Label();
            labelGameId = new Label();
            textBoxGameName = new TextBox();
            listBoxGames = new ListBox();
            buttonUpdateGame = new Button();
            buttonDeleteGame = new Button();
            textBoxGameId = new TextBox();
            SuspendLayout();
            // 
            // labelGameName
            // 
            labelGameName.AutoSize = true;
            labelGameName.Location = new Point(12, 9);
            labelGameName.Name = "labelGameName";
            labelGameName.Size = new Size(56, 17);
            labelGameName.TabIndex = 0;
            labelGameName.Text = "游戏名：";
            // 
            // labelGameId
            // 
            labelGameId.AutoSize = true;
            labelGameId.Location = new Point(12, 35);
            labelGameId.Name = "labelGameId";
            labelGameId.Size = new Size(57, 17);
            labelGameId.TabIndex = 1;
            labelGameId.Text = "游戏ID：";
            // 
            // textBoxGameName
            // 
            textBoxGameName.Location = new Point(74, 6);
            textBoxGameName.Name = "textBoxGameName";
            textBoxGameName.Size = new Size(100, 23);
            textBoxGameName.TabIndex = 2;
            textBoxGameName.Validating += textBoxGameName_Validating;
            // 
            // listBoxGames
            // 
            listBoxGames.FormattingEnabled = true;
            listBoxGames.ItemHeight = 17;
            listBoxGames.Location = new Point(180, 6);
            listBoxGames.Name = "listBoxGames";
            listBoxGames.Size = new Size(192, 106);
            listBoxGames.TabIndex = 5;
            listBoxGames.SelectedIndexChanged += listBoxGames_SelectedIndexChanged;
            // 
            // buttonUpdateGame
            // 
            buttonUpdateGame.Enabled = false;
            buttonUpdateGame.Location = new Point(12, 87);
            buttonUpdateGame.Name = "buttonUpdateGame";
            buttonUpdateGame.Size = new Size(75, 23);
            buttonUpdateGame.TabIndex = 6;
            buttonUpdateGame.Text = "添加/更新";
            buttonUpdateGame.UseVisualStyleBackColor = true;
            buttonUpdateGame.Click += buttonUpdateGame_Click;
            // 
            // buttonDeleteGame
            // 
            buttonDeleteGame.Enabled = false;
            buttonDeleteGame.Location = new Point(99, 87);
            buttonDeleteGame.Name = "buttonDeleteGame";
            buttonDeleteGame.Size = new Size(75, 23);
            buttonDeleteGame.TabIndex = 7;
            buttonDeleteGame.Text = "删除";
            buttonDeleteGame.UseVisualStyleBackColor = true;
            buttonDeleteGame.Click += buttonDeleteGame_Click;
            // 
            // textBoxGameId
            // 
            textBoxGameId.Enabled = false;
            textBoxGameId.Location = new Point(74, 35);
            textBoxGameId.Name = "textBoxGameId";
            textBoxGameId.Size = new Size(100, 23);
            textBoxGameId.TabIndex = 8;
            // 
            // ManageGame
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 122);
            Controls.Add(textBoxGameId);
            Controls.Add(buttonDeleteGame);
            Controls.Add(buttonUpdateGame);
            Controls.Add(listBoxGames);
            Controls.Add(textBoxGameName);
            Controls.Add(labelGameId);
            Controls.Add(labelGameName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageGame";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "新建游戏";
            Load += ManageGame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelGameName;
        private Label labelGameId;
        private TextBox textBoxGameName;
        private ListBox listBoxGames;
        private Button buttonUpdateGame;
        private Button buttonDeleteGame;
        private TextBox textBoxGameId;
    }
}