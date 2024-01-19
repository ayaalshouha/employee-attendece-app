using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EAS_Data
{
    public class AttendenceData
    {
        public static bool getAttendenceInfo(int AttendenceID, ref stAttendence attendence)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "select * from Attendences where ID = @AttendenceID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@AttendenceID", AttendenceID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    isFound = true;
                    attendence.ID = (int)Reader["ID"];
                    attendence.EmployeeID = (int)Reader["Name"];
                    attendence.Date = (DateTime)Reader["Date"];
                    attendence.CheckInTime = (DateTime)Reader["CheckInTime"];
                    attendence.CheckOutTime = (DateTime)Reader["CheckOutTime"];
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

        public static int Add(stAttendence attendence)
        {
            int newID = -1;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO  
                        Attendences   (EmployeeID,Date,CheckInTime,CheckOutTime)
                        VALUES  (@EmployeeID, @Date, @CheckInTime,@CheckOutTime);
                          SELECT SCOPE_IDENTITY();";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@EmployeeID", attendence.EmployeeID);
                Command.Parameters.AddWithValue("@Date", attendence.Date);
                Command.Parameters.AddWithValue("@CheckInTime", attendence.CheckInTime);

                if (attendence.CheckOutTime == DateTime.MinValue)
                    Command.Parameters.AddWithValue("@CheckOutTime", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@CheckOutTime", attendence.CheckOutTime);

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

        public static bool Update(stAttendence attendence)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Attendences
                    SET EmployeeID = @EmployeeID,
                        Date = @Date, CheckInTime = @CheckInTime, CheckOutTime = @CheckOutTime
                        WHERE ID = @AttendenceID;";


                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@AttendenceID", attendence.ID);
                Command.Parameters.AddWithValue("@EmployeeID", attendence.EmployeeID);
                Command.Parameters.AddWithValue("@Date", attendence.Date);
                Command.Parameters.AddWithValue("@CheckInTime", attendence.CheckInTime);
                //Command.Parameters.AddWithValue("@CheckOutTime", attendence.CheckOutTime);


                if (attendence.CheckOutTime == DateTime.MinValue)
                    Command.Parameters.AddWithValue("@CheckOutTime", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@CheckOutTime", attendence.CheckOutTime);


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

        public static bool DoesCheckedInToday(int EmployeeID)
        {
            bool Checkedin = false;
            DateTime dateTime = DateTime.Today;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Select ID from Attendences
                WHERE EmployeeID = @EmployeeID and Date = @dateTime;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                Command.Parameters.AddWithValue("@dateTime", dateTime);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                    Checkedin = true;
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return Checkedin;
        }

        public static bool DoesCheckedOutToday(int EmployeeID)
        {
            bool Checkedout = false;
            DateTime dateTime = DateTime.Today;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Select ID from Attendences
                WHERE EmployeeID = @EmployeeID and Date = @dateTime and CheckOutTime is not null;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                Command.Parameters.AddWithValue("@dateTime", dateTime);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
                    Checkedout = true;
            }

            catch (Exception ex)
            {
                DataSettings.StoreUsingEventLogs(ex.Message.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return Checkedout;
        }

        public static decimal getWorkHoursToday(int EmployeeID)
        {
            decimal WorkHours = -1;
            DateTime dateTime = DateTime.Today;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT DATEDIFF(HOUR, @CheckInTime, @CheckOutTime) from Attendences
                WHERE EmployeeID = @EmployeeID and Date = @dateTime;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                Command.Parameters.AddWithValue("@dateTime", dateTime);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out decimal total))
                {
                    WorkHours = total;
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
            return WorkHours;
        }

        public static bool CheckOut(int EmployeeID)
        {
            int RowAffected = 0;
            DateTime TodaysDate = DateTime.Now.Date;
            DateTime datetime = DateTime.Now;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Attendences
                    SET CheckOutTime = @datetime
                    WHERE EmployeeID = @EmployeeID and Date = @TodaysDate;";


                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@datetime", datetime);
                Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                Command.Parameters.AddWithValue("@TodaysDate", TodaysDate);

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

        public static bool Delete(int AttendenceID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM Attendences WHERE ID = @AttendenceID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@AttendenceID", AttendenceID);
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
                string Query = "SELECT * FROM Attendences;";
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
    }
}
