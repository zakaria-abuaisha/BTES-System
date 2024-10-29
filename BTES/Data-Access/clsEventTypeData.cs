using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access
{
    public  class clsEventTypeData
    {

        //this function will return the new contact id if succeeded and -1 if not.
        public static int InsertRecord(string EventType_Name)
        {

            int RecordID = -1;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"INSERT INTO Event_Types  (EventType_Name)
                             VALUES (@EventType_Name);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventType_Name", EventType_Name);




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

        public static bool UpdateRecord(int EventType_ID, string EventType_Name)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"Update Event_Types
                              set EventType_Name = @EventType_Name 
                              where EventType_ID = @EventType_ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventType_ID", EventType_ID);
            command.Parameters.AddWithValue("@eventTypeName", EventType_Name);


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

        public static bool FindByEventType_ID(int EventType_ID, ref string EventType_Name)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"SELECT * FROM Event_Types 
                             WHERE  EventType_ID = @EventType_ID;"; 

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventType_ID", EventType_ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    EventType_Name = (string)reader["EventType_Name"];


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

        public static bool DeleteEventType(int EventType_ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"Delete Event_Types 
                                        where EventType_ID = @EventType_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventType_ID", EventType_ID);

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

        public static DataTable GetAllRecords()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = "SELECT * FROM Event_Types;";

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

    }
}
