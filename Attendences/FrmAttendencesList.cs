using EAS_Buissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_Attendence_System.Attendences
{
    public partial class FrmAttendencesList : Form
    {
        public FrmAttendencesList()
        {
            InitializeComponent();
        }

        private void FrmAttendencesList_Load(object sender, EventArgs e)
        {
            dgvAttendencesList.DataSource = clsAttendence.AttendencesList();

        }
    }
}
