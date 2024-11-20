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
    public class clsConcertEventData
    {

        //this function will return the new contact id if succeeded and -1 if not.
        public static int InsertRecord(int Event_ID, string Band_Or_Artist)
        {

            int RecordID = -1;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"INSERT INTO Concerts  (Event_ID, Band_Or_Artist)
                             VALUES (@Event_ID, @Band_Or_Artist);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Band_Or_Artist", Band_Or_Artist);




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


        public static bool UpdateRecord(int Concert_ID, int Event_ID, string Band_Or_Artist)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"Update Concerts
                              set Concert_ID = @Concert_ID , 
                    Event_ID = @Event_ID , 
                    Band_Or_Artist = @Band_Or_Artist 
                              where Concert_ID = @Concert_ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Concert_ID", Concert_ID);
            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Band_Or_Artist", Band_Or_Artist);
            command.Parameters.AddWithValue("@Concert_ID", Concert_ID);


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

        public static bool FindByConcert_ID(int Concert_ID, ref int Event_ID, ref string Band_Or_Artist)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"SELECT * FROM Concerts 
                             WHERE  Concert_ID = @Concert_ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Concert_ID", Concert_ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Event_ID = (int)reader["Event_ID"];
                    Band_Or_Artist = (string)reader["Band_Or_Artist"];


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

        public static bool DeleteRecord(int Concert_ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"Delete Concerts 
                                        where Concert_ID = @Concert_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Concert_ID", Concert_ID);

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
            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = "SELECT * FROM Concerts;";

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

        public static bool IsRecordExist(int Concert_ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Concerts WHERE Concert_ID = @Concert_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Concert_ID", Concert_ID);


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
