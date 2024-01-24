using EAS_Buissness;
using Employees_Attendence_System.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_Attendence_System.Users
{
    public partial class FrmChangePassword : Form
    {
        private clsUser _User;
        private int UserID = -1; 
        public FrmChangePassword(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;  
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            userInformationWithFilter1.FilterEnbled = false; 
            userInformationWithFilter1.LoadUserInfo(UserID);
            txtCurrent.Focus();
        }

        private void txtCurrent_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrent.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrent, "This is required!");
            }
            else
                errorProvider1.SetError(txtCurrent, null);
        }

        private void txtNew_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNew.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNew, "This is required!");
            }
            else
                errorProvider1.SetError(txtNew, null);
        }

        private void txtCheck_Validating(object sender, CancelEventArgs e)
        {
            if (txtCheck.Text != txtNew.Text)
            {
                label1.Visible = true;
                label1.Text = "New password NOT matched!";
                return;
            }

            if (string.IsNullOrEmpty(txtCheck.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCheck, "This is required!");
            }
            else
                errorProvider1.SetError(txtCheck, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                label1.Visible = true;
                label1.Text = "Some feilds are NOT valid yet! check the error messages!";
                return;
            }

            //txtCurrent.Text = clsGlobal.ComputeHash(txtCurrent.Text);
            if (txtCurrent.Text != _User.password)
            {
                label1.Visible = true;
                label1.Text = "The current password you entered does NOT match our records.";
                return;
            }

            if (txtNew.Text != txtCheck.Text)
            {
                label1.Visible = true;
                label1.Text = "The new password you entered does NOT match the confirmation password.";
                return;
            }

            txtNew.Text = clsGlobal.ComputeHash(txtNew.Text);
            _User.password = txtNew.Text;

            if (_User.Save())
            {
                MessageBox.Show("Password updatted successfully.", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCurrent.Text = string.Empty;
                txtNew.Text = string.Empty;
                txtCheck.Text = string.Empty;
                label1.Visible = false;
                label1.Text = string.Empty;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userInformationWithFilter1_OnUserSelected(object sender, UserControls.UserInformationWithFilter.UserSelectedEventArgs e)
        {
            _User = e.SelectedUser; 
        }
    }
}
