using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Data
{
    public class OvertimeTrackingData
    {
        public static bool getTrackInfo(int TrackID, ref stOvertimeTracking track)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "select * from OverTimeTrackings where ID = @TrackID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@TrackID", TrackID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    isFound = true;
                    track.ID = (int)Reader["ID"];
                    track.EmployeeID = (int)Reader["EmployeeID"];
                    track.Date = (DateTime)Reader["Date"];
                    track.OvertimeHour = (decimal)Reader["OvertimeHours"];

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

        public static int Add(stOvertimeTracking track)
        {
            int newID = -1;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO  
                        OverTimeTrackings (EmployeeID,OvertimeHours,Date)
                        VALUES  (@EmployeeID, @OvertimeHours, @Date);
                          SELECT SCOPE_IDENTITY();";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@EmployeeID", track.EmployeeID);
                Command.Parameters.AddWithValue("@OvertimeHours", track.OvertimeHour);
                Command.Parameters.AddWithValue("@Date", track.Date);


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

        public static bool Update(stOvertimeTracking tracking)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update OverTimeTrackings
                    SET EmployeeID = @EmployeeID,
                        OvertimeHours = @OvertimeHours, 
                        Date = @Date 
                        WHERE ID = @trackID;";


                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@trackID", tracking.ID);
                Command.Parameters.AddWithValue("@EmployeeID", tracking.EmployeeID);
                Command.Parameters.AddWithValue("@OvertimeHours", tracking.OvertimeHour);
                Command.Parameters.AddWithValue("@Date", tracking.Date);

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

        public static bool Delete(int TrackID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM OverTimeTrackings WHERE ID = @TrackID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@TrackID", TrackID);
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

        public static bool isExist(int TrackID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM OverTimeTrackings WHERE ID = @TrackID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@TrackID", TrackID);
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

        public static DataTable List()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT * FROM OverTimeTrackings;";
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


        public static decimal CalculateOverTimePerMonth(int EmployeeID, int Month)
        {
            decimal TotalHours = -1;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT COUNT(OvertimeHours) FROM OverTimeTrackings
                            WHERE EmployeeID = @EmployeeID and  MONTH(Date) = @Month;";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                Command.Parameters.AddWithValue("@Month", Month);


                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out decimal total))
                {
                    TotalHours = total;
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

            return TotalHours;

        }

    }
}
