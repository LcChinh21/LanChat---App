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

        private void btnCreate_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
