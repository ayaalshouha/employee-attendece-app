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

namespace Employees_Attendence_System.Adminstration.MainScreen_Forms
{
    public partial class FrmEmployeesList : Form
    {
        public FrmEmployeesList()
        {
            InitializeComponent();
        }

        private void FrmEmployeesList_Load(object sender, EventArgs e)
        {
            dgvEmployeesList.DataSource = clsEmployee.EmployeesList();
            lblRecordNumber.Text = dgvEmployeesList.RowCount.ToString();

            comboBox1.Items.Add("None");
            comboBox1.SelectedItem = "None";

            foreach (DataGridViewColumn column in dgvEmployeesList.Columns)
            {
                if (column.HeaderText == "HireDate" || column.HeaderText == "LeaveDate")
                {
                    continue;
                }
                comboBox1.Items.Add(column.HeaderText);
            }

            DataGridViewButtonColumn EditBtnCloumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn DeleteBtnColumn = new DataGridViewButtonColumn();

            EditBtnCloumn.Name = "EditButtonColumn";
            DeleteBtnColumn.Name = "DeleteButtonColumn"; 

            EditBtnCloumn.HeaderText = "";
            DeleteBtnColumn.HeaderText = ""; 

            EditBtnCloumn.Text = "EDIT";
            DeleteBtnColumn.Text = "DELETE"; 

            EditBtnCloumn.Width = 40;
            DeleteBtnColumn.Width = 53;

            DeleteBtnColumn.UseColumnTextForButtonValue = true;
            EditBtnCloumn.UseColumnTextForButtonValue = true;

            dgvEmployeesList.Columns.Add(EditBtnCloumn);
            dgvEmployeesList.Columns.Add(DeleteBtnColumn);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable OriginalList = clsEmployee.EmployeesList();
            string filter = textBox1.Text;
            string selectedColumnName = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(filter) || selectedColumnName == "None")
            {
                dgvEmployeesList.DataSource = OriginalList;
                return;
            }


            if (OriginalList.Columns[selectedColumnName].DataType == typeof(Int32))
                dgvEmployeesList.DataSource = OriginalList.DefaultView.RowFilter = $"{selectedColumnName}='{filter}'"; 
            else
                dgvEmployeesList.DataSource = OriginalList.DefaultView.RowFilter = $"{selectedColumnName} LIKE '%{filter}%'";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "None")
            {
                textBox1.Visible = true;
                textBox1.Focus();
            }
            else
            {
                textBox1.Visible = false;
                dgvEmployeesList.DataSource = clsEmployee.EmployeesList();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "EMP_Code" || comboBox1.Text == "BasicSalary")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvEmployeesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvEmployeesList.Columns["EditButtonColumn"].Index)
            {
               //edit form 
            }else if (e.RowIndex >= 0 && e.ColumnIndex == dgvEmployeesList.Columns["DeleteButtonColumn"].Index)
            {
                //delete employee action
            }
            else
                return; 
        }
    }
}
