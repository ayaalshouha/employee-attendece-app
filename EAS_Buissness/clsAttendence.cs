using EAS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Buissness
{
    public class clsAttendence
    {
        private enum enMode { AddNew = 0, Update }
        private enMode _Mode = enMode.AddNew;
        public int ID { get; set; }
        public int EmployeeID { get; set; }

        public clsEmployee EmployeeInfo { get; set; }
        public DateTime Date { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public clsAttendence()
        {
            this.ID = -1;
            this.EmployeeID = -1;
            this.Date = DateTime.MinValue;
            this.CheckInTime = DateTime.MinValue;
            this.CheckOutTime = DateTime.MinValue;
            this.EmployeeInfo = null;
            _Mode = enMode.AddNew;
        }

        private clsAttendence(stAttendence attendence)
        {
            this.ID = attendence.ID;
            this.EmployeeID = attendence.EmployeeID;
            this.Date = attendence.Date;
            this.CheckInTime = attendence.CheckInTime;
            this.CheckOutTime = attendence.CheckOutTime;
            this.EmployeeInfo = clsEmployee.Find(EmployeeID);
            _Mode = enMode.Update;
        }

        public static clsAttendence Find(int attendenceID)
        {
            stAttendence attendence = new stAttendence();
            if (AttendenceData.getAttendenceInfo(attendenceID, ref attendence))
                return new clsAttendence(attendence);
            else
                return null;
        }

        private bool _AddNew()
        {
            stAttendence attendence = new stAttendence
            {
                //ID = this.ID,
                EmployeeID = this.EmployeeID,
                Date = this.Date,
                CheckInTime = this.CheckInTime,
                CheckOutTime = this.CheckOutTime
            };

            this.ID = AttendenceData.Add(attendence);
            return this.ID != -1;
        }

        private bool _Update()
        {
            stAttendence attendence = new stAttendence
            {
                ID = this.ID,
                EmployeeID = this.EmployeeID,
                Date = this.Date,
                CheckInTime = this.CheckInTime,
                CheckOutTime = this.CheckOutTime
            };

            return AttendenceData.Update(attendence);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public bool Delete()
        {
            return AttendenceData.Delete(this.ID);
        }

        public static DataTable AttendencesList()
        {
            return AttendenceData.List();
        }

        public static bool DoesCheckedInToday(int EmployeeID)
        {
            return AttendenceData.DoesCheckedInToday(EmployeeID);
        }
        public static bool DoesCheckedOutToday(int EmployeeID)
        {
            return AttendenceData.DoesCheckedOutToday(EmployeeID);
        }

        public static bool CheckOut(int EmployeeID)
        {
            return AttendenceData.CheckOut(EmployeeID);
        }

        public static decimal getWorkHoursToday(int EmployeeID)
        {
            return AttendenceData.getWorkHoursToday(EmployeeID);
        }

    }
}
