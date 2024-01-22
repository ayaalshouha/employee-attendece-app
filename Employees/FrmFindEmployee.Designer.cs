namespace Employees_Attendence_System.Employees
{
    partial class FrmFindEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.employeeInfoWithFilter1 = new Employees_Attendence_System.UserControls.EmployeeInfoWithFilter();
            this.SuspendLayout();
            // 
            // employeeInfoWithFilter1
            // 
            this.employeeInfoWithFilter1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.employeeInfoWithFilter1.FilterEnbled = true;
            this.employeeInfoWithFilter1.Location = new System.Drawing.Point(8, 9);
            this.employeeInfoWithFilter1.Name = "employeeInfoWithFilter1";
            this.employeeInfoWithFilter1.Size = new System.Drawing.Size(844, 394);
            this.employeeInfoWithFilter1.TabIndex = 0;
            // 
            // FrmFindEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(861, 413);
            this.Controls.Add(this.employeeInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFindEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Details";
            this.Load += new System.EventHandler(this.FrmFindEmployee_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.EmployeeInfoWithFilter employeeInfoWithFilter1;
    }
}