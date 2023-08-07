using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commander.Forms
{
    public partial class AppPackageBinaryEditForm : Form
    {
        public Core.Models.AppPackageBinary AppPackageBinary = new();

        public AppPackageBinaryEditForm(Core.Models.AppPackageBinary appPackageBinary)
        {
            AppPackageBinary = appPackageBinary;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            AppPackageBinary.Name = nameTextBox.Text;
            AppPackageBinary.SizeBytes = long.TryParse(sizeBytesTextBox.Text, out long sizeBytes) ? 0 : sizeBytes;
            AppPackageBinary.PublicUrl = urlTextBox.Text;
            AppPackageBinary.Sha256 = Convert.FromHexString(sha256TextBox.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AppPackageBinaryEditForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = AppPackageBinary.Name;
            sizeBytesTextBox.Text = AppPackageBinary.SizeBytes.ToString();
            urlTextBox.Text = AppPackageBinary.PublicUrl;
            sha256TextBox.Text = Convert.ToHexString(AppPackageBinary.Sha256 ?? new byte[32]);
        }
    }
}
