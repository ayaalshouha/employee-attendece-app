using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Data
{
    public class EmployeesData
    {
        public static bool getEmployeeInfo(int EmployeeID, ref stEmployee employee)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "select * from Employees where EMP_Code = @EmployeeID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    isFound = true;
                    employee.ID = (int)Reader["EMP_Code"];
                    employee.PersonID = (int)Reader["PersonID"];
                    employee.EmployeeDepartmentID = (int)Reader["DepartmentID"];
                    employee.WorkedFrom = (DateTime)Reader["HireDate"];

                    if(Reader["LeaveDate"] == DBNull.Value)
                        employee.WorkedTo = null;
                    else
                        employee.WorkedTo = (DateTime)Reader["LeaveDate"];
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

        public static int Add(stEmployee employee)
        {
            int newID = -1;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO  
                        Employees   (PersonID,DepartmentID,HireDate,LeaveDate)
                        VALUES  (@PersonID, @DepartmentID, @HireDate, @LeaveDate);
                          SELECT SCOPE_IDENTITY();";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@PersonID", employee.PersonID);
                Command.Parameters.AddWithValue("@DepartmentID", employee.EmployeeDepartmentID);
                Command.Parameters.AddWithValue("@HireDate", employee.WorkedFrom);

                if (employee.WorkedTo == DateTime.MinValue)
                    Command.Parameters.AddWithValue("@LeaveDate", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@LeaveDate", employee.WorkedTo);

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

        public static bool Update(stEmployee employee)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Employees
                    SET DepartmentID = @EmployeeDepartmentID,
                        LeaveDate = @LeaveDate
                        WHERE EMP_Code = @employeeID;";


                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@employeeID", employee.ID);
                Command.Parameters.AddWithValue("@EmployeeDepartmentID", employee.EmployeeDepartmentID);


                if (employee.WorkedTo == null)
                    Command.Parameters.AddWithValue("@LeaveDate", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@LeaveDate", employee.WorkedTo);


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

        public static bool Delete(int EmployeeID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE FROM Employees WHERE EMP_Code = @EmployeeID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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

        public static bool isExist_ByPersonID(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT EMP_Code FROM Employees WHERE PersonID = @PersonID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
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
                string Query = "SELECT * FROM Employees_List;";
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
