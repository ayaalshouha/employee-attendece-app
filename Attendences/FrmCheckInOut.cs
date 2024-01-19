using EAS_Buissness;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Employees_Attendence_System.Attendences
{
    public partial class FrmCheckInOut : Form
    {
        private clsEmployee CurrentEmployee;
        private int EmployeeID = -1;
        private string BasicText = "Enter your employement ID...";

        public FrmCheckInOut()
        {
            InitializeComponent();
        }
      
        private void FrmCheckInOut_Load(object sender, EventArgs e)
        {

            txtEmployeeID.Focus();


            if(DateTime.Now.Hour < 12)
                lblWelcoming.Text = "Good Morning :-)";
            else
                lblWelcoming.Text = "Good Afternoon :-)";
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == BasicText)
            {
                txtNotes.Text = "Please enter your ID first!";
                return;
            }


            if(int.TryParse(txtEmployeeID.Text, out int ID))
                EmployeeID = ID;


            CurrentEmployee = clsEmployee.Find(EmployeeID);

            if (CurrentEmployee == null)
            {
                txtNotes.Text = $"ID {EmployeeID} is NOT Found!";
                return;
            }

            if (CurrentEmployee.DoesCheckedInToday())
            {
                btnCheckIn.Enabled = false; 
                txtNotes.ForeColor=Color.Red;
                txtNotes.Text = $"\tYou already checked in today {CurrentEmployee.PersonInfo.FirstName}!";
                return; 
            }

            if (CurrentEmployee.CheckIn())
            {
                txtNotes.ForeColor = Color.DarkGreen; 
                txtNotes.Text = $" Checked in successfully {CurrentEmployee.PersonInfo.FirstName}, Have a joyful day! :-)";
                btnCheckIn.Enabled = false;
                txtEmployeeID.Text = BasicText;
                return;
            }

            txtNotes.ForeColor = Color.Red;
            txtNotes.Text = "\tOps!Something went wrong, Please try again! :-(";
        }

        private void txtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnCheckIn.PerformClick();


            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if(txtEmployeeID.Text == BasicText)
                txtEmployeeID.ForeColor = Color.Silver;
            else
                 txtEmployeeID.ForeColor = Color.Red; 

        }

        private void txtEmployeeID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                txtEmployeeID.ForeColor = Color.Silver;
                txtEmployeeID.Text = BasicText;
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == BasicText)
            {
                txtNotes.Text = "\tPlease enter your ID first!";
                return;
            }

            if (int.TryParse(txtEmployeeID.Text, out int ID))
                EmployeeID = ID;

            CurrentEmployee = clsEmployee.Find(EmployeeID);

            if (CurrentEmployee == null)
            {
                txtNotes.Text = $"\tID {EmployeeID} is NOT Found!";
                return;
            }

            if (CurrentEmployee.DoesCheckedOutToday())
            {
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
                txtNotes.ForeColor = Color.Red;
                txtNotes.Text = $"You already checked out today {CurrentEmployee.PersonInfo.FirstName}!, See you in the morning :-)";
                return;
            }

            if (CurrentEmployee.CheckOut())
            {
                txtNotes.ForeColor = Color.DarkGreen;
                txtNotes.Text = $"Checked out successfully {CurrentEmployee.PersonInfo.FirstName}, See you in the morning! :-)";
                btnCheckOut.Enabled = false;
            }
        }

        private void txtEmployeeID_Enter(object sender, EventArgs e)
        {
            txtEmployeeID.Text = "";
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            btnCheckOut.Enabled = true;
            btnCheckIn.Enabled = true;
            txtNotes.ForeColor = Color.Red;
            txtEmployeeID.Text= BasicText;
            txtNotes.Text = "any further messages will be appear here :-)";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
