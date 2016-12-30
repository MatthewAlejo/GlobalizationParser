using System;
using System.Windows.Forms;

namespace GlobalizationPointsOfInterest
{
    public partial class UserFilterForm : Form
    {
        public UserFilterForm()
        {
            InitializeComponent();
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            if (cboUserCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Select a Parsing Category!");
                return;
            }
            if (cboUserIncludeExclude.SelectedIndex < 0)
            {
                MessageBox.Show("Select a whether to include or exclude input filter!");
                return;
            }
            if (txtboxUserFilter.Text == string.Empty)
            {
                MessageBox.Show("Please Enter a filter to add");
                return;
            }
            if (!chkboxCS.Checked && !chkboxCSHTML.Checked && !chkboxJS.Checked)
            {
                MessageBox.Show("Please Select at least 1 compatible filetype!");
                return;
            }
            if (cboIsPattern.SelectedIndex < 0)
            {
                MessageBox.Show("Select whether this Filter is a pattern or a substring");
                return;
            }

            this.Close();
        }

        private void btnUserCancel_Click(object sender, EventArgs e)
        {
            txtboxUserFilter.Text = "";
            this.Close();
        }
    }
}
