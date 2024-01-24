namespace Employees_Attendence_System.Users
{
    partial class FrmChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCheckpass = new System.Windows.Forms.Label();
            this.lblNewpass = new System.Windows.Forms.Label();
            this.lblCurrentPass = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.userInformationWithFilter1 = new Employees_Attendence_System.UserControls.UserInformationWithFilter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.labelHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 72);
            this.panel1.TabIndex = 1;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHeader.Location = new System.Drawing.Point(307, 14);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(271, 44);
            this.labelHeader.TabIndex = 20;
            this.labelHeader.Text = "Change Password";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(669, 681);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 37);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(780, 681);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 37);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCheckpass
            // 
            this.lblCheckpass.AutoSize = true;
            this.lblCheckpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckpass.Location = new System.Drawing.Point(48, 644);
            this.lblCheckpass.Name = "lblCheckpass";
            this.lblCheckpass.Size = new System.Drawing.Size(157, 20);
            this.lblCheckpass.TabIndex = 17;
            this.lblCheckpass.Text = "Confirm password:";
            // 
            // lblNewpass
            // 
            this.lblNewpass.AutoSize = true;
            this.lblNewpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewpass.Location = new System.Drawing.Point(48, 612);
            this.lblNewpass.Name = "lblNewpass";
            this.lblNewpass.Size = new System.Drawing.Size(129, 20);
            this.lblNewpass.TabIndex = 16;
            this.lblNewpass.Text = "New password:";
            // 
            // lblCurrentPass
            // 
            this.lblCurrentPass.AutoSize = true;
            this.lblCurrentPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPass.Location = new System.Drawing.Point(48, 580);
            this.lblCurrentPass.Name = "lblCurrentPass";
            this.lblCurrentPass.Size = new System.Drawing.Size(155, 20);
            this.lblCurrentPass.TabIndex = 15;
            this.lblCurrentPass.Text = "Current password:";
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(241, 612);
            this.txtNew.Name = "txtNew";
            this.txtNew.PasswordChar = '*';
            this.txtNew.Size = new System.Drawing.Size(168, 26);
            this.txtNew.TabIndex = 14;
            this.txtNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtNew_Validating);
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(241, 644);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.PasswordChar = '*';
            this.txtCheck.Size = new System.Drawing.Size(168, 26);
            this.txtCheck.TabIndex = 13;
            this.txtCheck.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheck_Validating);
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(241, 580);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.PasswordChar = '*';
            this.txtCurrent.Size = new System.Drawing.Size(168, 26);
            this.txtCurrent.TabIndex = 12;
            this.txtCurrent.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrent_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(30, 676);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(633, 46);
            this.label1.TabIndex = 20;
            this.label1.Text = "NOTES: ";
            this.label1.Visible = false;
            // 
            // userInformationWithFilter1
            // 
            this.userInformationWithFilter1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userInformationWithFilter1.FilterEnbled = true;
            this.userInformationWithFilter1.Location = new System.Drawing.Point(12, 78);
            this.userInformationWithFilter1.Name = "userInformationWithFilter1";
            this.userInformationWithFilter1.Size = new System.Drawing.Size(853, 499);
            this.userInformationWithFilter1.TabIndex = 0;
            this.userInformationWithFilter1.OnUserSelected += new System.EventHandler<Employees_Attendence_System.UserControls.UserInformationWithFilter.UserSelectedEventArgs>(this.userInformationWithFilter1_OnUserSelected);
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(884, 766);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCheckpass);
            this.Controls.Add(this.lblNewpass);
            this.Controls.Add(this.lblCurrentPass);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userInformationWithFilter1);
            this.Name = "FrmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password Form";
            this.Load += new System.EventHandler(this.FrmChangePassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.UserInformationWithFilter userInformationWithFilter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCheckpass;
        private System.Windows.Forms.Label lblNewpass;
        private System.Windows.Forms.Label lblCurrentPass;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
    }
}