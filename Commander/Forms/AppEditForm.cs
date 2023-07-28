using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuiHub.Protos.Librarian.Sephirah.V1;
using TuiHub.Protos.Librarian.V1;

namespace Commander.Forms
{
    public enum AppEditFormType
    {
        Edit,
        Add
    }

    public partial class AppEditForm : Form
    {
        private IEnumerable<string> _tags = Enumerable.Empty<string>();
        private IEnumerable<string> _altNames = Enumerable.Empty<string>();
        private Core.Models.AppDetails _appDetails = new();

        private readonly bool _isViewOnly;
        private readonly long _internalId;
        private readonly AppEditFormType _appEditFormType;

        public AppEditForm(long internalId = -1, AppEditFormType appEditFormType = AppEditFormType.Edit, bool isViewOnly = false)
        {
            _appEditFormType = appEditFormType;
            _isViewOnly = isViewOnly;
            _internalId = internalId;
            InitializeComponent();
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            var app = new Core.Models.App
            {
                Source = Helpers.ProtoEnumsHelper.StringToAppSource(sourceComboBox.Text) ?? AppSource.Unspecified,
                SourceAppId = string.IsNullOrWhiteSpace(sourceIdTextBox.Text) ? null : sourceIdTextBox.Text,
                SourceUrl = string.IsNullOrWhiteSpace(sourceUrlTextBox.Text) ? null : sourceUrlTextBox.Text,
                Name = nameTextBox.Text,
                AltNames = _altNames,
                Type = Helpers.ProtoEnumsHelper.StringToAppType(typeComboBox.Text) ?? AppType.Unspecified,
                IconImageUrl = string.IsNullOrWhiteSpace(iconImageUrlTextBox.Text) ? null : iconImageUrlTextBox.Text,
                HeroImageUrl = string.IsNullOrWhiteSpace(heroImageUrlTextBox.Text) ? null : heroImageUrlTextBox.Text,
                Tags = _tags,
                AppDetails = _appDetails,
                ShortDescription = string.IsNullOrWhiteSpace(shortDescrptionTextBox.Text) ? null : shortDescrptionTextBox.Text,
            };
            if (_appEditFormType == AppEditFormType.Edit)
            {
                app.InternalId = _internalId;
                var loadingForm = new LoadingForm();
                try
                {
                    this.Enabled = false;
                    loadingForm.Show(this);

                    loadingForm.label.Text = "正在连接服务器修改信息...";
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    await GlobalContext.LibrarianClientService.UpdateAppAsync(client, app);

                    loadingForm.Close();
                    this.Enabled = true;
                    this.Close();
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
            else if (_appEditFormType == AppEditFormType.Add)
            {

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

        private void altNamesEditButton_Click(object sender, EventArgs e)
        {
            var stringCollectionEditForm = new StringCollectionEditForm(_altNames);
            var dialogResult = stringCollectionEditForm.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                _altNames = stringCollectionEditForm.Strings;
                altNamesNumTextBox.Text = stringCollectionEditForm.Strings.Count().ToString();
            }
        }

        private void tagsEditButton_Click(object sender, EventArgs e)
        {
            var stringCollectionEditForm = new StringCollectionEditForm(_tags);
            var dialogResult = stringCollectionEditForm.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                _tags = stringCollectionEditForm.Strings;
                tagsNumTextBox.Text = stringCollectionEditForm.Strings.Count().ToString();
            }
        }

        private void detailsEditButton_Click(object sender, EventArgs e)
        {
            var appDetailsEditForm = new AppDetailsEditForm(_appDetails, _isViewOnly);
            var dialogResult = appDetailsEditForm.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                _appDetails = appDetailsEditForm.AppDetails;
            }
        }

        private async void EditAppForm_Load(object sender, EventArgs e)
        {
            if (_isViewOnly)
            {
                okButton.Enabled = false;
                okButton.Visible = false;
                cancelButton.Enabled = false;
                cancelButton.Visible = false;
                closeButton.Enabled = true;
                closeButton.Visible = true;
                this.Text = "查看App";
            }

            var loadingForm = new LoadingForm();
            try
            {
                this.Enabled = false;
                loadingForm.Show(this);

                loadingForm.label.Text = "正在连接服务器请求信息...";
                var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                //var app = await GlobalContext.LibrarianClientService.GetAppAsync(client, _internalId);
                var app = (await GlobalContext.LibrarianClientService.ListAppsAsync(client, 1, 1, _internalId, null, null, null, true)).First();

                loadingForm.label.Text = "正在更新UI...";
                internalIdTextBox.Text = app.InternalId.ToString();
                sourceComboBox.Text = Helpers.ProtoEnumsHelper.AppSourceToString(app.Source);
                sourceIdTextBox.Text = app.SourceAppId;
                sourceUrlTextBox.Text = app.SourceUrl;
                nameTextBox.Text = app.Name;
                _altNames = app.AltNames;
                typeComboBox.Text = Helpers.ProtoEnumsHelper.AppTypeToString(app.Type);
                iconImageUrlTextBox.Text = app.IconImageUrl;
                heroImageUrlTextBox.Text = app.HeroImageUrl;
                _tags = app.Tags;
                _appDetails = app.AppDetails ?? new Core.Models.AppDetails();
                shortDescrptionTextBox.Text = app.ShortDescription;

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
    }
}
