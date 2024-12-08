using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTES.Data_Access.Setting;
using BTES.Business_layer;
using BTES.Business_layer.Event_Management;

namespace BTES.Data_Access.Event_Management
{ 
    public class clsConcertEventData
    {

        public static int InsertRecord(clsConcertEvent concertEvent, ref int Event_ID)
        {

            int RecordID = -1;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string InsertEvent_query = @"INSERT INTO Events  (Title, Event_Content, Event_Date, EventType, Regular_Tickets, VIP_Tickets, Regular_Price, VIP_Price, Location, Created_By)
                                 VALUES (@Title, @Event_Content, @Event_Date, @EventType, @Regular_Tickets, @VIP_Tickets, @Regular_Price, @VIP_Price, @Location, @Created_By);
                                 SELECT SCOPE_IDENTITY();";

            string InsertConcert_query = @"INSERT INTO Concerts  (Event_ID, Band_Or_Artist)
                             VALUES (@Event_ID, @Band_Or_Artist);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand InsertEvent_command = new SqlCommand(InsertEvent_query, connection);
            SqlCommand InsertConcert_command = new SqlCommand(InsertConcert_query, connection);

            InsertEvent_command.Parameters.AddWithValue("@Title", concertEvent.title);
            InsertEvent_command.Parameters.AddWithValue("@Event_Content", concertEvent.eventContent);
            InsertEvent_command.Parameters.AddWithValue("@Event_Date", concertEvent.eventDate);
            InsertEvent_command.Parameters.AddWithValue("@EventType", (int)concertEvent.eventType);
            InsertEvent_command.Parameters.AddWithValue("@Regular_Tickets", concertEvent.regularTickets);
            InsertEvent_command.Parameters.AddWithValue("@VIP_Tickets", concertEvent.VIPTickets);
            InsertEvent_command.Parameters.AddWithValue("@Regular_Price", concertEvent.regularPrice);
            InsertEvent_command.Parameters.AddWithValue("@VIP_Price", concertEvent.VIPprice);
            InsertEvent_command.Parameters.AddWithValue("@Location", concertEvent.location);
            InsertEvent_command.Parameters.AddWithValue("@Created_By", concertEvent.createdByUserID);





            InsertConcert_command.Parameters.AddWithValue("@Band_Or_Artist", concertEvent.Band_Or_Artist);


            try
            {
                int New_Event_ID = -1;
                connection.Open();

                object result = InsertEvent_command.ExecuteScalar();

                int insertedID = -1;
                if (result != null && int.TryParse(result.ToString(), out insertedID))
                {
                    New_Event_ID = insertedID;
                }
                concertEvent.event_ID = New_Event_ID;
                Event_ID = New_Event_ID;
                InsertConcert_command.Parameters.AddWithValue("@Event_ID", concertEvent.event_ID);
                result = InsertConcert_command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out insertedID))
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

