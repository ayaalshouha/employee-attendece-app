using EAS_Buissness;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Employees_Attendence_System.Leave_Request
{
    public partial class FrmFollowupExistingRequest : Form
    {
        private clsLeaveRequest Request;
        private int RequestID = -1; 

        public FrmFollowupExistingRequest()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id))
            {
                RequestID = id;
            }

            Request = clsLeaveRequest.Find(RequestID);

            if (Request == null)
            {
                txtNOTES.Visible = true;
                txtNOTES.Text = $"ID {RequestID} NOT Found !!";
                return;
            }

            txtEmployeeName.Text = Request.EmployeInfo.PersonInfo.ShortName();
            txtLeaveReason.Text = Request.LeaveReason;
            dtpStartDate.Value = Request.FromDate; 
            dtpEndDate.Value = Request.ToDate;


            txtYesNo.Text = !Request.isClosed ? "Pending..." :
                Request.RequestStatusID == clsLeaveRequest.enRequestStatus.Completed ?
                Request.isAccepted ? "YES" : "NO" : "Cancelled";


            linkCancel.Enabled = (Request.RequestStatusID == clsLeaveRequest.enRequestStatus.New);

        }

        private void FrmFollowupExistingRequest_Load(object sender, EventArgs e)
        {
            txtID.Focus();
            linkCancel.Enabled = false;
            txtNOTES.Visible = false;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnSearch.PerformClick();

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void linkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(MessageBox.Show("are you sure you want to cancel the leave request?", "Message Box", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (Request.Cancel())
                {
                    txtNOTES.Visible = true;
                    txtNOTES.ForeColor = Color.DarkGreen; 
                    txtNOTES.Text = "Request cancelled successfully :-)";
                    return; 
                }

                txtNOTES.Visible = true;
                txtNOTES.ForeColor = Color.Red;
                txtNOTES.Text = "Something went wrong please try again! :-(";
            }

        }
    }
}

   

   
    //    private void btnSearch_Click(object sender, EventArgs e)
    //    {
    //       
    //    }

    //    private void btnSave_Click(object sender, EventArgs e)
    //    {
    //        if (Employee == null)
    //            return;

    //        DateTime start = dtpStartDate.Value;
    //        DateTime end = dtpEndDate.Value;
    //        Reason = (clsLeaveRequest.enLeaveRequest)cbLeaveTypes.SelectedIndex + 1;

    //        int requestID = Employee.NewLeaveRequest(start, end, (int)Reason);

    //        if (requestID != -1)
    //        {
    //            txtNOTES.Visible = true;
    //            txtNOTES.ForeColor = Color.DarkGreen;
    //            txtNOTES.Text = "Leave request completed successfully. :-)";
    //            btnSave.Enabled = false;
    //            return;
    //        }

    //        txtNOTES.Visible = true;
    //        txtNOTES.ForeColor = Color.Red;
    //        txtNOTES.Text = "Something went wrong, Try again later! :-(";
    //    }
            
    
    //    private void txtID_KeyPress(object sender, KeyPressEventArgs e)
    //    {
    //        
    //    }

    //    private void btnClose_Click(object sender, EventArgs e)
    //    {
         
    //    }
    //
