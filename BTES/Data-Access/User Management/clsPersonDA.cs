using BTES.Data_Access.Setting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access
{
    public class ClsPersonDA
    {
        public static bool GetPerson_Info_By_In_Person(int Person_ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email, ref string Address, ref int Age, ref string Password, ref string UserName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);
            string query = "SELECT * FROM Person WHERE Person_ID = @Person_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Person_ID", Person_ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    FirstName = reader["FirstName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    Address = reader["Address"].ToString();
                    Age = int.Parse(reader["Age"].ToString());
                    Password = reader["Password"].ToString();
                    UserName = reader["UserName"].ToString();

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
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
