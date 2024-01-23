using EAS_Buissness;
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
    public partial class FrmUpdateUsername : Form
    {

        public delegate void DatabackEventHandler(object sender, string username);
        public event DatabackEventHandler Databack; 


        private clsUser User; 
        public FrmUpdateUsername(clsUser user)
        {
            InitializeComponent();
            this.User = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsUser.isExist(txtNewUsername.Text))
            {
                lblnotes.Visible = true; 
                lblnotes.Text = "username already exist! choose another one!";
                return; 
            }

            lblnotes.Visible = false;

            if(MessageBox.Show("Are you sure you want to change username ?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (User.ChangeUsername(txtNewUsername.Text.Trim()))
                {
                    MessageBox.Show("username changed successfully", "Message Box",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Databack?.Invoke(this, txtNewUsername.Text.Trim());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("something wrong happened please check again!", "Message Box",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            }
            else
                this.Close();
        }
    }
}
