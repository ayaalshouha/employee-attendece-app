using EAS_Buissness;
using Employees_Attendence_System.Global;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Employees_Attendence_System.Adminstration
{
    public partial class FrmAdminLogin : Form
    {
        private clsUser _User; 
        public FrmAdminLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUsername.Text))
            {
                txtNotes.Visible = true; 
                txtNotes.Text = "\tPlease enter your username/password.";
                return;
            }

            string HashedPassword = clsGlobal.ComputeHash(txtPassword.Text);
           
            _User = clsUser.Find(txtUsername.Text.Trim(), HashedPassword);

            if(_User == null)
            {
                txtNotes.Visible = true;

                txtNotes.Text = "\tInvalid username/password!";
                return; 
            }

            if (!_User.isActive)
            {
                txtNotes.Visible = true;

                txtNotes.Text = "\tUser is NOT active!";
                return;
            }

            clsGlobal.CurrentUser = _User;

            if (!chbRememberME.Checked)
            {
                txtPassword.Text = "";
                txtUsername.Text = "";
            }

            if (clsGlobal.SaveUsingRegistry(txtUsername.Text, txtPassword.Text))
            {
                this.Hide();
                FrmMainAdminScreen frmMainAdminScreen = new FrmMainAdminScreen(this);
                frmMainAdminScreen.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnLogin.PerformClick();
        }

        private void FrmAdminLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            string username = "", password = "";

            if (clsGlobal.getUsernamePasswordUsingRegistry(ref username, ref password))
            {
                txtUsername.Text = username;
                txtPassword.Text = password;
                chbRememberME.Checked = true;
            }
            else
                chbRememberME.Checked = false;
        }
    }
}
