using Employees_Attendence_System.Adminstration;
using Employees_Attendence_System.Attendences;
using Employees_Attendence_System.Leave_Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_Attendence_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmStart());
            //Application.Run(new FrmCheckInOut());
            //Application.Run(new FrmAdminLogin());
            //Application.Run(new FrmLeaveRequest());
        }
    }
}
