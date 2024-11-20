using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTES.Data_Access.Setting;

namespace BTES.Data_Access.Event_Management
{
    public  class clsSportEventData
    {

        //this function will return the new contact id if succeeded and -1 if not.
        public static int InsertRecord(int Event_ID, string Team_VS_Team)
        {

            int RecordID = -1;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"INSERT INTO Sports  (Event_ID, Team_VS_Team)
                             VALUES (@Event_ID, @Team_VS_Team);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Team_VS_Team", Team_VS_Team);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    RecordID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            { connection.Close(); }

            return RecordID;

        }


        public static bool UpdateRecord(int Sport_ID, int Event_ID, string Team_VS_Team)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"Update Sports
                              set Sport_ID = @Sport_ID , 
                    Event_ID = @Event_ID , 
                    Team_VS_Team = @Team_VS_Team 
                              where Sport_ID = @Sport_ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Sport_ID", Sport_ID);
            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Team_VS_Team", Team_VS_Team);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }

        public static bool FindBySport_ID(int Sport_ID, ref int Event_ID, ref string Team_VS_Team)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"SELECT * FROM Sports 
                             WHERE  Sport_ID = @Sport_ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Sport_ID", Sport_ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Event_ID = (int)reader["Event_ID"];
                    Team_VS_Team = (string)reader["Team_VS_Team"];


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
        public static bool DeleteRecord(int Sport_ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"Delete Sports 
                                        where Sport_ID = @Sport_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Sport_ID", Sport_ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static DataTable GetRecords()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = "SELECT * FROM Sports;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
        public static bool IsRecordExist(int Sport_ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Sports WHERE Sport_ID = @Sport_ID ";
        
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Sport_ID", Sport_ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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
