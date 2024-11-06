using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTES.Business_layer;

namespace BTES.Data_Access
{

    public class ClsEventData
    {
        public static int InsertRecord(ClsEvent Event)
        { 

            int RecordID = -1;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"INSERT INTO Events  (Title, Event_Content, Event_Date, EventType_ID, Regular_Tickets, VIP_Tickets, Regular_Price, VIP_Price, Location, Created_By)
                                 VALUES (@Title, @Event_Content, @Event_Date, @EventType_ID, @Regular_Tickets, @VIP_Tickets, @Regular_Price, @VIP_Price, @Location, @Created_By);
                                 SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Title", Event.title);
            command.Parameters.AddWithValue("@Event_Content", Event.eventContent);
            command.Parameters.AddWithValue("@Event_Date", Event.eventDate);
            command.Parameters.AddWithValue("@EventType_ID", Event.eventTypeID);
            command.Parameters.AddWithValue("@Regular_Tickets", Event.regularTickets);
            command.Parameters.AddWithValue("@VIP_Tickets", Event.VIPTickets);
            command.Parameters.AddWithValue("@Regular_Price", Event.regularPrice);
            command.Parameters.AddWithValue("@VIP_Price", Event.VIPprice);
            command.Parameters.AddWithValue("@Location", Event.location);
            command.Parameters.AddWithValue("@Created_By", Event.createdByUserID);



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


        public static bool UpdateRecord(ClsEvent Event)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

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

            command.Parameters.AddWithValue("@Event_ID", Event.event_ID);
            command.Parameters.AddWithValue("@Title", Event.title);
            command.Parameters.AddWithValue("@Event_Content", Event.eventContent);
            command.Parameters.AddWithValue("@Event_Date", Event.eventDate);
            command.Parameters.AddWithValue("@EventType_ID", Event.eventTypeID);
            command.Parameters.AddWithValue("@Regular_Tickets", Event.regularTickets);
            command.Parameters.AddWithValue("@VIP_Tickets", Event.VIPTickets);
            command.Parameters.AddWithValue("@Regular_Price", Event.regularPrice);
            command.Parameters.AddWithValue("@VIP_Price", Event.VIPprice);
            command.Parameters.AddWithValue("@Location", Event.location);
            command.Parameters.AddWithValue("@Created_By", Event.createdByUserID);
    

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

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

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

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

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

        public static DataTable GetAllRecords()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = $@"SELECT   Events.Event_ID, Events.Title,  Events.Location, Events.Event_Date, Event_Types.EventType_Name, 
                                        Events.Regular_Price, Events.VIP_Price
                            FROM  Events INNER JOIN
                            Event_Types ON Events.EventType_ID = Event_Types.EventType_ID";

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