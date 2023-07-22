using Grpc.Net.Client;
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
    public partial class SystemSettingsForm : Form
    {
        public SystemSettingsForm()
        {
            InitializeComponent();
        }

        private void SystemSettingsForm_Load(object sender, EventArgs e)
        {
            serverAddressTextBox.Text = GlobalContext.ServerAddress;
        }

        private void serverAddressSaveButton_Click(object sender, EventArgs e)
        {
            var serverAddress = serverAddressTextBox.Text;
            GlobalContext.ServerAddress = serverAddress;
            GlobalContext.GrpcChannel = GrpcChannel.ForAddress(serverAddress);
            Helpers.ConfigurationHelper.SetAppSetting("ServerAddress", serverAddress);
            MessageBox.Show(this, "保存成功");
            this.Close();
        }
    }
}
