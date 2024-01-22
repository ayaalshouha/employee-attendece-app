using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Data
{
    public class PeopleData
    {
        public static bool getPersonInfo(int PersonID, ref stPerson person)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);

            try
            {
                string Query = "select * from People where ID = @PersonID;";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PersonID", PersonID);

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    isFound = true;
                    person.ID = (int)Reader["ID"];
                    person.FirstName = (string)Reader["FirstName"];
                    person.SecondName = (string)Reader["SecondName"];
                    person.ThirdName = Reader["ThirdName"] == DBNull.Value ? string.Empty : (string)Reader["ThirdName"];
                    person.LastName = (string)Reader["LastName"];
                    person.Email = (string)Reader["Email"];
                    person.PhoneNumber = (string)Reader["PhoneNumber"];
                    person.Address = (string)Reader["Address"];
                    person.Nationality = (string)Reader["Nationality"];
                    person.BirthDate = (DateTime)Reader["BirthDate"];
                    person.Gender = Convert.ToBoolean(Reader["Gender"]) ? "Male" : "Female";
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

        public static int Add(stPerson person)
        {
            int newID = -1;

            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"INSERT INTO  
                        People   (FirstName,SecondName,ThirdName,LastName,Nationality,BirthDate,Email,Address,Gender,PhoneNumber)
                        VALUES  (@FirstName, @SecondName, @ThirdName, @LastName, @Nationality, @Birthdate, @Email, @Address, @Gender, @PhoneNumber);
                          SELECT SCOPE_IDENTITY();";

                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@FirstName", person.FirstName);
                Command.Parameters.AddWithValue("@SecondName", person.SecondName);
                Command.Parameters.AddWithValue("@ThirdName", person.ThirdName);
                Command.Parameters.AddWithValue("@LastName", person.LastName);
                Command.Parameters.AddWithValue("@Nationality", person.Nationality);
                Command.Parameters.AddWithValue("@Email", person.Email);
                Command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                Command.Parameters.AddWithValue("@Birthdate", person.BirthDate);
                Command.Parameters.AddWithValue("@Address", person.Address);
                Command.Parameters.AddWithValue("@Gender", person.Gender);



                if (person.Gender == "Male")
                    Command.Parameters.AddWithValue("@Gender", 0);
                else
                    Command.Parameters.AddWithValue("@Gender", 1);


                if (person.ThirdName == string.Empty)
                    Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ThirdName", person.ThirdName);


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

        public static bool Update(stPerson person)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = @"Update People
                    SET FirstName = @FirstName,
                        SecondName = @SecondName, 
                        ThirdName = @ThirdName, 
                        LastName = @LastName,
                        Address = @Address,
                        BirthDate = @Birthdate,
                        Email = @Email,
                        Nationality = @Nationality, 
                        PhoneNumber = @PhoneNumber, 
                        Gender = @Gender
                        WHERE ID = @PersonID;";


                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PersonID", person.ID);
                Command.Parameters.AddWithValue("@FirstName", person.FirstName);
                Command.Parameters.AddWithValue("@SecondName", person.SecondName);
                Command.Parameters.AddWithValue("@LastName", person.LastName);
                Command.Parameters.AddWithValue("@Email", person.Email);
                Command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                Command.Parameters.AddWithValue("@Birthdate", person.BirthDate);
                Command.Parameters.AddWithValue("@Address", person.Address);
                Command.Parameters.AddWithValue("@Nationality", person.Nationality);


                if (person.Gender == "Male")
                    Command.Parameters.AddWithValue("@Gender", 0);
                else
                    Command.Parameters.AddWithValue("@Gender", 1);


                if (person.ThirdName == string.Empty)
                    Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                else
                    Command.Parameters.AddWithValue("@ThirdName", person.ThirdName);


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

        public static bool Delete(int PersonID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "DELETE  FROM People WHERE ID = @PersonID;";
                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static bool isExist(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataSettings.ConnectionString);
            try
            {
                string Query = "SELECT ID FROM People WHERE ID = @PersonID;";
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
                string Query = "SELECT * FROM People;";
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
