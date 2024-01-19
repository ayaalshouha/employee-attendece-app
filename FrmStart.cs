using Employees_Attendence_System.Adminstration;
using Employees_Attendence_System.Attendences;
using Employees_Attendence_System.Leave_Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_Attendence_System
{
    public partial class FrmStart : Form
    {
       
        public FrmStart()
        {
            InitializeComponent();
        }

        

        private void btnAttendences_Click(object sender, EventArgs e)
        {
            FrmCheckInOut frmCheckInOut = new FrmCheckInOut();
            frmCheckInOut.ShowDialog();
        }

        private void btnAdminstration_Click(object sender, EventArgs e)
        {
            FrmAdminLogin frmAdminLogin = new FrmAdminLogin();
            frmAdminLogin.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLeaveRequest frmLeaveRequest = new FrmLeaveRequest();
            frmLeaveRequest.ShowDialog();
        }
    }
}
