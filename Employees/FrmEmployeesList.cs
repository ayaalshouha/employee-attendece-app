using EAS_Buissness;
using Employees_Attendence_System.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Employees_Attendence_System.Adminstration.MainScreen_Forms
{
    public partial class FrmEmployeesList : Form
    {
        public FrmEmployeesList()
        {
            InitializeComponent();
        }

        private void _RefreshDatGridView()
        {
            dgvEmployeesList.DataSource = clsEmployee.EmployeesList();
            lblRecordNumber.Text = dgvEmployeesList.RowCount.ToString();
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
            DataGridViewButtonColumn PreviewBtnColumn = new DataGridViewButtonColumn();

            EditBtnCloumn.Name = "EditButtonColumn";
            DeleteBtnColumn.Name = "DeleteButtonColumn";
            PreviewBtnColumn.Name = "PreviewButtonColumn"; 


            EditBtnCloumn.HeaderText = "";
            DeleteBtnColumn.HeaderText = "";
            PreviewBtnColumn.HeaderText = "";

            PreviewBtnColumn.Text = "PREVIEW"; 
            EditBtnCloumn.Text = "EDIT";
            DeleteBtnColumn.Text = "DELETE";

            PreviewBtnColumn.Width = 60; 
            EditBtnCloumn.Width = 40;
            DeleteBtnColumn.Width = 53;

            DeleteBtnColumn.UseColumnTextForButtonValue = true;
            EditBtnCloumn.UseColumnTextForButtonValue = true;
            PreviewBtnColumn.UseColumnTextForButtonValue = true; 

            dgvEmployeesList.Columns.Add(EditBtnCloumn);
            dgvEmployeesList.Columns.Add(DeleteBtnColumn);
            dgvEmployeesList.Columns.Add(PreviewBtnColumn);
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
            {
                DataView View = OriginalList.DefaultView;
                View.RowFilter = $"{selectedColumnName}='{filter}'";
                dgvEmployeesList.DataSource = View;
            }
            else
            {
                DataView View = OriginalList.DefaultView;
                View.RowFilter = $"{selectedColumnName} LIKE '%{filter}%'";
                dgvEmployeesList.DataSource = View;
            }
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
            int EmployeeID = (int)dgvEmployeesList.CurrentRow.Cells[0].Value;
            int index = e.ColumnIndex;
            int EditIndex = dgvEmployeesList.Columns["EditButtonColumn"].Index;
            int DeleteIndex = dgvEmployeesList.Columns["DeleteButtonColumn"].Index;
            int PreviewIndex = dgvEmployeesList.Columns["PreviewButtonColumn"].Index;

            if (e.RowIndex >= 0 && index == EditIndex)
            {
               //Add/Edit form 
               FrmAddUpdateEmployee form = new FrmAddUpdateEmployee(EmployeeID);
                form.ShowDialog();
            }

            if (e.RowIndex >= 0 && index == DeleteIndex)
            {
                //deletion code
                if(MessageBox.Show($"are you sure you want to delete employee with EMP_CODE {EmployeeID} ??", "Message Box",
                    MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsEmployee.Delete(EmployeeID))
                        MessageBox.Show($"Employee details deleted successfully.", "Message Box",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Employee details are associated with another information in the system, can't be deleted!", "Message Box",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if(e.RowIndex >= 0 && index == PreviewIndex)
            {
                //preview form 
                FrmFindEmployee form = new FrmFindEmployee(EmployeeID);
                form.ShowDialog(); 
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmAddUpdateEmployee form = new FrmAddUpdateEmployee();
            form.ShowDialog();
        }
    }
}
