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
            listView1 = new ListView();
            internalIdHeader = new ColumnHeader();
            nameHeader = new ColumnHeader();
            typeHeader = new ColumnHeader();
            sourceHeader = new ColumnHeader();
            shortDescptionHeader = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { internalIdHeader, typeHeader, sourceHeader, nameHeader, shortDescptionHeader });
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(800, 450);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // internalIdHeader
            // 
            internalIdHeader.Text = "InternalID";
            internalIdHeader.Width = 100;
            // 
            // nameHeader
            // 
            nameHeader.Text = "名称";
            nameHeader.Width = 120;
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
            // shortDescptionHeader
            // 
            shortDescptionHeader.Text = "简要描述";
            shortDescptionHeader.Width = 400;
            // 
            // AppsManagePage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AppsManagePage";
            Text = "AppsManagePage";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader internalIdHeader;
        private ColumnHeader nameHeader;
        private ColumnHeader typeHeader;
        private ColumnHeader sourceHeader;
        private ColumnHeader shortDescptionHeader;
    }
}