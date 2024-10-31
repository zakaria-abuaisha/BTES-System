using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access
{
    public class clsAdminData
    {
        public static bool FindByAdmin_ID(int Admin_ID, ref int Person_ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email,
                              ref string Address, ref int Age, ref string Password, ref string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"SELECT    Admin.Admin_ID, Person.*
                                                FROM     Admin INNER JOIN
                         Person ON Admin.Person_ID = Person.Person_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Admin_ID", Admin_ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found


                    Person_ID = (int)reader["Person_ID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];
                    Age = (int)reader["Age"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];

                    isFound = true;

                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static bool Login(string Username, string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"SELECT      found=1
                            FROM            Admin INNER JOIN
                            Person ON Admin.Person_ID = Person.Person_ID
						    where UserName = @UserName and Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", Username);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();

                isFound = Convert.ToBoolean(command.ExecuteScalar());


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }
    }

}
