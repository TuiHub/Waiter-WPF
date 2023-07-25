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
    public partial class StringCollectionEditForm : Form
    {
        public IEnumerable<string> Strings = Enumerable.Empty<string>();

        public StringCollectionEditForm()
        {
            InitializeComponent();
        }

        public StringCollectionEditForm(IEnumerable<string> strings)
        {
            Strings = strings;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var result = new List<string>();
            var strs = textBox.Text.Split('\n');
            foreach (var str in strs)
            {
                if (string.IsNullOrWhiteSpace(str) == false)
                {
                    result.Add(str);
                }
            }
            Strings = result;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void StringCollectionEditForm_Load(object sender, EventArgs e)
        {
            foreach (string str in Strings)
            {
                textBox.Text += str;
                textBox.Text += "\n";
            }
        }
    }
}
