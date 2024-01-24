namespace Employees_Attendence_System.Users
{
    partial class FrmUserInformation
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
            this.userInformationWithFilter1 = new Employees_Attendence_System.UserControls.UserInformationWithFilter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userInformationWithFilter1
            // 
            this.userInformationWithFilter1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userInformationWithFilter1.FilterEnbled = true;
            this.userInformationWithFilter1.Location = new System.Drawing.Point(13, 85);
            this.userInformationWithFilter1.Name = "userInformationWithFilter1";
            this.userInformationWithFilter1.Size = new System.Drawing.Size(853, 501);
            this.userInformationWithFilter1.TabIndex = 0;
            this.userInformationWithFilter1.OnUserSelected += new System.EventHandler<Employees_Attendence_System.UserControls.UserInformationWithFilter.UserSelectedEventArgs>(this.userInformationWithFilter1_OnUserSelected);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.labelHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 72);
            this.panel1.TabIndex = 2;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHeader.Location = new System.Drawing.Point(297, 14);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(284, 44);
            this.labelHeader.TabIndex = 20;
            this.labelHeader.Text = "User\'s Information";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsername.Location = new System.Drawing.Point(719, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(147, 24);
            this.lblUsername.TabIndex = 21;
            this.lblUsername.Text = "[Hello username]";
            // 
            // FrmUserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(878, 592);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userInformationWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmUserInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUserInformation";
            this.Load += new System.EventHandler(this.FrmUserInformation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserInformationWithFilter userInformationWithFilter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label labelHeader;
    }
}