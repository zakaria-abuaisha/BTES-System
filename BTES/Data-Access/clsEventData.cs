using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access
{

    public class clsEventData
    {
        public static int InsertRecord(string Title, string Event_Content, DateTime Event_Date, int EventType_ID, int Regular_Tickets, int VIP_Tickets, float Regular_Price, float VIP_Price, string Location, int Created_By)
        {

            int RecordID = -1;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"INSERT INTO Events  (Title, Event_Content, Event_Date, EventType_ID, Regular_Tickets, VIP_Tickets, Regular_Price, VIP_Price, Location, Created_By)
                                 VALUES (@Title, @Event_Content, @Event_Date, @EventType_ID, @Regular_Tickets, @VIP_Tickets, @Regular_Price, @VIP_Price, @Location, @Created_By);
                                 SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Event_Content", Event_Content);
            command.Parameters.AddWithValue("@Event_Date", Event_Date);
            command.Parameters.AddWithValue("@EventType_ID", EventType_ID);
            command.Parameters.AddWithValue("@Regular_Tickets", Regular_Tickets);
            command.Parameters.AddWithValue("@VIP_Tickets", VIP_Tickets);
            command.Parameters.AddWithValue("@Regular_Price", Regular_Price);
            command.Parameters.AddWithValue("@VIP_Price", VIP_Price);
            command.Parameters.AddWithValue("@Location", Location);
            command.Parameters.AddWithValue("@Created_By", Created_By);




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


        public static bool UpdateRecord(int Event_ID, string Title, string Event_Content, DateTime Event_Date, int EventType_ID, int Regular_Tickets, int VIP_Tickets, float Regular_Price, float VIP_Price, string Location, int Created_By)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"Update Events
                              set Event_ID = @Event_ID , 
                            Title = @Title , 
                            Event_Content = @Event_Content , 
                            Event_Date = @Event_Date , 
                            EventType_ID = @EventType_ID , 
                            Regular_Tickets = @Regular_Tickets , 
                            VIP_Tickets = @VIP_Tickets , 
                            Regular_Price = @Regular_Price , 
                            VIP_Price = @VIP_Price , 
                            Location = @Location , 
                            Created_By = @Created_By 
                              where Event_ID = @Event_ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Event_Content", Event_Content);
            command.Parameters.AddWithValue("@Event_Date", Event_Date);
            command.Parameters.AddWithValue("@EventType_ID", EventType_ID);
            command.Parameters.AddWithValue("@Regular_Tickets", Regular_Tickets);
            command.Parameters.AddWithValue("@VIP_Tickets", VIP_Tickets);
            command.Parameters.AddWithValue("@Regular_Price", Regular_Price);
            command.Parameters.AddWithValue("@VIP_Price", VIP_Price);
            command.Parameters.AddWithValue("@Location", Location);
            command.Parameters.AddWithValue("@Created_By", Created_By);
            command.Parameters.AddWithValue("@Event_ID", Event_ID);


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


        public static bool FindByEvent_ID(int Event_ID, ref string Title, ref string Event_Content, ref DateTime Event_Date, ref int EventType_ID, ref int Regular_Tickets, ref int VIP_Tickets, ref float Regular_Price, ref float VIP_Price, ref string Location, ref int Created_By)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"SELECT * FROM Events 
                                 WHERE  Event_ID = @Event_ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Title = (string)reader["Title"];
                    Event_Content = (string)reader["Event_Content"];
                    Event_Date = DateTime.Parse(reader["Event_Date"].ToString());
                    EventType_ID = int.Parse(reader["EventType_ID"].ToString());
                    Regular_Tickets = int.Parse(reader["Regular_Tickets"].ToString());
                    VIP_Tickets = int.Parse(reader["VIP_Tickets"].ToString());
                    Regular_Price = float.Parse(reader["Regular_Price"].ToString());
                    VIP_Price = float.Parse(reader["VIP_Price"].ToString());
                    Location = (string)reader["Location"];
                    Created_By = int.Parse(reader["Created_By"].ToString());


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
        public static bool DeleteEvent(int Event_ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string query = @"Delete Events 
                                            where Event_ID = @Event_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID);

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
    }
}