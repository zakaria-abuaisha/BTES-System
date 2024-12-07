using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTES.Business_layer;
using BTES.Data_Access.Setting;

namespace BTES.Data_Access
{

    public class ClsEventData
    {
    
        public static bool FindByEvent_ID(int Event_ID, ref ClsEvent Event)
        {
            bool isFound = false;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"SELECT * FROM Events 
                                 WHERE  Event_ID = @Event_ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID); 


            try
            {
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

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
                    Event.event_ID = Event_ID;


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
                clsDatabaseManager.CloseConnection();
            }

            return isFound;

        }

        public static DataTable GetAllRecords()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = $@"SELECT   Events.Event_ID, Events.Title,  Events.Location, Events.Event_Date, 
										CASE
											WHEN Events.EventType = 1 THEN 'Sport'
											WHEN Events.EventType = 2 THEN 'Concert'
											ELSE 'Unknown'
										END as EventType, 
                                        Events.Regular_Price, Events.VIP_Price
                            FROM  Events";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                

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
                clsDatabaseManager.CloseConnection();
            }

            return dt;

        }


    }
}