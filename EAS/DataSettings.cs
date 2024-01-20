using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Data
{
    public struct stPerson
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

    }
    public struct stEmployee
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int EmployeeDepartmentID { get; set; }
        public DateTime WorkedFrom { get; set; }
        public DateTime WorkedTo { get; set; }
    }
    public struct stUser
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int permissions { get; set; }
        public bool isActive { get; set; }
    }
    public struct stDepartment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RequiredWorkHours { get; set; }
        public decimal DollarPerHour { get; set; }
        public int TotalEmployeesCount { get; set; }
    }
    public struct stAttendence
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

    }
    public struct stOvertimeTracking
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public decimal OvertimeHour { get; set; }
        public DateTime Date { get; set; }
    }
    public struct stLeaveRequest
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int LeaveReasonID { get; set; }
        public bool isAccepted { get; set; }
        public int ClosedByUserID { get; set; }

        public int RequestStatus { get; set; }
    }
    public class DataSettings
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["connectionString"]; 

           //"server=.; database=AttendenceEmployeesSystem; user id=sa; password=sa123456;";
        public static void StoreUsingEventLogs(string message)
        {
            string sourceName = "AttendenceApp";

            if (!EventLog.SourceExists(sourceName))
                EventLog.CreateEventSource(sourceName, "Application");

            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);
        }

        //public static List<string> GetAllCountries()
        //{
        //    SqlConnection connection = new SqlConnection(DataSettings.ConnectionString);
        //    List<string> Countries = new List<string>();
        //    try
        //    {
        //        string Query = "SELECT nicename From Countries;";
        //        SqlCommand command = new SqlCommand(Query, connection);

        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Countries.Add(reader["nicename"].ToString());
        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return Countries;
        //}

    }
}
