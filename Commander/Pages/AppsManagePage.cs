using Commander.Forms;
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

namespace Commander.Pages
{
    public partial class AppsManagePage : Form
    {
        private Form _parentForm;

        public AppsManagePage(Form parentForm)
        {
            _parentForm = parentForm;
            InitializeComponent();
        }

        private async void loadToolStripButton_Click(object sender, EventArgs e)
        {
            var loadingForm = new LoadingForm();
            try
            {
                this.Enabled = false;
                loadingForm.Show(_parentForm);

                var appType = ProtoEnumsHelper.StringToAppType(appTypeToolStripComboBox.Text);
                var appSource = ProtoEnumsHelper.StringToAppSource(appSourceToolStripComboBox.Text);
                long? internalId = string.IsNullOrEmpty(internalIdToolStripTextBox.Text) ? null :
                                     long.Parse(internalIdToolStripTextBox.Text);
                var appName = string.IsNullOrEmpty(appNameToolStripTextBox.Text) ? null :
                                  appNameToolStripTextBox.Text;
                var pageNum = Int32.Parse(pageNumToolStripTextBox.Text);
                var pageSize = Int32.Parse(pageSizeToolStripTextBox.Text);

                loadingForm.label.Text = "正在连接服务器请求信息...";
                var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                var apps = await GlobalContext.LibrarianClientService.ListAppsAsync(client, pageNum, pageSize, internalId, appType, appSource, appName);

                // https://blog.csdn.net/zxsean/article/details/51985021
                loadingForm.label.Text = "正在更新列表...";
                currentPageSizeToolStripTextBox.Text = apps.Count().ToString();
                appsListView.Items.Clear();
                appsListView.BeginUpdate();
                foreach (var app in apps)
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
            if (appsListView.SelectedItems.Count == 1)
            {
                var appInternalId = long.Parse(appsListView.SelectedItems[0].Text);
                var editAppForm = new AppEditForm(appInternalId);
                editAppForm.ShowDialog(_parentForm);
            }
        }
    }
}
