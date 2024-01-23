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
            this.SuspendLayout();
            // 
            // userInformationWithFilter1
            // 
            this.userInformationWithFilter1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userInformationWithFilter1.FilterEnbled = true;
            this.userInformationWithFilter1.Location = new System.Drawing.Point(2, -1);
            this.userInformationWithFilter1.Name = "userInformationWithFilter1";
            this.userInformationWithFilter1.Size = new System.Drawing.Size(853, 501);
            this.userInformationWithFilter1.TabIndex = 0;
            // 
            // FrmUserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(858, 497);
            this.Controls.Add(this.userInformationWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUserInformation";
            this.Text = "FrmUserInformation";
            this.Load += new System.EventHandler(this.FrmUserInformation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserInformationWithFilter userInformationWithFilter1;
    }
}