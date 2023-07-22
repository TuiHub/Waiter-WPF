namespace Commander
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            systemSettingsToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem1 = new ToolStripMenuItem();
            loginToolStripMenuItem = new ToolStripMenuItem();
            manageToolStripMenuItem = new ToolStripMenuItem();
            appManageToolStripMenuItem = new ToolStripMenuItem();
            appPackageManageToolStripMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { systemSettingsToolStripMenuItem, accountToolStripMenuItem1, manageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // systemSettingsToolStripMenuItem
            // 
            systemSettingsToolStripMenuItem.Name = "systemSettingsToolStripMenuItem";
            systemSettingsToolStripMenuItem.Size = new Size(68, 21);
            systemSettingsToolStripMenuItem.Text = "系统设置";
            systemSettingsToolStripMenuItem.Click += systemSettingsToolStripMenuItem_Click;
            // 
            // accountToolStripMenuItem1
            // 
            accountToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { loginToolStripMenuItem });
            accountToolStripMenuItem1.Name = "accountToolStripMenuItem1";
            accountToolStripMenuItem1.Size = new Size(44, 21);
            accountToolStripMenuItem1.Text = "账号";
            // 
            // loginToolStripMenuItem
            // 
            loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            loginToolStripMenuItem.Size = new Size(100, 22);
            loginToolStripMenuItem.Text = "登录";
            loginToolStripMenuItem.Click += loginToolStripMenuItem_Click;
            // 
            // manageToolStripMenuItem
            // 
            manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { appManageToolStripMenuItem, appPackageManageToolStripMenuItem });
            manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            manageToolStripMenuItem.Size = new Size(44, 21);
            manageToolStripMenuItem.Text = "管理";
            // 
            // appManageToolStripMenuItem
            // 
            appManageToolStripMenuItem.Name = "appManageToolStripMenuItem";
            appManageToolStripMenuItem.Size = new Size(180, 22);
            appManageToolStripMenuItem.Text = "App管理";
            appManageToolStripMenuItem.Click += appManageToolStripMenuItem_Click;
            // 
            // appPackageManageToolStripMenuItem
            // 
            appPackageManageToolStripMenuItem.Name = "appPackageManageToolStripMenuItem";
            appPackageManageToolStripMenuItem.Size = new Size(180, 22);
            appPackageManageToolStripMenuItem.Text = "AppPackage管理";
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 25);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 425);
            mainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Commander";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem systemSettingsToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem1;
        private ToolStripMenuItem loginToolStripMenuItem;
        private ToolStripMenuItem manageToolStripMenuItem;
        private ToolStripMenuItem appManageToolStripMenuItem;
        private ToolStripMenuItem appPackageManageToolStripMenuItem;
        private Panel mainPanel;
    }
}