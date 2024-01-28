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

namespace Employees_Attendence_System.Employees
{
    public partial class FrmAddUpdateEmployee : Form
    {
        private enum enMode { add=1, update}
        private enMode _Mode = enMode.add;
        private clsEmployee _Employee;
        private clsPerson _Person;
        private int _PerosnID = -1;
        private int _EmployeeID = -1;

        public FrmAddUpdateEmployee(int EmployeeID = -1)
        {
            _EmployeeID = EmployeeID; 
            InitializeComponent();
            _Mode = _EmployeeID == -1 ? enMode.add : enMode.update;
        }
        

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dateTimeBirthdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pbDefaultPicture_Click(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThirdName_TextChanged(object sender, EventArgs e)
        {

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void LoadEmployeeInfo(clsEmployee employee)
        {
            if (employee != null)
            {
                lblID.Text = employee.PersonID.ToString(); 
                txtFirstName.Text = employee.PersonInfo.FirstName;
                txtSecondName.Text = employee.PersonInfo.SecondName;
                txtThirdName.Text = employee.PersonInfo.ThirdName;
                txtLastName.Text = employee.PersonInfo.LastName;

                txtEmail.Text = employee.PersonInfo.Email;
                txtPhone.Text = employee.PersonInfo.PhoneNumber;
                txtAddress.Text = employee.PersonInfo.Address; 


                if (employee.PersonInfo.Gender == "Male")
                    rdMale.Checked = true;
                else
                    rdFemale.Checked = true;

                dtpBirthdate.Text = employee.PersonInfo.BirthDate.ToShortDateString();


                cbDepartmentsOptions.SelectedItem = employee.DepartmentInfo.Name.ToString();
                cbCountries.SelectedItem = employee.PersonInfo.Nationality.ToString();

                lblEmploymentID.Text = employee.ID.ToString();
                dtpHireDate.Text = employee.WorkedFrom.ToString();

                if(employee.WorkedTo == null)
                    dtpLeaveDate.Enabled = false;
                else
                    dtpLeaveDate.Text = employee.WorkedTo.ToString();
            }
            else
                MessageBox.Show("Employee NOT Found", "Message Box", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetDefaultValues()
        {
            if (_Mode == enMode.add)
                rdMale.Checked = true;

            //set the max date to 18 years from now 
            dtpBirthdate.MaxDate = DateTime.Now.AddDays(-18);
            //should not allow adding age more than 100 years
            dtpBirthdate.MinDate = DateTime.Now.AddYears(-100);


            //load countries list
            DataTable countries = clsPerson.CountriesList();
            foreach (DataRow row in countries.Rows)
            {
                cbCountries.Items.Add(row["nicename"]);
            }

            //load departments list 
            DataTable departments = clsDepartment.DepartmentsList();
            foreach (DataRow row in departments.Rows)
            {
                cbDepartmentsOptions.Items.Add(row["Name"]);
            }
        }
        private void FrmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            SetDefaultValues();

            if (_Mode == enMode.add)
            {
                lblHeader.Text = "Add Employee";
                txtFirstName.Focus();
            }
            else
            {
                lblHeader.Text = "Update Employee";
                _Employee = clsEmployee.Find(_EmployeeID);
                LoadEmployeeInfo(_Employee); 
            }
        }
    }
}
