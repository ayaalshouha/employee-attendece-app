using EAS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Buissness
{
    internal class clsOvertimeTrack
    {
        private enum enMode { AddNew = 0, Update }
        private enMode _Mode = enMode.AddNew;
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public decimal OvertimeHour { get; set; }
        public DateTime Date { get; set; }

        public clsOvertimeTrack()
        {
            this.ID = -1;
            this.EmployeeID = -1;
            this.OvertimeHour = -1;
            this.Date = DateTime.MinValue;

            _Mode = enMode.AddNew;
        }
        private clsOvertimeTrack(stOvertimeTracking tracking)
        {
            this.ID = tracking.ID;
            this.EmployeeID = tracking.EmployeeID;
            this.OvertimeHour = tracking.OvertimeHour;
            this.Date = tracking.Date;
            _Mode = enMode.Update;
        }

        public static clsOvertimeTrack Find(int TrackID)
        {
            stOvertimeTracking tracking = new stOvertimeTracking();
            if (OvertimeTrackingData.getTrackInfo(TrackID, ref tracking))
                return new clsOvertimeTrack(tracking);
            else
                return null;
        }

        private bool _AddNew()
        {
            stOvertimeTracking tracking = new stOvertimeTracking
            {
                EmployeeID = this.EmployeeID,
                OvertimeHour = this.OvertimeHour,
                Date = this.Date
            };

            this.ID = OvertimeTrackingData.Add(tracking);
            return this.ID != -1;
        }

        private bool _Update()
        {
            stOvertimeTracking tracking = new stOvertimeTracking
            {
                ID = this.ID,
                EmployeeID = this.EmployeeID,
                OvertimeHour = this.OvertimeHour,
                Date = this.Date
            };

            return OvertimeTrackingData.Update(tracking);
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
            return OvertimeTrackingData.Delete(this.ID);
        }


        public static DataTable TrackingsList()
        {
            return OvertimeTrackingData.List();
        }

        public static decimal CalculateTotalHoursPerMonth(int EmployeeID, int Month)
        {
            return OvertimeTrackingData.CalculateOverTimePerMonth(EmployeeID, Month);
        }

    }
}
