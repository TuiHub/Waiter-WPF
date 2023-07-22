using Commander.Forms;
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
            var loginForm = new LoginForm();
            loginForm.ShowDialog(this);
        }

        private void systemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var systemSettingsForm = new SystemSettingsForm();
            systemSettingsForm.ShowDialog(this);
        }
    }
}