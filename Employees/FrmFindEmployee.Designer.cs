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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.employeeInfoWithFilter1 = new Employees_Attendence_System.UserControls.EmployeeInfoWithFilter();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(861, 85);
            this.pnlHeader.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::Employees_Attendence_System.Properties.Resources.arrow_left1;
            this.btnClose.Location = new System.Drawing.Point(3, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 74);
            this.btnClose.TabIndex = 15;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHeader.Location = new System.Drawing.Point(314, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(232, 44);
            this.lblHeader.TabIndex = 21;
            this.lblHeader.Text = "Find Employee";
            // 
            // employeeInfoWithFilter1
            // 
            this.employeeInfoWithFilter1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.employeeInfoWithFilter1.FilterEnbled = true;
            this.employeeInfoWithFilter1.Location = new System.Drawing.Point(8, 91);
            this.employeeInfoWithFilter1.Name = "employeeInfoWithFilter1";
            this.employeeInfoWithFilter1.Size = new System.Drawing.Size(844, 394);
            this.employeeInfoWithFilter1.TabIndex = 0;
            this.employeeInfoWithFilter1.onEmployeeSelected += new System.EventHandler<Employees_Attendence_System.UserControls.EmployeeInfoWithFilter.EmployeeSelectedEventArgs>(this.employeeInfoWithFilter1_onEmployeeSelected);
            // 
            // FrmFindEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(861, 505);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.employeeInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFindEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Details";
            this.Load += new System.EventHandler(this.FrmFindEmployee_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.EmployeeInfoWithFilter employeeInfoWithFilter1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeader;
    }
}