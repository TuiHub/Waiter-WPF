namespace Commander.Forms
{
    partial class SearchAppsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchAppsForm));
            appsListView = new ListView();
            internalIdHeader = new ColumnHeader();
            typeHeader = new ColumnHeader();
            sourceHeader = new ColumnHeader();
            nameHeader = new ColumnHeader();
            shortDescptionHeader = new ColumnHeader();
            toolStrip2 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            keywordToolStripTextBox = new ToolStripTextBox();
            toolStripSeparator3 = new ToolStripSeparator();
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
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // appsListView
            // 
            appsListView.Columns.AddRange(new ColumnHeader[] { internalIdHeader, typeHeader, sourceHeader, nameHeader, shortDescptionHeader });
            appsListView.Dock = DockStyle.Fill;
            appsListView.FullRowSelect = true;
            appsListView.Location = new Point(0, 25);
            appsListView.Name = "appsListView";
            appsListView.Size = new Size(800, 425);
            appsListView.TabIndex = 1;
            appsListView.UseCompatibleStateImageBehavior = false;
            appsListView.View = View.Details;
            appsListView.DoubleClick += appsListView_DoubleClick;
            // 
            // internalIdHeader
            // 
            internalIdHeader.Text = "InternalID";
            internalIdHeader.Width = 150;
            // 
            // typeHeader
            // 
            typeHeader.Text = "类型";
            typeHeader.Width = 80;
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
            shortDescptionHeader.Width = 370;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel3, keywordToolStripTextBox, toolStripSeparator3, toolStripLabel1, pageNumToolStripTextBox, toolStripSeparator1, toolStripLabel2, pageSizeToolStripTextBox, toolStripSeparator2, toolStripLabel7, currentPageSizeToolStripTextBox, toolStripLabel8, toolStripSeparator5, loadToolStripButton });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(800, 25);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(56, 22);
            toolStripLabel3.Text = "关键词：";
            // 
            // keywordToolStripTextBox
            // 
            keywordToolStripTextBox.Name = "keywordToolStripTextBox";
            keywordToolStripTextBox.Size = new Size(150, 25);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
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
            // SearchAppsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(appsListView);
            Controls.Add(toolStrip2);
            Name = "SearchAppsForm";
            Text = "AppSearchForm";
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView appsListView;
        private ColumnHeader internalIdHeader;
        private ColumnHeader typeHeader;
        private ColumnHeader sourceHeader;
        private ColumnHeader nameHeader;
        private ColumnHeader shortDescptionHeader;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox keywordToolStripTextBox;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox pageNumToolStripTextBox;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox pageSizeToolStripTextBox;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel7;
        private ToolStripTextBox currentPageSizeToolStripTextBox;
        private ToolStripLabel toolStripLabel8;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton loadToolStripButton;
    }
}