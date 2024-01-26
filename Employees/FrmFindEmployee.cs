using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_Attendence_System.Employees
{
    public partial class FrmFindEmployee : Form
    {
        private int EmployeeID = -1; 
        public FrmFindEmployee(int employeeID = -1)
        {
            InitializeComponent();
            EmployeeID = employeeID;
        }

        private void FrmFindEmployee_Load(object sender, EventArgs e)
        {
            if(EmployeeID != -1)
            {
                employeeInfoWithFilter1.LoadEmployeeInfo(EmployeeID);
                employeeInfoWithFilter1.FilterEnbled = false;
                lblHeader.Text = "Employee's Card"; 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeeInfoWithFilter1_onEmployeeSelected(object sender, UserControls.EmployeeInfoWithFilter.EmployeeSelectedEventArgs e)
        {
           
        }
    }
}
