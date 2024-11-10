using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BTES.Data_Access.Setting;

namespace BTES.Data_Access
{
    public class ClsAdminData
    {
        public static bool FindByAdmin_ID(int Admin_ID, ref int Person_ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email,
                              ref string Address, ref int Age, ref string Password, ref string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"SELECT    Admin.Admin_ID, Person.*
                                                FROM     Admin INNER JOIN
                         Person ON Admin.Person_ID = Person.Person_ID
                         where Admin.Admin_ID = @Admin_ID";

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

        public static bool Login(ref int Admin_ID, ref int Person_ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email,
                              ref string Address, ref int Age, string Password, string Username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"SELECT    Admin.Admin_ID, Person.*
                                                FROM     Admin INNER JOIN
                         Person ON Admin.Person_ID = Person.Person_ID
                         where Username = @Username and Password =  @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found

                    Admin_ID = (int)reader["Admin_ID"];
                    Person_ID = (int)reader["Person_ID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];
                    Age = Convert.ToInt32(reader["Age"]);


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
    }

}
