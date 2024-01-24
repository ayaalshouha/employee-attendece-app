namespace Employees_Attendence_System.Adminstration
{
    partial class FrmMainAdminScreen
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
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.DateNow = new System.Windows.Forms.Label();
            this.lblWelcoming = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeOvertimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.attendenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendenceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.leaveManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approvedLeavesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.currentUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.attendencesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overtimeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMainScreen = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblSubHeader);
            this.pnlHeader.Controls.Add(this.DateNow);
            this.pnlHeader.Controls.Add(this.lblWelcoming);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 33);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1004, 85);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.Font = new System.Drawing.Font("Sakkal Majalla", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSubHeader.Location = new System.Drawing.Point(462, 55);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(80, 25);
            this.lblSubHeader.TabIndex = 24;
            this.lblSubHeader.Text = "SubHeader";
            // 
            // DateNow
            // 
            this.DateNow.AutoSize = true;
            this.DateNow.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateNow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DateNow.Location = new System.Drawing.Point(867, 47);
            this.DateNow.Name = "DateNow";
            this.DateNow.Size = new System.Drawing.Size(110, 19);
            this.DateNow.TabIndex = 23;
            this.DateNow.Text = "DateTime.Now";
            // 
            // lblWelcoming
            // 
            this.lblWelcoming.AutoSize = true;
            this.lblWelcoming.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcoming.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWelcoming.Location = new System.Drawing.Point(847, 20);
            this.lblWelcoming.Name = "lblWelcoming";
            this.lblWelcoming.Size = new System.Drawing.Size(130, 19);
            this.lblWelcoming.TabIndex = 22;
            this.lblWelcoming.Text = "Hello [username]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(393, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 49);
            this.label1.TabIndex = 21;
            this.label1.Text = "Main Screen";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnCompany);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 624);
            this.panel1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Sitka Subheading", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = global::Employees_Attendence_System.Properties.Resources.allow_list;
            this.button2.Location = new System.Drawing.Point(-11, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 98);
            this.button2.TabIndex = 15;
            this.button2.Text = "Attendences";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnCompany
            // 
            this.btnCompany.FlatAppearance.BorderSize = 0;
            this.btnCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompany.Font = new System.Drawing.Font("Sitka Subheading", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompany.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCompany.Image = global::Employees_Attendence_System.Properties.Resources.company2;
            this.btnCompany.Location = new System.Drawing.Point(1, 6);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(107, 83);
            this.btnCompany.TabIndex = 16;
            this.btnCompany.Text = "Company";
            this.btnCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCompany.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Sitka Subheading", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Image = global::Employees_Attendence_System.Properties.Resources.group__3_;
            this.button4.Location = new System.Drawing.Point(1, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 83);
            this.button4.TabIndex = 17;
            this.button4.Text = "Employees";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Sitka Subheading", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::Employees_Attendence_System.Properties.Resources.overtime_rate;
            this.button1.Location = new System.Drawing.Point(1, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 83);
            this.button1.TabIndex = 14;
            this.button1.Text = "Overtime";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Sitka Subheading", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNew.Image = global::Employees_Attendence_System.Properties.Resources.status_away;
            this.btnNew.Location = new System.Drawing.Point(1, 184);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(107, 83);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "Leave ";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.companyToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.currentUserToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.companyToolStripMenuItem.Text = "Company";
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeDetailsToolStripMenuItem,
            this.employeeOvertimeToolStripMenuItem,
            this.employeesListToolStripMenuItem,
            this.toolStripMenuItem1,
            this.attendenceToolStripMenuItem,
            this.attendenceListToolStripMenuItem,
            this.toolStripMenuItem2,
            this.leaveManagmentToolStripMenuItem,
            this.approvedLeavesListToolStripMenuItem,
            this.toolStripMenuItem3});
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.employeesToolStripMenuItem.Text = "Employees";
            // 
            // employeeDetailsToolStripMenuItem
            // 
            this.employeeDetailsToolStripMenuItem.Name = "employeeDetailsToolStripMenuItem";
            this.employeeDetailsToolStripMenuItem.Size = new System.Drawing.Size(344, 34);
            this.employeeDetailsToolStripMenuItem.Text = "Employee Details";
            this.employeeDetailsToolStripMenuItem.Click += new System.EventHandler(this.employeeDetailsToolStripMenuItem_Click);
            // 
            // employeeOvertimeToolStripMenuItem
            // 
            this.employeeOvertimeToolStripMenuItem.Name = "employeeOvertimeToolStripMenuItem";
            this.employeeOvertimeToolStripMenuItem.Size = new System.Drawing.Size(344, 34);
            this.employeeOvertimeToolStripMenuItem.Text = "Employee Overtime";
            // 
            // employeesListToolStripMenuItem
            // 
            this.employeesListToolStripMenuItem.Name = "employeesListToolStripMenuItem";
            this.employeesListToolStripMenuItem.Size = new System.Drawing.Size(344, 34);
            this.employeesListToolStripMenuItem.Text = "Employees List";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(341, 6);
            // 
            // attendenceToolStripMenuItem
            // 
            this.attendenceToolStripMenuItem.Name = "attendenceToolStripMenuItem";
            this.attendenceToolStripMenuItem.Size = new System.Drawing.Size(344, 34);
            this.attendenceToolStripMenuItem.Text = "Attendence";
            // 
            // attendenceListToolStripMenuItem
            // 
            this.attendenceListToolStripMenuItem.Name = "attendenceListToolStripMenuItem";
            this.attendenceListToolStripMenuItem.Size = new System.Drawing.Size(344, 34);
            this.attendenceListToolStripMenuItem.Text = "Attendences List";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(341, 6);
            // 
            // leaveManagmentToolStripMenuItem
            // 
            this.leaveManagmentToolStripMenuItem.Name = "leaveManagmentToolStripMenuItem";
            this.leaveManagmentToolStripMenuItem.Size = new System.Drawing.Size(344, 34);
            this.leaveManagmentToolStripMenuItem.Text = "Leave Requests Management";
            // 
            // approvedLeavesListToolStripMenuItem
            // 
            this.approvedLeavesListToolStripMenuItem.Name = "approvedLeavesListToolStripMenuItem";
            this.approvedLeavesListToolStripMenuItem.Size = new System.Drawing.Size(344, 34);
            this.approvedLeavesListToolStripMenuItem.Text = "Approved Requests List";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(341, 6);
            // 
            // currentUserToolStripMenuItem
            // 
            this.currentUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userInformationToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.currentUserToolStripMenuItem.Name = "currentUserToolStripMenuItem";
            this.currentUserToolStripMenuItem.Size = new System.Drawing.Size(126, 29);
            this.currentUserToolStripMenuItem.Text = "Current User";
            // 
            // userInformationToolStripMenuItem
            // 
            this.userInformationToolStripMenuItem.Name = "userInformationToolStripMenuItem";
            this.userInformationToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.userInformationToolStripMenuItem.Text = "User information";
            this.userInformationToolStripMenuItem.Click += new System.EventHandler(this.userInformationToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.changePasswordToolStripMenuItem.Text = "Change password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesListToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.attendencesReportToolStripMenuItem,
            this.overtimeReportToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.helpToolStripMenuItem.Text = "Reports";
            // 
            // employeesListToolStripMenuItem1
            // 
            this.employeesListToolStripMenuItem1.Name = "employeesListToolStripMenuItem1";
            this.employeesListToolStripMenuItem1.Size = new System.Drawing.Size(348, 34);
            this.employeesListToolStripMenuItem1.Text = "Employees List";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(348, 34);
            this.toolStripMenuItem4.Text = "Employee Leave Requests List";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(345, 6);
            // 
            // attendencesReportToolStripMenuItem
            // 
            this.attendencesReportToolStripMenuItem.Name = "attendencesReportToolStripMenuItem";
            this.attendencesReportToolStripMenuItem.Size = new System.Drawing.Size(348, 34);
            this.attendencesReportToolStripMenuItem.Text = "Attendences Report";
            // 
            // overtimeReportToolStripMenuItem
            // 
            this.overtimeReportToolStripMenuItem.Name = "overtimeReportToolStripMenuItem";
            this.overtimeReportToolStripMenuItem.Size = new System.Drawing.Size(348, 34);
            this.overtimeReportToolStripMenuItem.Text = "Overtime Report";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainScreen.Location = new System.Drawing.Point(110, 118);
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Size = new System.Drawing.Size(894, 624);
            this.pnlMainScreen.TabIndex = 10;
            // 
            // FrmMainAdminScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 742);
            this.Controls.Add(this.pnlMainScreen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMainAdminScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.FrmMainAdminScreen_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWelcoming;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.Label DateNow;
        private System.Windows.Forms.ToolStripMenuItem employeeDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem attendenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendenceListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem leaveManagmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeOvertimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approvedLeavesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Panel pnlMainScreen;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.ToolStripMenuItem employeesListToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem attendencesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overtimeReportToolStripMenuItem;
    }
}