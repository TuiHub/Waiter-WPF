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
    public partial class AppDetailsEditForm : Form
    {
        private readonly DateTime _emptyDateTime = new DateTime(1753, 1, 1);

        public Core.Models.AppDetails AppDetails;

        private bool _isViewOnly;
        private IEnumerable<string> _imageUrls = Enumerable.Empty<string>();
        public AppDetailsEditForm(Core.Models.AppDetails appDetails, bool isViewOnly = false)
        {
            AppDetails = appDetails;
            _isViewOnly = isViewOnly;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            AppDetails = new Core.Models.AppDetails
            {
                Developer = string.IsNullOrWhiteSpace(developerTextBox.Text) ? null : developerTextBox.Text,
                Publisher = string.IsNullOrWhiteSpace(publisherTextBox.Text) ? null : publisherTextBox.Text,
                Version = string.IsNullOrWhiteSpace(versionTextBox.Text) ? null : versionTextBox.Text,
                ReleaseDate = releaseDateDateTimePicker.Value == _emptyDateTime ? null :
                                  releaseDateDateTimePicker.Value,
                ImageUrls = _imageUrls,
                Description = string.IsNullOrWhiteSpace(descrptionTextBox.Text) ? null : descrptionTextBox.Text
            };

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

        private void imageUrlsEditButton_Click(object sender, EventArgs e)
        {
            var stringCollectionEditForm = new StringCollectionEditForm(_imageUrls);
            var dialogResult = stringCollectionEditForm.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                _imageUrls = stringCollectionEditForm.Strings;
                imageUrlsNumTextBox.Text = stringCollectionEditForm.Strings.Count().ToString();
            }
        }

        private void AppDetailsEditForm_Load(object sender, EventArgs e)
        {
            if (_isViewOnly)
            {
                okButton.Enabled = false;
                okButton.Visible = false;
                cancelButton.Enabled = false;
                cancelButton.Visible = false;
                closeButton.Enabled = true;
                closeButton.Visible = true;
                this.Text = "查看AppDetails";
            }

            developerTextBox.Text = AppDetails.Developer ?? string.Empty;
            publisherTextBox.Text = AppDetails.Publisher ?? string.Empty;
            versionTextBox.Text = AppDetails.Version ?? string.Empty;
            releaseDateDateTimePicker.Value = AppDetails.ReleaseDate ?? _emptyDateTime;
            _imageUrls = AppDetails.ImageUrls;
            descrptionTextBox.Text = AppDetails.Description ?? string.Empty;
        }
    }
}
