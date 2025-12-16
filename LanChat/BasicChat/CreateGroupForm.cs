using System;
using System.Windows.Forms;

namespace BasicChat
{
    public partial class FormCreateGroup : Form
    {
        public string GroupName { get; private set; }

        public FormCreateGroup()
        {
            InitializeComponent();
        }

        private void lblCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroupName.Text))
            {
                MessageBox.Show("Ten nhom khong duoc de trong");
                return;
            }

            GroupName = txtGroupName.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void lblCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
