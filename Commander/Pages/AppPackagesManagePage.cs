﻿using Commander.Forms;
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
    public partial class AppPackagesManagePage : Form
    {
        private Core.Models.App? _parentApp;

        public AppPackagesManagePage()
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

                var appPackageSource = ProtoEnumsHelper.StringToAppPackageSource(appPackageSourceToolStripComboBox.Text);
                long? internalId = string.IsNullOrEmpty(internalIdToolStripTextBox.Text) ? null :
                                     long.Parse(internalIdToolStripTextBox.Text);
                var parentAppInternalId = _parentApp?.InternalId;
                var pageNum = Int32.Parse(pageNumToolStripTextBox.Text);
                var pageSize = Int32.Parse(pageSizeToolStripTextBox.Text);

                loadingForm.label.Text = "正在连接服务器请求信息...";
                var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                var appPackages = await GlobalContext.LibrarianClientService.ListAppPackagesAsync(client, pageNum, pageSize, appPackageSource, internalId, parentAppInternalId);

                // https://blog.csdn.net/zxsean/article/details/51985021
                loadingForm.label.Text = "正在更新列表...";
                currentPageSizeToolStripTextBox.Text = appPackages.Count().ToString();
                appPackagesListView.Items.Clear();
                appPackagesListView.BeginUpdate();
                foreach (var appPackage in appPackages)
                {
                    ListViewItem item = new();
                    item.Text = appPackage.InternalId.ToString();
                    item.SubItems.Add(appPackage.SourceAppId.ToString());
                    item.SubItems.Add(ProtoEnumsHelper.AppPackageSourceToString(appPackage.Source));
                    item.SubItems.Add(appPackage.Name);
                    item.SubItems.Add(appPackage.Description);
                    appPackagesListView.Items.Add(item);
                }
                appPackagesListView.EndUpdate();

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

        private void searchAppsToolStripButton_Click(object sender, EventArgs e)
        {
            var searchAppsForm = new SearchAppsForm();
            searchAppsForm.ShowDialog(this);
            if (searchAppsForm.SelectedApp != null)
            {
                parentAppInternalIdToolStripTextBox.Text = searchAppsForm.SelectedApp.InternalId.ToString();
            }
        }
    }
}
