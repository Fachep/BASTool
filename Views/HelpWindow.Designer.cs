namespace BiligameAccountSwitchTool.Views
{
    partial class HelpWindow
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
            linkLabelRepo = new LinkLabel();
            buttonOpenVBS = new Button();
            textBoxDescription = new TextBox();
            labelVersion = new Label();
            labelVersionValue = new Label();
            SuspendLayout();
            // 
            // linkLabelRepo
            // 
            linkLabelRepo.AutoSize = true;
            linkLabelRepo.Location = new Point(12, 9);
            linkLabelRepo.Name = "linkLabelRepo";
            linkLabelRepo.Size = new Size(0, 17);
            linkLabelRepo.TabIndex = 1;
            linkLabelRepo.LinkClicked += linkLabel1_LinkClicked;
            // 
            // buttonOpenVBS
            // 
            buttonOpenVBS.Location = new Point(337, 235);
            buttonOpenVBS.Name = "buttonOpenVBS";
            buttonOpenVBS.Size = new Size(75, 23);
            buttonOpenVBS.TabIndex = 2;
            buttonOpenVBS.Text = "打开脚本...";
            buttonOpenVBS.UseVisualStyleBackColor = true;
            buttonOpenVBS.Click += buttonOpenVBS_Click;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(12, 29);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.ScrollBars = ScrollBars.Vertical;
            textBoxDescription.Size = new Size(400, 200);
            textBoxDescription.TabIndex = 3;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(12, 244);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(44, 17);
            labelVersion.TabIndex = 4;
            labelVersion.Text = "版本：";
            // 
            // labelVersionValue
            // 
            labelVersionValue.AutoSize = true;
            labelVersionValue.Location = new Point(53, 244);
            labelVersionValue.Name = "labelVersionValue";
            labelVersionValue.Size = new Size(0, 17);
            labelVersionValue.TabIndex = 5;
            // 
            // HelpWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 270);
            Controls.Add(labelVersionValue);
            Controls.Add(labelVersion);
            Controls.Add(textBoxDescription);
            Controls.Add(buttonOpenVBS);
            Controls.Add(linkLabelRepo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HelpWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "帮助";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel linkLabelRepo;
        private Button buttonOpenVBS;
        private TextBox textBoxDescription;
        private Label labelVersion;
        private Label labelVersionValue;
    }
}