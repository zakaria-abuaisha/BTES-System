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
    public  class clsSportEventData
    {
        public static int InsertRecord(clsSportEvent sportEvent, ref int Event_ID)
        {

            int RecordID = -1;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string InsertEvent_query = @"INSERT INTO Events  (Title, Event_Content, Event_Date, EventType, Regular_Tickets, VIP_Tickets, Regular_Price, VIP_Price, Location, Created_By)
                                 VALUES (@Title, @Event_Content, @Event_Date, @EventType, @Regular_Tickets, @VIP_Tickets, @Regular_Price, @VIP_Price, @Location, @Created_By);
                                 SELECT SCOPE_IDENTITY();";

            string InsertSport_query = @"INSERT INTO Sports  (Event_ID, Team_VS_Team)
                             VALUES (@Event_ID, @Team_VS_Team);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand InsertEvent_command = new SqlCommand(InsertEvent_query, connection);
            SqlCommand InsertSport_command = new SqlCommand(InsertSport_query, connection);

            InsertEvent_command.Parameters.AddWithValue("@Title", sportEvent.title);
            InsertEvent_command.Parameters.AddWithValue("@Event_Content", sportEvent.eventContent);
            InsertEvent_command.Parameters.AddWithValue("@Event_Date", sportEvent.eventDate);
            InsertEvent_command.Parameters.AddWithValue("@EventType", (int)sportEvent.eventType);
            InsertEvent_command.Parameters.AddWithValue("@Regular_Tickets", sportEvent.regularTickets);
            InsertEvent_command.Parameters.AddWithValue("@VIP_Tickets", sportEvent.VIPTickets);
            InsertEvent_command.Parameters.AddWithValue("@Regular_Price", sportEvent.regularPrice);
            InsertEvent_command.Parameters.AddWithValue("@VIP_Price", sportEvent.VIPprice);
            InsertEvent_command.Parameters.AddWithValue("@Location", sportEvent.location);
            InsertEvent_command.Parameters.AddWithValue("@Created_By", sportEvent.createdByUserID);


            


            InsertSport_command.Parameters.AddWithValue("@Team_VS_Team", sportEvent.Team_VS_Team);


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
                sportEvent.event_ID = New_Event_ID;
                Event_ID = New_Event_ID;
                InsertSport_command.Parameters.AddWithValue("@Event_ID", sportEvent.event_ID);
                result = InsertSport_command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out  insertedID))
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

        public static bool UpdateRecord(clsSportEvent sportEvent)
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

                                  Update Sports
                              set Team_VS_Team = @Team_VS_Team 
                                  where Sport_ID = @Sport_ID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", sportEvent.event_ID);
            command.Parameters.AddWithValue("@Title", sportEvent.title);
            command.Parameters.AddWithValue("@Event_Content", sportEvent.eventContent);
            command.Parameters.AddWithValue("@Event_Date", sportEvent.eventDate);
            command.Parameters.AddWithValue("@EventType", (int)sportEvent.eventType);
            command.Parameters.AddWithValue("@Regular_Tickets", sportEvent.regularTickets);
            command.Parameters.AddWithValue("@VIP_Tickets", sportEvent.VIPTickets);
            command.Parameters.AddWithValue("@Regular_Price", sportEvent.regularPrice);
            command.Parameters.AddWithValue("@VIP_Price", sportEvent.VIPprice);
            command.Parameters.AddWithValue("@Location", sportEvent.location);
            command.Parameters.AddWithValue("@Created_By", sportEvent.createdByUserID);

            command.Parameters.AddWithValue("@Sport_ID", sportEvent.Sport_ID);
            command.Parameters.AddWithValue("@Team_VS_Team", sportEvent.Team_VS_Team);


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

        public static bool FindBySport_ID(int Sport_ID, ref string Team_VS_Team , ref ClsEvent Event)
        {
            bool isFound = false;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"SELECT Sport_ID, Sports.Team_VS_Team ,Events.* 
                    FROM Sports inner join Events on Sports.Event_ID = Events.Event_ID
                    WHERE Sports.Sport_ID = @Sport_ID;";

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

        public static bool FindByEvent_ID(int Event_ID, ref int Sport_ID, ref string Team_VS_Team, ref ClsEvent Event)
        {
            bool isFound = false;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"SELECT Sport_ID, Sports.Team_VS_Team ,Events.* 
                                FROM Sports inner join Events on Sports.Event_ID = Events.Event_ID
                                WHERE Sports.Event_ID = @Event_ID;";

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

                    Sport_ID = int.Parse(reader["Sport_ID"].ToString());

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

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"DELETE FROM Events
                                WHERE Event_ID IN (
                                    SELECT Event_ID FROM Sports WHERE Sport_ID = @Sport_ID
                                );
                                DELETE FROM Sports
                                WHERE Sport_ID = @Sport_ID;";

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
            SqlConnection connection = clsDatabaseManager.GetInstance();

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
        
    }
}
