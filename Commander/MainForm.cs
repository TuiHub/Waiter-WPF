using Commander.Forms;
using Commander.Pages;
using Grpc.Net.Client;
using TuiHub.Protos.Librarian.Sephirah.V1;

namespace Commander
{
    public partial class MainForm : Form
    {
        private Core.Services.LibrarianClientService _service = new Core.Services.LibrarianClientService();

        public MainForm()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var loginForm = new LoginForm();
            loginForm.ShowDialog(this);
        }

        private void systemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var systemSettingsForm = new SystemSettingsForm();
            systemSettingsForm.ShowDialog(this);
        }

        private void appManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appsManagePage = new AppsManagePage(this);
            foreach (var control in mainPanel.Controls)
            {
                (control as Form)?.Close();
            }
            mainPanel.Controls.Clear();
            appsManagePage.TopLevel = false;
            appsManagePage.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(appsManagePage);
            appsManagePage.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // init GlobalContext
            GlobalContext.ServerAddress = Helpers.ConfigurationHelper.GetAppSetting("ServerAddress") ?? "https://theam.example.com";
            GlobalContext.GrpcChannel = GrpcChannel.ForAddress(GlobalContext.ServerAddress);
            // init AccessToken, RefreshToken
            Core.GlobalContext.AccessToken = Helpers.ConfigurationHelper.GetAppSetting("AccessToken") ?? string.Empty;
            Core.GlobalContext.RefreshToken = Helpers.ConfigurationHelper.GetAppSetting("RefreshToken") ?? string.Empty;
        }

        private void appPackageManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appPackagesManagePage = new AppPackagesManagePage(this);
            foreach (var control in mainPanel.Controls)
            {
                (control as Form)?.Close();
            }
            mainPanel.Controls.Clear();
            appPackagesManagePage.TopLevel = false;
            appPackagesManagePage.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(appPackagesManagePage);
            appPackagesManagePage.Show();
        }
    }
}