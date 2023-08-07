namespace Commander.Forms
{
    partial class AppPackageBinaryEditForm
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
            nameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            sizeBytesTextBox = new TextBox();
            urlTextBox = new TextBox();
            sha256TextBox = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.08F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.92F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 4);
            tableLayoutPanel1.Controls.Add(nameTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(sizeBytesTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(urlTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(sha256TextBox, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(600, 150);
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
            tableLayoutPanel3.Location = new Point(0, 120);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(600, 30);
            tableLayoutPanel3.TabIndex = 48;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Right;
            okButton.Location = new Point(152, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 4;
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
            closeButton.TabIndex = 6;
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
            cancelButton.TabIndex = 5;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameTextBox.Location = new Point(141, 3);
            nameTextBox.Margin = new Padding(3, 3, 30, 3);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(429, 23);
            nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Margin = new Padding(3, 0, 15, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 17);
            label1.TabIndex = 40;
            label1.Text = "名称";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 36);
            label2.Margin = new Padding(3, 0, 15, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 17);
            label2.TabIndex = 42;
            label2.Text = "大小（字节）";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 66);
            label4.Margin = new Padding(3, 0, 15, 0);
            label4.Name = "label4";
            label4.Size = new Size(120, 17);
            label4.TabIndex = 44;
            label4.Text = "URL";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(3, 96);
            label3.Margin = new Padding(3, 0, 15, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 17);
            label3.TabIndex = 43;
            label3.Text = "Sha256";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sizeBytesTextBox
            // 
            sizeBytesTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sizeBytesTextBox.Location = new Point(141, 33);
            sizeBytesTextBox.Margin = new Padding(3, 3, 30, 3);
            sizeBytesTextBox.Name = "sizeBytesTextBox";
            sizeBytesTextBox.Size = new Size(429, 23);
            sizeBytesTextBox.TabIndex = 1;
            // 
            // urlTextBox
            // 
            urlTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            urlTextBox.Location = new Point(141, 63);
            urlTextBox.Margin = new Padding(3, 3, 30, 3);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(429, 23);
            urlTextBox.TabIndex = 2;
            // 
            // sha256TextBox
            // 
            sha256TextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sha256TextBox.Location = new Point(141, 93);
            sha256TextBox.Margin = new Padding(3, 3, 30, 3);
            sha256TextBox.Name = "sha256TextBox";
            sha256TextBox.Size = new Size(429, 23);
            sha256TextBox.TabIndex = 3;
            // 
            // AppPackageBinaryEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 150);
            Controls.Add(tableLayoutPanel1);
            Name = "AppPackageBinaryEditForm";
            Text = "编辑AppPackageBinary";
            Load += AppPackageBinaryEditForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox nameTextBox;
        private Label label2;
        private Label label4;
        private Label label3;
        private TextBox sizeBytesTextBox;
        private TextBox urlTextBox;
        private TextBox sha256TextBox;
        private TableLayoutPanel tableLayoutPanel3;
        private Button okButton;
        private Button closeButton;
        private Button cancelButton;
    }
}