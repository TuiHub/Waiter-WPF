using Commander.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuiHub.Protos.Librarian.Sephirah.V1;
using TuiHub.Protos.Librarian.V1;

namespace Commander.Forms
{
    public partial class SearchAppsForm : Form
    {
        public Core.Models.App? SelectedApp;

        private IEnumerable<Core.Models.App> _apps;

        public SearchAppsForm()
        {
            InitializeComponent();
        }

        private async void loadToolStripButton_Click(object sender, EventArgs e)
        {
            var loadingForm = new LoadingForm();
            try
            {
                this.Enabled = false;
                loadingForm.Show(this);

                var pageNum = Int32.Parse(pageNumToolStripTextBox.Text);
                var pageSize = Int32.Parse(pageSizeToolStripTextBox.Text);
                var keywork = keywordToolStripTextBox.Text;

                loadingForm.label.Text = "正在连接服务器请求信息...";
                var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                _apps = Enumerable.Empty<Core.Models.App>();
                _apps = await GlobalContext.LibrarianClientService.SearchAppsAsync(client, pageNum, pageSize, keywork);

                // https://blog.csdn.net/zxsean/article/details/51985021
                loadingForm.label.Text = "正在更新列表...";
                currentPageSizeToolStripTextBox.Text = _apps.Count().ToString();
                appsListView.Items.Clear();
                appsListView.BeginUpdate();
                foreach (var app in _apps)
                {
                    ListViewItem item = new();
                    item.Text = app.InternalId.ToString();
                    item.SubItems.Add(ProtoEnumsHelper.AppTypeToString(app.Type));
                    item.SubItems.Add(ProtoEnumsHelper.AppSourceToString(app.Source));
                    item.SubItems.Add(app.Name);
                    item.SubItems.Add(app.ShortDescription);
                    appsListView.Items.Add(item);
                }
                appsListView.EndUpdate();

                loadingForm.Close();
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                loadingForm.Close();
                this.Enabled = true;
                MessageBox.Show(this,
                                $"发生异常：{ex.Message}",
                                "运行时错误",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void appsListView_DoubleClick(object sender, EventArgs e)
        {
            if (appsListView.SelectedItems.Count > 0)
            {
                var item = appsListView.SelectedItems[0];
                SelectedApp = _apps.ToList()[item.Index];
                this.Close();
            }
        }
    }
}
