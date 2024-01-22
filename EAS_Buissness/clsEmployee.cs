using EAS_Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace EAS_Buissness
{
    public class clsEmployee
    {
        private enum enMode { AddNew = 0, Update }
        private enMode _Mode = enMode.AddNew;
        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public int EmployeeDepartmentID { get; set; }
        public clsDepartment DepartmentInfo { get; set; }
        public DateTime WorkedFrom { get; set; }
        public DateTime? WorkedTo { get; set; }

        public bool isStillWorking
        {
            get { return (this.WorkedTo == null);  }
        }

        public clsEmployee()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.PersonInfo = null;
            this.EmployeeDepartmentID = -1;
            this.WorkedFrom = DateTime.MinValue;
            this.WorkedTo = null;

            _Mode = enMode.AddNew;
        }
        private clsEmployee(stEmployee employee)
        {
            this.ID = employee.ID;
            this.PersonID = employee.PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.EmployeeDepartmentID = employee.EmployeeDepartmentID;
            this.DepartmentInfo = clsDepartment.Find(EmployeeDepartmentID);
            this.WorkedFrom = employee.WorkedFrom;
            this.WorkedTo = employee.WorkedTo;

            _Mode = enMode.Update;
        }

        public static clsEmployee Find(int EmployeeID)
        {
            stEmployee employee = new stEmployee();
            if (EmployeesData.getEmployeeInfo(EmployeeID, ref employee))
                return new clsEmployee(employee);
            else
                return null;
        }

        private bool _AddNew()
        {
            stEmployee employee = new stEmployee
            {
                PersonID = this.PersonID,
                EmployeeDepartmentID = this.EmployeeDepartmentID,
                WorkedTo = this.WorkedTo,
                WorkedFrom = this.WorkedFrom,
            };

            this.ID = EmployeesData.Add(employee);
            return this.ID != -1;
        }

        private bool _Update()
        {
            stEmployee employee = new stEmployee
            {
                ID = this.ID,
                PersonID = this.PersonID,
                EmployeeDepartmentID = this.EmployeeDepartmentID,
                WorkedTo = this.WorkedTo,
                WorkedFrom = this.WorkedFrom,
            };

            return EmployeesData.Update(employee);
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
            return EmployeesData.Delete(this.ID);
        }

        public static bool isExist_ByPersonID(int PersonID)
        {
            return EmployeesData.isExist_ByPersonID(PersonID);
        }

        public static DataTable EmployeesList()
        {
            return EmployeesData.List();
        }

        public bool DoesCheckedInToday()
        {
            return clsAttendence.DoesCheckedInToday(this.ID);
        }

        public bool DoesCheckedOutToday()
        {
            return clsAttendence.DoesCheckedOutToday(this.ID);
        }

        public bool CheckIn()
        {
            clsAttendence attendence = new clsAttendence();
            attendence.EmployeeID = this.ID;
            attendence.Date = DateTime.Today;
            attendence.CheckInTime = DateTime.Now;

            if (attendence.Save())
            {
                return true;
            }
            return false;
        }
        public bool CheckOut()
        {
            if (clsAttendence.CheckOut(this.ID))
            {
                HandleOvertime(); return true;
            }

            return false;
        }

        public decimal CalculateTotalOvertimePerMonth(int Month)
        {
            return clsOvertimeTrack.CalculateTotalHoursPerMonth(this.ID, Month);
        }

        public decimal CalculateOverTimeBonusPerMonth(int Month)
        {
            decimal OverTime = CalculateTotalOvertimePerMonth(Month);
            return OverTime * DepartmentInfo.DollarPerHour;
        }

        public bool DoesAttendWorkHours()
        {
            return (clsAttendence.getWorkHoursToday(this.ID) == this.DepartmentInfo.RequiredWorkHours);
        }

        public bool HandleOvertime()
        {
            if(!DoesAttendWorkHours())
            {
                clsOvertimeTrack newTrack = new clsOvertimeTrack();
                newTrack.EmployeeID = this.ID; 
                newTrack.Date = DateTime.Today;
                newTrack.OvertimeHour = clsAttendence.getWorkHoursToday(this.ID) - this.DepartmentInfo.RequiredWorkHours;

                if (newTrack.Save())
                {
                    return true;
                }
            }
            return true; 
        }

        public int NewLeaveRequest(DateTime StartDate, DateTime EndDate, int Reason)
        {
            int requestID = -1;
            clsLeaveRequest request = new clsLeaveRequest();
            request.EmployeeID = this.ID;
            request.FromDate = StartDate;
            request.ToDate = EndDate;
            request.LeaveReasonID = (clsLeaveRequest.enLeaveRequest)Reason;
            request.RequestStatusID = clsLeaveRequest.enRequestStatus.New;

            if (request.Save())
                requestID = request.ID;


            return requestID;
        }



    }
}
