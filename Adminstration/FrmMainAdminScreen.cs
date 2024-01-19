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
    }
}
