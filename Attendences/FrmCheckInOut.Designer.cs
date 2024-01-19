namespace Employees_Attendence_System.Attendences
{
    partial class FrmCheckInOut
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWelcoming = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnrefresh = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.label6);
            this.pnlHeader.Controls.Add(this.lblWelcoming);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(634, 145);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Employees_Attendence_System.Properties.Resources.arrow_left__2_;
            this.btnClose.Location = new System.Drawing.Point(7, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 39);
            this.btnClose.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Employees_Attendence_System.Properties.Resources.status__1_;
            this.pictureBox1.Location = new System.Drawing.Point(88, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(238, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(341, 37);
            this.label6.TabIndex = 4;
            this.label6.Text = "Attendence Fingerprint";
            // 
            // lblWelcoming
            // 
            this.lblWelcoming.AutoSize = true;
            this.lblWelcoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcoming.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWelcoming.Location = new System.Drawing.Point(406, 79);
            this.lblWelcoming.Name = "lblWelcoming";
            this.lblWelcoming.Size = new System.Drawing.Size(140, 25);
            this.lblWelcoming.TabIndex = 3;
            this.lblWelcoming.Text = "Good morning ";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.SystemColors.Control;
            this.pnlContent.Controls.Add(this.btnCheckIn);
            this.pnlContent.Controls.Add(this.label3);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Location = new System.Drawing.Point(41, 236);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(273, 366);
            this.pnlContent.TabIndex = 0;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Image = global::Employees_Attendence_System.Properties.Resources.administrator_down;
            this.btnCheckIn.Location = new System.Drawing.Point(30, 52);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(183, 109);
            this.btnCheckIn.TabIndex = 5;
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(9, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 72);
            this.label3.TabIndex = 2;
            this.label3.Text = "Check-in for your attendence";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check-In";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCheckOut);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(320, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 366);
            this.panel1.TabIndex = 1;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Image = global::Employees_Attendence_System.Properties.Resources.hand_clock;
            this.btnCheckOut.Location = new System.Drawing.Point(43, 52);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(183, 109);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(13, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 64);
            this.label4.TabIndex = 3;
            this.label4.Text = "Check-out to complete your attendence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "Check-Out";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Sitka Small", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.ForeColor = System.Drawing.Color.Red;
            this.txtNotes.Location = new System.Drawing.Point(12, 608);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(581, 48);
            this.txtNotes.TabIndex = 5;
            this.txtNotes.Text = "any further messages will be appear here :-)";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeID.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeID.ForeColor = System.Drawing.Color.Silver;
            this.txtEmployeeID.Location = new System.Drawing.Point(41, 164);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(552, 54);
            this.txtEmployeeID.TabIndex = 0;
            this.txtEmployeeID.Text = "Enter your employement ID...";
            this.txtEmployeeID.TextChanged += new System.EventHandler(this.txtEmployeeID_TextChanged);
            this.txtEmployeeID.Enter += new System.EventHandler(this.txtEmployeeID_Enter);
            this.txtEmployeeID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmployeeID_KeyPress);
            this.txtEmployeeID.Leave += new System.EventHandler(this.txtEmployeeID_Leave);
            // 
            // btnrefresh
            // 
            this.btnrefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnrefresh.Image = global::Employees_Attendence_System.Properties.Resources.refresh;
            this.btnrefresh.Location = new System.Drawing.Point(503, 164);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(90, 54);
            this.btnrefresh.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnrefresh, "Refresh");
            this.btnrefresh.UseVisualStyleBackColor = false;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // FrmCheckInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(634, 660);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmCheckInOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCheckInOut";
            this.Load += new System.EventHandler(this.FrmCheckInOut_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWelcoming;
        private System.Windows.Forms.Label txtNotes;
        private System.Windows.Forms.RichTextBox txtEmployeeID;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnClose;
    }
}