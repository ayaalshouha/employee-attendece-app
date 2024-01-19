using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EAS_Data
{
    public class LeaveRequestData
    {
        public static bool getRequestInfo(int RequestID, ref stLeaveRequest request)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "select * from LeaveRequests where ID = @RequestID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@RequestID", RequestID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    isFound = true;
                    request.ID = (int)Reader["ID"];
                    request.EmployeeID = (int)Reader["EmployeeID"];


                    if(Reader["isAccepted"] == DBNull.Value)
                        request.isAccepted = false;
                    else
                        request.isAccepted = (bool)Reader["isAccepted"];

                    
                    request.ToDate = (DateTime)Reader["ToDate"];
                    request.FromDate = (DateTime)Reader["FromDate"];
                    request.LeaveReasonID = (int)Reader["LeaveReason"];

                    if (Reader["ClosedByUserID"] == DBNull.Value)
                        request.ClosedByUserID = -1;
                    else
                        request.ClosedByUserID = (int)Reader["ClosedByUserID"]; 


                    request.RequestStatus = (int)Reader["RequestStatus"];
                }

                Reader.Close();
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
        public static int Add(stLeaveRequest request)
        {
            int newID = -1;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO  
                        LeaveRequests   (EmployeeID,FromDate,ToDate,LeaveReason,isAccepted,ClosedByUserID,RequestStatus)
                        VALUES  (@EmployeeID, @FromDate, @ToDate, @LeaveReason, @isAccepted,@ClosedByUserID,1);
                          SELECT SCOPE_IDENTITY();";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@EmployeeID", request.EmployeeID);
                Command.Parameters.AddWithValue("@FromDate", request.FromDate);
                Command.Parameters.AddWithValue("@ToDate", request.ToDate);
                Command.Parameters.AddWithValue("@LeaveReason", request.LeaveReasonID);

                //NOT checked yet to be accepted or not 
                Command.Parameters.AddWithValue("@isAccepted", DBNull.Value);


                if (request.ClosedByUserID == -1)
                    Command.Parameters.AddWithValue("@ClosedByUserID", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ClosedByUserID", request.ClosedByUserID);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int LastID))
                {
                    newID = LastID;
                }
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return newID;
        }

        public static bool Update(stLeaveRequest request)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update LeaveRequests
                    SET EmployeeID = @EmployeeID,
                        isAccepted = @isAccepted, 
                        ToDate = @ToDate ,FromDate = @FromDate , 
                        LeaveReason = @LeaveReason , ClosedByUserID = @ClosedByUserID, 
                        RequestStatus = @RequestStatus
                        WHERE ID = @requestID;";


                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@requestID", request.ID);
                Command.Parameters.AddWithValue("@EmployeeID", request.EmployeeID);
                Command.Parameters.AddWithValue("@isAccepted", request.isAccepted);
                Command.Parameters.AddWithValue("@ToDate", request.ToDate);
                Command.Parameters.AddWithValue("@FromDate", request.FromDate);
                Command.Parameters.AddWithValue("@LeaveReason", request.LeaveReasonID);
                Command.Parameters.AddWithValue("@ClosedByUserID", request.ClosedByUserID);
                Command.Parameters.AddWithValue("@RequestStatus", request.RequestStatus);

                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }

            return RowAffected > 0;
        }

        public static bool Delete(int RequestID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM LeaveRequests WHERE ID = @RequestID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@RequestID", RequestID);
                Connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }

        public static bool isExist(int RequestID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM LeaveRequests WHERE ID = @RequestID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@RequestID", RequestID);
                Connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool isClosed(int RequestID)
        {
            bool isClosed = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            { 
                string Query = @"SELECT isClosed = 1 FROM LeaveRequests
                               WHERE ID = @RequestID  and RequestStatus IN (2,3);";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@RequestID", RequestID);
                Connection.Open();
                object result = command.ExecuteScalar();

                isClosed = (result != null);
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return isClosed;
        }

        public static bool Accept(int RequestID, int UserID)
        {
            int RowAffected = -1;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"UPDATE LeaveRequests  
                                  SET  isAccepted = 1 , ClosedByUserID = @UserID , RequestStatus = 3
                                WHERE ID = @RequestID;";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@RequestID", RequestID);
                command.Parameters.AddWithValue("@UserID", UserID);

                Connection.Open();
                RowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }
        public static bool Reject(int RequestID, int UserID)
        {
            int RowAffected = -1;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"UPDATE LeaveRequests  
                                  SET  isAccepted = 0 , ClosedByUserID = @UserID , RequestStatus = 3
                                WHERE ID = @RequestID;";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@RequestID", RequestID);
                command.Parameters.AddWithValue("@UserID", UserID);

                Connection.Open();
                RowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }

        public static DataTable List()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM LeaveRequests;";
                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static bool UpdateStatus(int RequestID, int StatusID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"UPDATE LeaveRequests SET RequestStatus = @StatusID
                                WHERE ID = @RequestID;"
                ;

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@StatusID", StatusID);
                command.Parameters.AddWithValue("@RequestID", RequestID);

                Connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());

            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }

        
    }
}

