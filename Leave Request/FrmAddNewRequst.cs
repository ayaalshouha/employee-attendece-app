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

namespace Employees_Attendence_System.Leave_Request
{
    public partial class FrmAddNewRequst : Form
    {
        private clsEmployee Employee;
        private int EmployeeID = -1;
        private clsLeaveRequest.enLeaveRequest Reason;
        public string Notes
        {
            get
            {
                return this.txtNOTES.Text;
            }
            set
            {
                this.txtNOTES.Text = value;
            }
        }
        public FrmAddNewRequst()
        {
            InitializeComponent();
        }

        private void FrmAddNewRequst_Load(object sender, EventArgs e)
        {
            txtID.Focus();
            cbLeaveTypes.SelectedIndex = 0;
            btnSave.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtNOTES.Visible = true;
                txtNOTES.Text = $"\tEnter ID First!!";
                return;
            }

            if (int.TryParse(txtID.Text, out int id))
            {
                EmployeeID = id;
            }

            Employee = clsEmployee.Find(EmployeeID);

            if (Employee == null)
            {
                txtNOTES.Visible = true;
                txtNOTES.Text = $"\tID {EmployeeID} NOT Found !!";
                return;
            }

            btnSave.Enabled = true;
            txtEmployeeName.Text = Employee.PersonInfo.ShortName();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Employee == null)
                return;

            DateTime start = dtpStartDate.Value;
            DateTime end = dtpEndDate.Value;
            Reason = (clsLeaveRequest.enLeaveRequest)cbLeaveTypes.SelectedIndex + 1;

            int requestID = Employee.NewLeaveRequest(start, end, (int)Reason);

            if (requestID != -1)
            {
                txtNOTES.Visible = true;
                txtNOTES.ForeColor = Color.DarkGreen;
                txtNOTES.Text = $@"Leave request completed successfully. Follow up with ID {requestID} :-)";

                btnSave.Enabled = false;
                return;
            }

            txtNOTES.Visible = true;
            txtNOTES.ForeColor = Color.Red;
            txtNOTES.Text = "Something went wrong, Try again later! :-(";
        }
            
    
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnSearch.PerformClick();

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
         
        }
    }
}
