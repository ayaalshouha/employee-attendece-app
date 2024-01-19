using EAS_Data;
using System;

namespace EAS_Buissness
{
    public class clsLeaveRequest
    {
        private enum enMode { AddNew = 0, Update }
        private enMode _Mode = enMode.AddNew;

        public enum enLeaveRequest { SickLeave = 1, RemoteWork = 2, Pesonal }
        public enum enRequestStatus { New = 1, Cancelled = 2, Completed }
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public clsEmployee EmployeInfo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public enLeaveRequest LeaveReasonID { get; set; }
        public bool isAccepted { get; set; }
        public int ClosedByUserID { get; set; }
        public enRequestStatus RequestStatusID { get; set; }

        public bool isClosed
        {
            get
            {
                return LeaveRequestData.isClosed(this.ID); 
            }
        }
        public string LeaveReason
        {
            get
            {
                switch (LeaveReasonID)
                {
                    case enLeaveRequest.SickLeave:
                        return "Sick Leave";
                    case enLeaveRequest.RemoteWork:
                        return "Remote Work";
                    case enLeaveRequest.Pesonal:
                        return "Peronal Reasons";
                    default:
                        return "Leave Request Reason";
                }
            }
        }

        public string RequestStatus
        {
            get
            {
                switch (RequestStatusID)
                {
                    case enRequestStatus.New:
                        return "New";
                    case enRequestStatus.Cancelled:
                        return "Cancelled";
                    case enRequestStatus.Completed:
                        return "Completed";
                    default:
                        return "Request Status";
                }
            }
        }

        public clsLeaveRequest()
        {
            this.ID = -1;
            this.EmployeeID = -1;
            this.FromDate = DateTime.MinValue;
            this.ToDate = DateTime.MinValue;
            this.RequestStatusID = enRequestStatus.New;
            this.LeaveReasonID = enLeaveRequest.SickLeave;
            this.isAccepted = false;
            this.EmployeInfo = null;
            this.ClosedByUserID = -1;

            _Mode = enMode.AddNew;
        }



        private clsLeaveRequest(stLeaveRequest request)
        {
            this.ID = request.ID;
            this.EmployeeID = request.EmployeeID;
            this.FromDate = request.FromDate;
            this.ToDate = request.ToDate;
            this.RequestStatusID = (enRequestStatus)request.RequestStatus;
            this.LeaveReasonID = (enLeaveRequest)request.LeaveReasonID;
            this.isAccepted = request.isAccepted;
            this.EmployeInfo = clsEmployee.Find(EmployeeID);
            this.ClosedByUserID = request.ClosedByUserID;

            _Mode = enMode.Update;
        }

        public static clsLeaveRequest Find(int requestID)
        {
            stLeaveRequest request = new stLeaveRequest();
            if (LeaveRequestData.getRequestInfo(requestID, ref request))
                return new clsLeaveRequest(request);
            else
                return null;
        }

        private bool _AddNew()
        {
            stLeaveRequest request = new stLeaveRequest
            {
                //ID = this.ID,
                EmployeeID = this.EmployeeID,
                FromDate = this.FromDate,
                ToDate = this.ToDate,
                LeaveReasonID = (int)LeaveReasonID,
                RequestStatus = (int)RequestStatusID,
                isAccepted = this.isAccepted,
                ClosedByUserID = this.ClosedByUserID
            };

            this.ID = LeaveRequestData.Add(request);
            return this.ID != -1;
        }

        private bool _Update()
        {
            stLeaveRequest request = new stLeaveRequest
            {
                ID = this.ID,
                EmployeeID = this.EmployeeID,
                FromDate = this.FromDate,
                ToDate = this.ToDate,
                LeaveReasonID = (int)LeaveReasonID,
                RequestStatus = (int)RequestStatusID,
                isAccepted = this.isAccepted,
                ClosedByUserID = this.ClosedByUserID
            };

            return LeaveRequestData.Update(request);
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

        public bool Accept(int UserID)
        {
            return LeaveRequestData.Accept(this.ID, UserID);
        }
        public bool Reject(int UserID)
        {
            return LeaveRequestData.Reject(this.ID, UserID);

        }
        public bool Cancel()
        {
            return LeaveRequestData.UpdateStatus(this.ID, 2);
        }
        public bool Delete()
        {
            return LeaveRequestData.Delete(this.ID);
        }



    }
}
