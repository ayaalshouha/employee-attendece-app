using EAS_Buissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_Attendence_System.UserControls
{
    public partial class EmployeeInfoWithFilter : UserControl
    {
        private clsEmployee Employee;
        private int? _EmployeeID = null;
        private bool _FilterEnabled = true;

        public bool FilterEnbled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public clsEmployee SelectedEmployee
        {
            get{ return Employee; } 
        }
        
        public int? EmployeeID
        {
            get { return _EmployeeID; }
        }

        public EmployeeInfoWithFilter()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            lblPersonID.Text = "[???]";
            lblName.Text = "[???]";
            lblDepartmentName.Text = "[???]";
            lblEmail.Text = "[???]";
            lblHireDate.Text =   "[???]";
            lblLeavingDate.Text = "[???]";
            lblPhonenumber.Text = "[???]";
            lblBirthdate.Text = "[???]";
            lblGender.Text = "[???]";
            lblCountry.Text = "[???]";
            lblEditInfo.Visible = false;
        }
        private void LoadEmployeeInfo(clsEmployee Employee)
        {
            if (Employee != null)
            {
                lblPersonID.Text = Employee.PersonInfo.ID.ToString();
                lblName.Text = Employee.PersonInfo.FullName();
                lblDepartmentName.Text = Employee.DepartmentInfo.Name.ToString();
                lblEmail.Text = Employee.PersonInfo.Email.ToString();
                lblHireDate.Text = Employee.WorkedFrom.ToShortDateString();

                //string workedTo;
                //workedTo = Employee.WorkedTo?.ToString();
                //lblLeavingDate.Text = workedTo ?? "Still working."; 

                //lblLeavingDate.Text = Employee.WorkedTo.ToString() ?? "Still Working."; 

                lblLeavingDate.Text = Employee.WorkedTo.HasValue ? Employee.WorkedTo.ToString() : "Still Working.";

                lblPhonenumber.Text = Employee.PersonInfo.PhoneNumber.ToString();
                lblBirthdate.Text = Employee.PersonInfo.BirthDate.ToShortDateString();
                lblGender.Text = Employee.PersonInfo.Gender.ToString();
                lblCountry.Text = Employee.PersonInfo.Nationality.ToString();

                lblEditInfo.Visible = true;
                lblEditInfo.Enabled = true;
                lblNotes.Visible = false;

            }
            
        }
        public void LoadEmployeeInfo(int EmployeeID)
        {
            _EmployeeID = EmployeeID; 
            Employee = clsEmployee.Find(_EmployeeID.Value);

            if (Employee != null)
                LoadEmployeeInfo(Employee);
            else
            {
                Clear();
                lblNotes.Visible = true; 
                lblNotes.Text = "NOT FOUND!";
            }

        }
       

        private void EmployeeInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                return;


            if (int.TryParse(txtInput.Text, out int result))
                _EmployeeID = result;
            else
                return;


            Employee = clsEmployee.Find(_EmployeeID.Value);

            if (Employee != null)
                LoadEmployeeInfo(Employee);
            else
            {
                Clear();
                lblNotes.Visible = true;
                lblNotes.Text = "NOT FOUND!";
            }

        }
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void lblEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //form add edit employee with update mode 
        }
    }
}
