namespace Commander.Forms
{
    partial class SystemSettingsForm
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
            label1 = new Label();
            serverAddressTextBox = new TextBox();
            serverAddressSaveButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(serverAddressTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(serverAddressSaveButton, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(600, 330);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(26, 16);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 0;
            label1.Text = "服务器地址";
            // 
            // serverAddressTextBox
            // 
            serverAddressTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            serverAddressTextBox.Location = new Point(123, 13);
            serverAddressTextBox.Name = "serverAddressTextBox";
            serverAddressTextBox.Size = new Size(294, 23);
            serverAddressTextBox.TabIndex = 1;
            // 
            // serverAddressSaveButton
            // 
            serverAddressSaveButton.Anchor = AnchorStyles.None;
            serverAddressSaveButton.Location = new Point(472, 13);
            serverAddressSaveButton.Name = "serverAddressSaveButton";
            serverAddressSaveButton.Size = new Size(75, 23);
            serverAddressSaveButton.TabIndex = 2;
            serverAddressSaveButton.Text = "保存";
            serverAddressSaveButton.UseVisualStyleBackColor = true;
            serverAddressSaveButton.Click += serverAddressSaveButton_Click;
            // 
            // SystemSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 330);
            Controls.Add(tableLayoutPanel1);
            Name = "SystemSettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "系统设置";
            Load += SystemSettingsForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox serverAddressTextBox;
        private Button serverAddressSaveButton;
    }
}