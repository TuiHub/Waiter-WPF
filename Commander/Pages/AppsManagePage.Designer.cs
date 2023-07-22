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
            appsListView = new ListView();
            internalIdHeader = new ColumnHeader();
            typeHeader = new ColumnHeader();
            sourceHeader = new ColumnHeader();
            nameHeader = new ColumnHeader();
            shortDescptionHeader = new ColumnHeader();
            toolStrip = new ToolStrip();
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
            appsListView.TabIndex = 0;
            appsListView.UseCompatibleStateImageBehavior = false;
            appsListView.View = View.Details;
            // 
            // internalIdHeader
            // 
            internalIdHeader.Text = "InternalID";
            internalIdHeader.Width = 100;
            // 
            // typeHeader
            // 
            typeHeader.Text = "类型";
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
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip";
            // 
            // AppsManagePage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(appsListView);
            Controls.Add(toolStrip);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AppsManagePage";
            Text = "AppsManagePage";
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
    }
}