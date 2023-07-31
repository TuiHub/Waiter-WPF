namespace Commander.Forms
{
    partial class AppPackageEditForm
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
            appBinaryEditButton = new Button();
            nameTextBox = new TextBox();
            sourceIdTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            descrptionTextBox = new TextBox();
            internalIdTextBox = new TextBox();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            okButton = new Button();
            closeButton = new Button();
            cancelButton = new Button();
            sourceComboBox = new ComboBox();
            label4 = new Label();
            label6 = new Label();
            label5 = new Label();
            label7 = new Label();
            isPublicComboBox = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.08462F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.91538F));
            tableLayoutPanel1.Controls.Add(appBinaryEditButton, 1, 4);
            tableLayoutPanel1.Controls.Add(nameTextBox, 1, 3);
            tableLayoutPanel1.Controls.Add(sourceIdTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(descrptionTextBox, 1, 6);
            tableLayoutPanel1.Controls.Add(internalIdTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 7);
            tableLayoutPanel1.Controls.Add(sourceComboBox, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label6, 0, 4);
            tableLayoutPanel1.Controls.Add(label5, 0, 5);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(isPublicComboBox, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(600, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // appBinaryEditButton
            // 
            appBinaryEditButton.Anchor = AnchorStyles.Left;
            appBinaryEditButton.Location = new Point(141, 123);
            appBinaryEditButton.Name = "appBinaryEditButton";
            appBinaryEditButton.Size = new Size(50, 23);
            appBinaryEditButton.TabIndex = 4;
            appBinaryEditButton.Text = "编辑...";
            appBinaryEditButton.UseVisualStyleBackColor = true;
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameTextBox.Location = new Point(141, 93);
            nameTextBox.Margin = new Padding(3, 3, 30, 3);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(429, 23);
            nameTextBox.TabIndex = 3;
            // 
            // sourceIdTextBox
            // 
            sourceIdTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sourceIdTextBox.Location = new Point(141, 63);
            sourceIdTextBox.Margin = new Padding(3, 3, 30, 3);
            sourceIdTextBox.Name = "sourceIdTextBox";
            sourceIdTextBox.Size = new Size(429, 23);
            sourceIdTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(3, 66);
            label3.Margin = new Padding(3, 0, 15, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 17);
            label3.TabIndex = 44;
            label3.Text = "父App Internal ID";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 36);
            label2.Margin = new Padding(3, 0, 15, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 17);
            label2.TabIndex = 43;
            label2.Text = "来源";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // descrptionTextBox
            // 
            descrptionTextBox.Dock = DockStyle.Fill;
            descrptionTextBox.Location = new Point(141, 183);
            descrptionTextBox.Margin = new Padding(3, 3, 30, 3);
            descrptionTextBox.Multiline = true;
            descrptionTextBox.Name = "descrptionTextBox";
            descrptionTextBox.ScrollBars = ScrollBars.Both;
            descrptionTextBox.Size = new Size(429, 234);
            descrptionTextBox.TabIndex = 6;
            // 
            // internalIdTextBox
            // 
            internalIdTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            internalIdTextBox.Location = new Point(141, 3);
            internalIdTextBox.Margin = new Padding(3, 3, 30, 3);
            internalIdTextBox.Name = "internalIdTextBox";
            internalIdTextBox.Size = new Size(429, 23);
            internalIdTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Margin = new Padding(3, 0, 15, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 17);
            label1.TabIndex = 39;
            label1.Text = "Internal ID";
            label1.TextAlign = ContentAlignment.MiddleRight;
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
            tableLayoutPanel3.TabIndex = 38;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Right;
            okButton.Location = new Point(152, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 7;
            okButton.Text = "确定";
            okButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.None;
            closeButton.Enabled = false;
            closeButton.Location = new Point(261, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 9;
            closeButton.Text = "关闭";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Visible = false;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Left;
            cancelButton.Location = new Point(371, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // sourceComboBox
            // 
            sourceComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sourceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sourceComboBox.FormattingEnabled = true;
            sourceComboBox.Items.AddRange(new object[] { "Game", "Unspecified" });
            sourceComboBox.Location = new Point(141, 33);
            sourceComboBox.Margin = new Padding(3, 3, 30, 3);
            sourceComboBox.Name = "sourceComboBox";
            sourceComboBox.Size = new Size(429, 25);
            sourceComboBox.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 96);
            label4.Margin = new Padding(3, 0, 15, 0);
            label4.Name = "label4";
            label4.Size = new Size(120, 17);
            label4.TabIndex = 45;
            label4.Text = "名称";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(3, 126);
            label6.Margin = new Padding(3, 0, 15, 0);
            label6.Name = "label6";
            label6.Size = new Size(120, 17);
            label6.TabIndex = 47;
            label6.Text = "文件";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(3, 156);
            label5.Margin = new Padding(3, 0, 15, 0);
            label5.Name = "label5";
            label5.Size = new Size(120, 17);
            label5.TabIndex = 46;
            label5.Text = "是否公开";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(3, 291);
            label7.Margin = new Padding(3, 0, 15, 0);
            label7.Name = "label7";
            label7.Size = new Size(120, 17);
            label7.TabIndex = 48;
            label7.Text = "描述";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // isPublicComboBox
            // 
            isPublicComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            isPublicComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            isPublicComboBox.FormattingEnabled = true;
            isPublicComboBox.Items.AddRange(new object[] { "Game", "Unspecified" });
            isPublicComboBox.Location = new Point(141, 153);
            isPublicComboBox.Margin = new Padding(3, 3, 30, 3);
            isPublicComboBox.Name = "isPublicComboBox";
            isPublicComboBox.Size = new Size(429, 25);
            isPublicComboBox.TabIndex = 5;
            // 
            // AppPackageEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "AppPackageEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "编辑AppPackage";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Button okButton;
        private Button closeButton;
        private Button cancelButton;
        private Label label1;
        private TextBox internalIdTextBox;
        private ComboBox sourceComboBox;
        private TextBox nameTextBox;
        private TextBox sourceIdTextBox;
        private Label label3;
        private Label label2;
        private TextBox descrptionTextBox;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label7;
        private ComboBox isPublicComboBox;
        private Button appBinaryEditButton;
    }
}