        public static bool UpdateRecord(clsConcertEvent concertEvent)
        {
            int rowsAffected = 0;

            SqlConnection connection = clsDatabaseManager.GetInstance();


            string query = @"Update Events
                              set Title = @Title , 
                                  Event_Content = @Event_Content , 
                                  Event_Date = @Event_Date , 
                                  EventType = @EventType , 
                                  Regular_Tickets = @Regular_Tickets , 
                                  VIP_Tickets = @VIP_Tickets , 
                                  Regular_Price = @Regular_Price , 
                                  VIP_Price = @VIP_Price , 
                                  Location = @Location , 
                                  Created_By = @Created_By 
                                  where Event_ID = @Event_ID;

                                  Update Concerts
                              set Band_Or_Artist = @Band_Or_Artist 
                                  where Concert_ID = @Concert_ID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", concertEvent.event_ID);
            command.Parameters.AddWithValue("@Title", concertEvent.title);
            command.Parameters.AddWithValue("@Event_Content", concertEvent.eventContent);
            command.Parameters.AddWithValue("@Event_Date", concertEvent.eventDate);
            command.Parameters.AddWithValue("@EventType", (int)concertEvent.eventType);
            command.Parameters.AddWithValue("@Regular_Tickets", concertEvent.regularTickets);
            command.Parameters.AddWithValue("@VIP_Tickets", concertEvent.VIPTickets);
            command.Parameters.AddWithValue("@Regular_Price", concertEvent.regularPrice);
            command.Parameters.AddWithValue("@VIP_Price", concertEvent.VIPprice);
            command.Parameters.AddWithValue("@Location", concertEvent.location);
            command.Parameters.AddWithValue("@Created_By", concertEvent.createdByUserID);

            command.Parameters.AddWithValue("@Concert_ID", concertEvent.Concert_ID);
            command.Parameters.AddWithValue("@Event_ID", concertEvent.event_ID);
            command.Parameters.AddWithValue("@Band_Or_Artist", concertEvent.Band_Or_Artist);


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

        public static bool FindByConcert_ID(int Concert_ID, ref string Band_Or_Artist, ref ClsEvent Event)
        {
            bool isFound = false;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"SELECT Concert_ID, Concerts.Band_Or_Artist ,Events.* 
                    FROM Concerts inner join Events on Concerts.Event_ID = Events.Event_ID
                    WHERE Concerts.Concert_ID = @Concert_ID;";

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

                    Event.event_ID = int.Parse(reader["Event_ID"].ToString());
                    Event.title = (string)reader["Title"];
                    Event.eventContent = (string)reader["Event_Content"];
                    Event.eventDate = DateTime.Parse(reader["Event_Date"].ToString());
                    Event.eventType = (ClsEvent.enEventType)int.Parse(reader["EventType"].ToString());
                    Event.regularTickets = int.Parse(reader["Regular_Tickets"].ToString());
                    Event.VIPTickets = int.Parse(reader["VIP_Tickets"].ToString());
                    Event.regularPrice = float.Parse(reader["Regular_Price"].ToString());
                    Event.VIPprice = float.Parse(reader["VIP_Price"].ToString());
                    Event.location = (string)reader["Location"];
                    Event.createdByUserID = int.Parse(reader["Created_By"].ToString());

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

        public static bool FindByEvent_ID(int Event_ID, ref int Concert_ID, ref string Band_Or_Artist, ref ClsEvent Event)
        {
            bool isFound = false;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"SELECT Concert_ID, Concerts.Band_Or_Artist ,Events.* 
                                FROM Concerts inner join Events on Concerts.Event_ID = Events.Event_ID
                                WHERE Concerts.Event_ID = @Event_ID;";

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

                    Concert_ID = int.Parse(reader["Concert_ID"].ToString());

                    Event.event_ID = int.Parse(reader["Event_ID"].ToString());
                    Event.title = (string)reader["Title"];
                    Event.eventContent = (string)reader["Event_Content"];
                    Event.eventDate = DateTime.Parse(reader["Event_Date"].ToString());
                    Event.eventType = (ClsEvent.enEventType)int.Parse(reader["EventType"].ToString());
                    Event.regularTickets = int.Parse(reader["Regular_Tickets"].ToString());
                    Event.VIPTickets = int.Parse(reader["VIP_Tickets"].ToString());
                    Event.regularPrice = float.Parse(reader["Regular_Price"].ToString());
                    Event.VIPprice = float.Parse(reader["VIP_Price"].ToString());
                    Event.location = (string)reader["Location"];
                    Event.createdByUserID = int.Parse(reader["Created_By"].ToString());


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

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"DELETE FROM Events
                                WHERE Event_ID IN (
                                    SELECT Event_ID FROM Concerts WHERE Concert_ID = @Concert_ID
                                );
                                DELETE FROM Concerts
                                WHERE Concert_ID = @Concert_ID;";


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
            SqlConnection connection = clsDatabaseManager.GetInstance();

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


    }
}
