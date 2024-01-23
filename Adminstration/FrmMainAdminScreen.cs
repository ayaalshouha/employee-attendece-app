using Employees_Attendence_System.Employees;
using Employees_Attendence_System.Global;
using Employees_Attendence_System.Leave_Request;
using Employees_Attendence_System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_Attendence_System.Adminstration
{
    public partial class FrmMainAdminScreen : Form
    {
        private FrmAdminLogin _Login; 
        public FrmMainAdminScreen(FrmAdminLogin login)
        {
            _Login = login;
            InitializeComponent();
        }

        private void FrmMainAdminScreen_Load(object sender, EventArgs e)
        {
            lblWelcoming.Text = $"Hello [{clsGlobal.CurrentUser.username}]"; 
            DateNow.Text = DateTime.Now.ToShortDateString();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void employeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmFindEmployee Form = new FrmFindEmployee(); 
            //Form.ShowDialog();

            pnlMainScreen.Controls.Clear();
            lblSubHeader.Text = "Employee Details"; 
            FrmFindEmployee Form = new FrmFindEmployee();
            Form.TopLevel = false;
            Form.Dock = DockStyle.Fill;
            pnlMainScreen.Controls.Add(Form);
            Form.Show();
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMainScreen.Controls.Clear();
            lblSubHeader.Text = "Current user info";
            FrmUserInformation Form = new FrmUserInformation(clsGlobal.CurrentUser.ID);
            Form.TopLevel = false;
            Form.Dock = DockStyle.Fill;
            pnlMainScreen.Controls.Add(Form);
            Form.Show();
        }
    }
}
