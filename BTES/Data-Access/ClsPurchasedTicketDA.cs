using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access
{
    public class ClsPurchasedTicketDA
    {

        /// <summary>
        /// This method will return the newly inserted ID for the purchased ticket. If the operation fails, it will return -1.
        /// </summary>
        /// <returns></returns>
        public static int Purchase_Ticket(int Event_ID, int Customer_ID, float Fees, int Payment_Gateway, string TicketType)
        {

            //CONNECTING WITH DATABASE
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            //PREPAER THE QUERY
            string query;
            if (TicketType == "Regular")
            {
                query = $@"INSERT INTO Purchased_Tickets (Event_ID, Customer_ID, Purchase_Date, Fees, Payment_Gateway, Status, TicketType)
                                VALUES ( @Event_ID, @Customer_ID, @Purchase_Date, @Fees, @Payment_Gateway, @Status, @TicketType);
                                UPDATE Events
                                SET Regular_Tickets = Regular_Tickets - 1
                                WHERE Event_ID = @Event_ID;
                                SELECT SCOPE_IDENTITY();";
            }
            else
            {
                query = $@"INSERT INTO Purchased_Tickets (Event_ID, Customer_ID, Purchase_Date, Fees, Payment_Gateway, Status, TicketType)
                                VALUES ( @Event_ID, @Customer_ID, @Purchase_Date, @Fees, @Payment_Gateway, @Status, @TicketType);
                                UPDATE Events
                                SET VIP_Tickets = VIP_Tickets - 1
                                WHERE Event_ID = @Event_ID;
                                SELECT SCOPE_IDENTITY();";
            }
            

            //SEND THE QUERY AND THE CONNECTION TO (COMMAND) TO EXCUTE THE QUERY
            SqlCommand command = new SqlCommand(query, connection);

            //SEND THE PARAMETERS
            command.Parameters.AddWithValue("@Event_ID ", Event_ID);
            command.Parameters.AddWithValue("@Customer_ID ", Customer_ID);
            command.Parameters.AddWithValue("@Purchase_Date ", DateTime.Now);
            command.Parameters.AddWithValue("@Fees ", Fees);
            command.Parameters.AddWithValue("@Payment_Gateway ", Payment_Gateway);
            command.Parameters.AddWithValue("@Status ", 1);
            command.Parameters.AddWithValue("@TicketType ", TicketType);



            try
            {
                //OPEN THE CONNECION
                connection.Open();
                //EXECUTE
                object result = command.ExecuteScalar();

                connection.Close();

                
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    return insertedID;
                else
                    return -1;

            }

            catch (Exception)
            {
                return -1;
            }

        }

        public static bool GetPurchased_Tickets_Info_By_In_Purchased_Tickets(int PT_ID, ref int Event_ID, ref int Customer_ID, ref DateTime Purchase_Date, ref float Fees, ref int Payment_Gateway, ref bool Status, ref string TicketType)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "SELECT * FROM Purchased_Tickets WHERE PT_ID = @PT_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PT_ID", PT_ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    Event_ID = int.Parse(reader["Event_ID"].ToString());
                    Customer_ID = int.Parse(reader["Customer_ID"].ToString());
                    Purchase_Date = DateTime.Parse(reader["Purchase_Date"].ToString());
                    Fees = float.Parse(reader["Fees"].ToString());
                    Payment_Gateway = int.Parse(reader["Payment_Gateway"].ToString());
                    Status = bool.Parse(reader["Status"].ToString());
                    TicketType = (string)reader["TicketType"];

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
          
            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }
    }
}
