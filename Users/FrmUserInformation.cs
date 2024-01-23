using Employees_Attendence_System.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_Attendence_System.Users
{
    public partial class FrmUserInformation : Form
    {
        private int user_id = -1; 

        public FrmUserInformation(int UserID = -1)
        {
            user_id = UserID;
            InitializeComponent();
        }
        private void FrmUserInformation_Load(object sender, EventArgs e)
        {
            if(user_id == -1)
                userInformationWithFilter1.FilterEnbled = true;
            else
            {
                userInformationWithFilter1.FilterEnbled = false;
                userInformationWithFilter1.LoadUserInfo(user_id);
            }
        }

        private void userInformationWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
