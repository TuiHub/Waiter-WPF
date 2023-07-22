namespace Commander.Pages
{
    partial class AppsManagePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppsManagePage));
            appsListView = new ListView();
            internalIdHeader = new ColumnHeader();
            typeHeader = new ColumnHeader();
            sourceHeader = new ColumnHeader();
            nameHeader = new ColumnHeader();
            shortDescptionHeader = new ColumnHeader();
            toolStrip = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            internalIdToolStripTextBox = new ToolStripTextBox();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripLabel4 = new ToolStripLabel();
            appTypeToolStripComboBox = new ToolStripComboBox();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripLabel5 = new ToolStripLabel();
            appSourceToolStripComboBox = new ToolStripComboBox();
            toolStripLabel6 = new ToolStripLabel();
            appNameToolStripTextBox = new ToolStripTextBox();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            pageNumToolStripTextBox = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            pageSizeToolStripTextBox = new ToolStripTextBox();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel7 = new ToolStripLabel();
            currentPageSizeToolStripTextBox = new ToolStripTextBox();
            toolStripLabel8 = new ToolStripLabel();
            toolStripSeparator5 = new ToolStripSeparator();
            loadToolStripButton = new ToolStripButton();
            toolStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // appsListView
            // 
            appsListView.Columns.AddRange(new ColumnHeader[] { internalIdHeader, typeHeader, sourceHeader, nameHeader, shortDescptionHeader });
            appsListView.Dock = DockStyle.Fill;
            appsListView.FullRowSelect = true;
            appsListView.Location = new Point(0, 50);
            appsListView.Name = "appsListView";
            appsListView.Size = new Size(1200, 625);
            appsListView.TabIndex = 0;
            appsListView.UseCompatibleStateImageBehavior = false;
            appsListView.View = View.Details;
            // 
            // internalIdHeader
            // 
            internalIdHeader.Text = "InternalID";
            internalIdHeader.Width = 150;
            // 
            // typeHeader
            // 
            typeHeader.Text = "类型";
            typeHeader.Width = 100;
            // 
            // sourceHeader
            // 
            sourceHeader.Text = "来源";
            sourceHeader.Width = 80;
            // 
            // nameHeader
            // 
            nameHeader.Text = "名称";
            nameHeader.Width = 120;
            // 
            // shortDescptionHeader
            // 
            shortDescptionHeader.Text = "简要描述";
            shortDescptionHeader.Width = 400;
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel3, internalIdToolStripTextBox, toolStripSeparator3, toolStripLabel4, appTypeToolStripComboBox, toolStripSeparator4, toolStripLabel5, appSourceToolStripComboBox, toolStripLabel6, appNameToolStripTextBox });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1200, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(77, 22);
            toolStripLabel3.Text = "InternalID：";
            // 
            // internalIdToolStripTextBox
            // 
            internalIdToolStripTextBox.Name = "internalIdToolStripTextBox";
            internalIdToolStripTextBox.Size = new Size(150, 25);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(44, 22);
            toolStripLabel4.Text = "类型：";
            // 
            // appTypeToolStripComboBox
            // 
            appTypeToolStripComboBox.Items.AddRange(new object[] { "Game", "Unspecified" });
            appTypeToolStripComboBox.Name = "appTypeToolStripComboBox";
            appTypeToolStripComboBox.Size = new Size(101, 25);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(44, 22);
            toolStripLabel5.Text = "来源：";
            // 
            // appSourceToolStripComboBox
            // 
            appSourceToolStripComboBox.Items.AddRange(new object[] { "Internal", "Steam", "vndb", "Unspecified" });
            appSourceToolStripComboBox.Name = "appSourceToolStripComboBox";
            appSourceToolStripComboBox.Size = new Size(81, 25);
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(44, 22);
            toolStripLabel6.Text = "名称：";
            // 
            // appNameToolStripTextBox
            // 
            appNameToolStripTextBox.Name = "appNameToolStripTextBox";
            appNameToolStripTextBox.Size = new Size(400, 25);
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, pageNumToolStripTextBox, toolStripSeparator1, toolStripLabel2, pageSizeToolStripTextBox, toolStripSeparator2, toolStripLabel7, currentPageSizeToolStripTextBox, toolStripLabel8, toolStripSeparator5, loadToolStripButton });
            toolStrip1.Location = new Point(0, 25);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1200, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(44, 22);
            toolStripLabel1.Text = "页数：";
            // 
            // pageNumToolStripTextBox
            // 
            pageNumToolStripTextBox.Name = "pageNumToolStripTextBox";
            pageNumToolStripTextBox.Size = new Size(50, 25);
            pageNumToolStripTextBox.Text = "1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(80, 22);
            toolStripLabel2.Text = "每页条目数：";
            // 
            // pageSizeToolStripTextBox
            // 
            pageSizeToolStripTextBox.Name = "pageSizeToolStripTextBox";
            pageSizeToolStripTextBox.Size = new Size(40, 25);
            pageSizeToolStripTextBox.Text = "50";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Size = new Size(56, 22);
            toolStripLabel7.Text = "当前页共";
            // 
            // currentPageSizeToolStripTextBox
            // 
            currentPageSizeToolStripTextBox.Name = "currentPageSizeToolStripTextBox";
            currentPageSizeToolStripTextBox.ReadOnly = true;
            currentPageSizeToolStripTextBox.Size = new Size(40, 25);
            currentPageSizeToolStripTextBox.Text = "0";
            // 
            // toolStripLabel8
            // 
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(32, 22);
            toolStripLabel8.Text = "条目";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            // 
            // loadToolStripButton
            // 
            loadToolStripButton.Image = (Image)resources.GetObject("loadToolStripButton.Image");
            loadToolStripButton.ImageTransparentColor = Color.Magenta;
            loadToolStripButton.Name = "loadToolStripButton";
            loadToolStripButton.Size = new Size(52, 22);
            loadToolStripButton.Text = "加载";
            loadToolStripButton.Click += loadToolStripButton_Click;
            // 
            // AppsManagePage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 675);
            ControlBox = false;
            Controls.Add(appsListView);
            Controls.Add(toolStrip1);
            Controls.Add(toolStrip);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AppsManagePage";
            Text = "AppsManagePage";
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView appsListView;
        private ColumnHeader internalIdHeader;
        private ColumnHeader nameHeader;
        private ColumnHeader typeHeader;
        private ColumnHeader sourceHeader;
        private ColumnHeader shortDescptionHeader;
        private ToolStrip toolStrip;
        private ToolStrip toolStrip1;
        private ToolStripButton loadToolStripButton;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox pageNumToolStripTextBox;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox pageSizeToolStripTextBox;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox internalIdToolStripTextBox;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel toolStripLabel4;
        private ToolStripComboBox appTypeToolStripComboBox;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel toolStripLabel5;
        private ToolStripComboBox appSourceToolStripComboBox;
        private ToolStripLabel toolStripLabel6;
        private ToolStripTextBox appNameToolStripTextBox;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel toolStripLabel7;
        private ToolStripTextBox currentPageSizeToolStripTextBox;
        private ToolStripLabel toolStripLabel8;
    }
}