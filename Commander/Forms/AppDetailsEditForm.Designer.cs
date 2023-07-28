namespace Commander.Forms
{
    partial class AppDetailsEditForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            okButton = new Button();
            closeButton = new Button();
            cancelButton = new Button();
            descrptionTextBox = new TextBox();
            versionTextBox = new TextBox();
            publisherTextBox = new TextBox();
            developerTextBox = new TextBox();
            label1 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            imageUrlsNumTextBox = new TextBox();
            imageUrlsEditButton = new Button();
            label14 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            releaseDateDateTimePicker = new DateTimePicker();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.08F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.92F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 6);
            tableLayoutPanel1.Controls.Add(descrptionTextBox, 1, 5);
            tableLayoutPanel1.Controls.Add(versionTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(publisherTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(developerTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(releaseDateDateTimePicker, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(600, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel3, 2);
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.46154F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.0769234F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.46154F));
            tableLayoutPanel3.Controls.Add(okButton, 0, 0);
            tableLayoutPanel3.Controls.Add(closeButton, 1, 0);
            tableLayoutPanel3.Controls.Add(cancelButton, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 420);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(600, 30);
            tableLayoutPanel3.TabIndex = 37;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Right;
            okButton.Location = new Point(152, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 6;
            okButton.Text = "确定";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.None;
            closeButton.Enabled = false;
            closeButton.Location = new Point(261, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 8;
            closeButton.Text = "关闭";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Visible = false;
            closeButton.Click += closeButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Left;
            cancelButton.Location = new Point(371, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // descrptionTextBox
            // 
            descrptionTextBox.Dock = DockStyle.Fill;
            descrptionTextBox.Location = new Point(141, 153);
            descrptionTextBox.Margin = new Padding(3, 3, 30, 3);
            descrptionTextBox.Multiline = true;
            descrptionTextBox.Name = "descrptionTextBox";
            descrptionTextBox.ScrollBars = ScrollBars.Both;
            descrptionTextBox.Size = new Size(429, 264);
            descrptionTextBox.TabIndex = 5;
            // 
            // versionTextBox
            // 
            versionTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            versionTextBox.Location = new Point(141, 63);
            versionTextBox.Margin = new Padding(3, 3, 30, 3);
            versionTextBox.Name = "versionTextBox";
            versionTextBox.Size = new Size(429, 23);
            versionTextBox.TabIndex = 2;
            // 
            // publisherTextBox
            // 
            publisherTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            publisherTextBox.Location = new Point(141, 33);
            publisherTextBox.Margin = new Padding(3, 3, 30, 3);
            publisherTextBox.Name = "publisherTextBox";
            publisherTextBox.Size = new Size(429, 23);
            publisherTextBox.TabIndex = 1;
            // 
            // developerTextBox
            // 
            developerTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            developerTextBox.Location = new Point(141, 3);
            developerTextBox.Margin = new Padding(3, 3, 30, 3);
            developerTextBox.Name = "developerTextBox";
            developerTextBox.Size = new Size(429, 23);
            developerTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Margin = new Padding(3, 0, 15, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 17);
            label1.TabIndex = 1;
            label1.Text = "开发商";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.Controls.Add(imageUrlsNumTextBox, 1, 0);
            tableLayoutPanel4.Controls.Add(imageUrlsEditButton, 2, 0);
            tableLayoutPanel4.Controls.Add(label14, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(138, 120);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(462, 30);
            tableLayoutPanel4.TabIndex = 26;
            // 
            // imageUrlsNumTextBox
            // 
            imageUrlsNumTextBox.Anchor = AnchorStyles.Left;
            imageUrlsNumTextBox.Location = new Point(53, 3);
            imageUrlsNumTextBox.Name = "imageUrlsNumTextBox";
            imageUrlsNumTextBox.ReadOnly = true;
            imageUrlsNumTextBox.Size = new Size(40, 23);
            imageUrlsNumTextBox.TabIndex = 1;
            imageUrlsNumTextBox.TabStop = false;
            imageUrlsNumTextBox.Text = "0";
            // 
            // imageUrlsEditButton
            // 
            imageUrlsEditButton.Anchor = AnchorStyles.Left;
            imageUrlsEditButton.Location = new Point(99, 3);
            imageUrlsEditButton.Name = "imageUrlsEditButton";
            imageUrlsEditButton.Size = new Size(50, 23);
            imageUrlsEditButton.TabIndex = 4;
            imageUrlsEditButton.Text = "编辑...";
            imageUrlsEditButton.UseVisualStyleBackColor = true;
            imageUrlsEditButton.Click += imageUrlsEditButton_Click;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Left;
            label14.AutoSize = true;
            label14.Location = new Point(3, 6);
            label14.Name = "label14";
            label14.Size = new Size(44, 17);
            label14.TabIndex = 0;
            label14.Text = "数量：";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 36);
            label2.Margin = new Padding(3, 0, 15, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 17);
            label2.TabIndex = 27;
            label2.Text = "发行商";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(3, 66);
            label3.Margin = new Padding(3, 0, 15, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 17);
            label3.TabIndex = 28;
            label3.Text = "版本";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 96);
            label4.Margin = new Padding(3, 0, 15, 0);
            label4.Name = "label4";
            label4.Size = new Size(120, 17);
            label4.TabIndex = 29;
            label4.Text = "发布时间";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(3, 126);
            label5.Margin = new Padding(3, 0, 15, 0);
            label5.Name = "label5";
            label5.Size = new Size(120, 17);
            label5.TabIndex = 30;
            label5.Text = "展示图片URL";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(3, 276);
            label6.Margin = new Padding(3, 0, 15, 0);
            label6.Name = "label6";
            label6.Size = new Size(120, 17);
            label6.TabIndex = 31;
            label6.Text = "描述";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // releaseDateDateTimePicker
            // 
            releaseDateDateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            releaseDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            releaseDateDateTimePicker.Location = new Point(141, 93);
            releaseDateDateTimePicker.Name = "releaseDateDateTimePicker";
            releaseDateDateTimePicker.Size = new Size(200, 23);
            releaseDateDateTimePicker.TabIndex = 3;
            releaseDateDateTimePicker.Value = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // AppDetailsEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "AppDetailsEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "编辑AppDetails";
            Load += AppDetailsEditForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox imageUrlsNumTextBox;
        private Button imageUrlsEditButton;
        private Label label14;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox versionTextBox;
        private TextBox publisherTextBox;
        private TextBox developerTextBox;
        private TextBox descrptionTextBox;
        private TableLayoutPanel tableLayoutPanel3;
        private Button okButton;
        private Button closeButton;
        private Button cancelButton;
        private DateTimePicker releaseDateDateTimePicker;
    }
}