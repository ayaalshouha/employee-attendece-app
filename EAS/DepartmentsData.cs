using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Data
{
    public class DepartmentsData
    {
        public static bool getDepartmentInfo(int DepartmentID, ref stDepartment department)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "select * from Departments where ID = @DepartmentID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    isFound = true;
                    department.ID = (int)Reader["ID"];
                    department.Name = (string)Reader["Name"];
                    department.RequiredWorkHours = (int)Reader["RequiredWorkHours"];
                    department.DollarPerHour = (decimal)Reader["DollarPerHour"];
                    department.TotalEmployeesCount = (int)Reader["TotalEmployeesCount"];
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

        public static int Add(stDepartment department)
        {
            int newID = -1;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO  
                        Departments   (Name,RequiredWorkHours,DollarPerHour,TotalEmployeesCount)
                        VALUES  (@Name, @RequiredWorkHours, @DollarPerHour,@TotalEmployeesCount);
                          SELECT SCOPE_IDENTITY();";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@Name", department.Name);
                Command.Parameters.AddWithValue("@RequiredWorkHours", department.RequiredWorkHours);
                Command.Parameters.AddWithValue("@DollarPerHour", department.DollarPerHour);
                Command.Parameters.AddWithValue("@TotalEmployeesCount", 0);

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




        public static bool Update(stDepartment department)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Departments
                    SET Name = @Name,
                        RequiredWorkHours = @RequiredWorkHours, 
                        DollarPerHour = @DollarPerHour,
                        WHERE ID = @departmentID;";


                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@departmentID", department.ID);
                Command.Parameters.AddWithValue("@RequiredWorkHours", department.RequiredWorkHours);
                Command.Parameters.AddWithValue("@DollarPerHour", department.DollarPerHour);


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

        public static bool Delete(int DepartmentID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM Departments WHERE ID = @DepartmentID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
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

        public static int getTotalEmployeesCount(int DepartmentID)
        {
            int TotalCount = -1;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"SELECT TotalEmployeesCount FROM Departments
                            WHERE ID = @DepartmentID;";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int LastID))
                {
                    TotalCount = LastID;
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
            return TotalCount;
        }

        //(SELECT COUNT(ID) FROM Employees WHERE EmployeeDepartmentID = @DepartmentID)

        public static bool UpdateTotalEmployeesCount(stDepartment Department)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update Departments 
                SET TotalEmployeesCount = @TotalEmployeesCount + 1
                WHERE ID = @DepartmentID;";


                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@DepartmentID", Department.ID);
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

        public static bool isExist(int DepartmentID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM Departments WHERE ID = @DepartmentID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
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
                string Query = "SELECT * FROM Departments;";
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
