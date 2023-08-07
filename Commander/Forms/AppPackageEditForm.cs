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
    public partial class AppPackageEditForm : Form
    {
        private Core.Models.AppPackageBinary _appPackageBinary = new();

        private readonly long _internalId;

        public AppPackageEditForm(long internalId)
        {
            _internalId = internalId;
            InitializeComponent();
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            var loadingForm = new LoadingForm();
            try
            {
                this.Enabled = false;
                loadingForm.Show(this);

                var appPackage = new Core.Models.AppPackage
                {
                    InternalId = _internalId,
                    Source = Helpers.ProtoEnumsHelper.StringToAppPackageSource(sourceComboBox.Text) ?? AppPackageSource.Unspecified,
                    SourceAppId = long.Parse(sourceIdTextBox.Text),
                    Name = nameTextBox.Text,
                    IsPublic = Helpers.ProtoEnumsHelper.StringToBool(isPublicComboBox.Text) ?? false,
                    Description = descrptionTextBox.Text,
                    AppPackageBinary = _appPackageBinary
                };

                var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                await GlobalContext.LibrarianClientService.UpdateAppPackageAsync(client, appPackage);

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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AppPackageEditForm_Load(object sender, EventArgs e)
        {
            var loadingForm = new LoadingForm();
            try
            {
                this.Enabled = false;
                loadingForm.Show(this);

                var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                var appPackage = (await GlobalContext.LibrarianClientService.ListAppPackagesAsync(client, 1, 1, null, _internalId, null)).First();

                internalIdTextBox.Text = appPackage.InternalId.ToString();
                sourceComboBox.Text = Helpers.ProtoEnumsHelper.AppPackageSourceToString(appPackage.Source);
                sourceIdTextBox.Text = appPackage.SourceAppId.ToString();
                nameTextBox.Text = appPackage.Name;
                _appPackageBinary = appPackage.AppPackageBinary ?? new Core.Models.AppPackageBinary();
                isPublicComboBox.Text = Helpers.ProtoEnumsHelper.BoolToString(appPackage.IsPublic);
                descrptionTextBox.Text = appPackage.Description;

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

        private void appBinaryEditButton_Click(object sender, EventArgs e)
        {
            var appPackageBinaryEditForm = new AppPackageBinaryEditForm(_appPackageBinary);
            appPackageBinaryEditForm.ShowDialog();
            if (appPackageBinaryEditForm.DialogResult == DialogResult.OK)
            {
                _appPackageBinary = appPackageBinaryEditForm.AppPackageBinary;
            }
        }
    }
}
