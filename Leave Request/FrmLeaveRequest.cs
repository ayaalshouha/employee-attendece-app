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
    public partial class FrmLeaveRequest : Form
    {
        public FrmLeaveRequest()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add form 
            pnlMainScreen.Controls.Clear();
            FrmAddNewRequst Form = new FrmAddNewRequst();
           Form.TopLevel = false;
           Form.Dock = DockStyle.Fill;
           pnlMainScreen.Controls.Add(Form);
           Form.Show();
        }

        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            pnlMainScreen.Controls.Clear();
            FrmFollowupExistingRequest Form = new FrmFollowupExistingRequest();
            Form.TopLevel = false;
            Form.Dock = DockStyle.Fill;
            pnlMainScreen.Controls.Add(Form);
            Form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
