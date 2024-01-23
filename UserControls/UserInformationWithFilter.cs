using EAS_Buissness;
using Employees_Attendence_System.Users;
using System;
using System.Windows.Forms;

namespace Employees_Attendence_System.UserControls
{
    public partial class UserInformationWithFilter : UserControl
    {
        public class UserSelectedEventArgs : EventArgs
        {
            public clsUser SelectedUser { get; }

            public UserSelectedEventArgs(clsUser user)
            {
                this.SelectedUser = user;
            }
        }

        public event EventHandler<UserSelectedEventArgs> OnUserSelected;
        public void RaiseOnLicenseSelected(clsUser user)
        {
            RaiseOnLicenseSelected(new UserSelectedEventArgs(user));
        }
        protected virtual void RaiseOnLicenseSelected(UserSelectedEventArgs e)
        {
            OnUserSelected?.Invoke(this, e);
        }

       private clsUser User;
        private int? _UserID = null;
        private bool _FilterEnabled = true;

        public bool FilterEnbled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public clsUser SelectedUser
        {
            get { return User; }
        }
        public int? UserID
        {
            get { return _UserID; }
        }

        private void Clear()
        {
            lblPersonID.Text = "[???]";
            lblName.Text = "[???]";
            lblDepartmentName.Text = "[???]";
            lblEmail.Text = "[???]";
            lblHireDate.Text = "[???]";
            lblLeavingDate.Text = "[???]";
            lblPhonenumber.Text = "[???]";
            lblBirthdate.Text = "[???]";
            lblGender.Text = "[???]";
            lblCountry.Text = "[???]";
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblisActive.Text = "[???]"; 

            lblEditInfo.Visible = false;
        }

        private void LoadUserInfo(clsUser user)
        {
            if (user != null)
            {
                lblPersonID.Text = user.EmployeeInfo.PersonInfo.ID.ToString();
                lblName.Text = user.EmployeeInfo.PersonInfo.FullName();
                lblDepartmentName.Text = user.EmployeeInfo.DepartmentInfo.Name.ToString();
                lblEmail.Text = user.EmployeeInfo.PersonInfo.Email.ToString();
                lblHireDate.Text = user.EmployeeInfo.WorkedFrom.ToShortDateString();

                //string workedTo;
                //workedTo = Employee.WorkedTo?.ToString();
                //lblLeavingDate.Text = workedTo ?? "Still working."; 

                //lblLeavingDate.Text = Employee.WorkedTo.ToString() ?? "Still Working."; 

                lblLeavingDate.Text = user.EmployeeInfo.WorkedTo.HasValue ? user.EmployeeInfo.WorkedTo.ToString() : "Still Working.";

                lblPhonenumber.Text = user.EmployeeInfo.PersonInfo.PhoneNumber.ToString();
                lblBirthdate.Text = user.EmployeeInfo.PersonInfo.BirthDate.ToShortDateString();
                lblGender.Text = user.EmployeeInfo.PersonInfo.Gender.ToString();
                lblCountry.Text = user.EmployeeInfo.PersonInfo.Nationality.ToString();

                lblUserID.Text = user.ID.ToString();
                lblUserName.Text = user.username.ToString();
                lblisActive.Text = user.isActive ? "YES" : "NO";

                
                lblEditUsername.Enabled = true; 
                lblEditInfo.Enabled = true;
                lblNotes.Visible = false;
            }
        }
        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            User = clsUser.Find(_UserID.Value);

            if (User != null)
            {
                LoadUserInfo(User);

                if (OnUserSelected != null)
                {
                    RaiseOnLicenseSelected(User);
                }
            }
            else
            {
                Clear();
                lblNotes.Visible = true;
                lblNotes.Text = "NOT FOUND!";
            }

        }


        public UserInformationWithFilter()
        {
            InitializeComponent();
        }
        private void UserInformationWithFilter_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                return;


            if (int.TryParse(txtInput.Text, out int result))
                _UserID = result;
            else
                return;


            User = clsUser.Find(_UserID.Value);

            if (User != null)
            {
                LoadUserInfo(User);

                if (OnUserSelected != null)
                {
                    RaiseOnLicenseSelected(User);
                }
            }
            else
            {
                Clear();
                lblNotes.Visible = true;
                lblNotes.Text = "NOT FOUND!";
            }
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void UpdateUsernameLabel(object sender , string username)
        {
            lblUserName.Text = username;
        }

        private void lblEditUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUpdateUsername form = new FrmUpdateUsername(User);
            form.Databack += UpdateUsernameLabel; 
            form.ShowDialog();
           
        }
    }
}
