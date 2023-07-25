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
    public partial class EditAppForm : Form
    {
        private IEnumerable<string> _tags = Enumerable.Empty<string>();

        private readonly bool _isViewOnly;
        private readonly long _internalId;

        public EditAppForm(long internalId, bool isViewOnly = false)
        {
            _isViewOnly = isViewOnly;
            _internalId = internalId;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        }

        private void EditAppForm_Load(object sender, EventArgs e)
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
        }
    }
}
