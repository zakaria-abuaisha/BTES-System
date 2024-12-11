using BTES.Business_layer;
using BTES.Data_Access.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public static int Purchase_Ticket(ClsPurchasedTicket PT)
        {

            //CONNECTING WITH DATABASE
            SqlConnection connection = clsDatabaseManager.GetInstance();

            //PREPAER THE QUERY
            string query;
            if (PT.TicketType == "Regular")
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
            command.Parameters.AddWithValue("@Event_ID ", PT.Event.event_ID);
            command.Parameters.AddWithValue("@Customer_ID ", PT.Customer.Customer_ID);
            command.Parameters.AddWithValue("@Purchase_Date ", DateTime.Now);
            command.Parameters.AddWithValue("@Fees ", PT.Fees);
            command.Parameters.AddWithValue("@Payment_Gateway ", Convert.ToInt32(PT.PaymentGateway));
            command.Parameters.AddWithValue("@Status ", 1);
            command.Parameters.AddWithValue("@TicketType ", PT.TicketType);



            try
            {
                //OPEN THE CONNECION
                
                //EXECUTE
                object result = command.ExecuteScalar();

                clsDatabaseManager.CloseConnection();


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

        public static bool GetPurchased_Tickets_Info_By_In_Purchased_Tickets(int PurchasedTicket_ID,
    ref int Event_ID, ref int Customer_ID, ref DateTime Purchase_Date,
    ref float Fees, ref int Payment_Gateway, ref bool Status, ref string TicketType)
        {
            using (SqlConnection connection = clsDatabaseManager.GetInstance())
            using (SqlCommand command = new SqlCommand("SELECT * FROM Purchased_Tickets WHERE PT_ID = @PT_ID", connection))
            {
                command.Parameters.AddWithValue("@PT_ID", PurchasedTicket_ID);

                try
                {
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            Event_ID = reader["Event_ID"] != DBNull.Value ? Convert.ToInt32(reader["Event_ID"]) : 0;
                            Customer_ID = reader["Customer_ID"] != DBNull.Value ? Convert.ToInt32(reader["Customer_ID"]) : 0;
                            Purchase_Date = reader["Purchase_Date"] != DBNull.Value ? Convert.ToDateTime(reader["Purchase_Date"]) : DateTime.MinValue;
                            Fees = reader["Fees"] != DBNull.Value ? Convert.ToSingle(reader["Fees"]) : 0f;
                            Payment_Gateway = reader["Payment_Gateway"] != DBNull.Value ? Convert.ToInt32(reader["Payment_Gateway"]) : 0;
                            Status = reader["Status"] != DBNull.Value ? Convert.ToBoolean(reader["Status"]) : false;
                            TicketType = reader["TicketType"] != DBNull.Value ? reader["TicketType"].ToString() : string.Empty;

                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool Refund_Ticket(ClsPurchasedTicket PT)
        {
            string query = PT.TicketType == "Regular"
                ? @"UPDATE Purchased_Tickets
            SET Status = 0
            WHERE PT_ID = @PurchasedTicket_ID;
            UPDATE Events
            SET Regular_Tickets = Regular_Tickets + 1
            WHERE Event_ID = @Event_ID;"
                : @"UPDATE Purchased_Tickets
            SET Status = 0
            WHERE PT_ID = @PurchasedTicket_ID;
            UPDATE Events
            SET VIP_Tickets = VIP_Tickets + 1
            WHERE Event_ID = @Event_ID;";

            using (SqlConnection connection = clsDatabaseManager.GetInstance())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PurchasedTicket_ID", PT.PurchasedTicket_ID);
                command.Parameters.AddWithValue("@Event_ID", PT.Event.event_ID);

                try
                {
                    
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch
                {
                    return false;
                }
            }
        }


        public static bool IsRefundAllowed(int PurchasedTicket_ID)
        {
            bool isAllowed = false;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = $@"select Event_Date from Purchased_Tickets inner join Events on Purchased_Tickets.Event_ID = Events.Event_ID
                                where PT_ID = @PurchasedTicket_ID and Status = 1;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PurchasedTicket_ID", PurchasedTicket_ID);


            try
            {
                
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DateTime eventDate = DateTime.Parse(reader["Event_Date"].ToString()).AddDays(-1);
                    isAllowed = eventDate > DateTime.Now;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                clsDatabaseManager.CloseConnection();
            }

            return isAllowed;
        }


        public static DataTable GetAllRecords(int Customer_ID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"SELECT   Purchased_Tickets.PT_ID, Events.Title, (Person.FirstName + ' ' + Person.LastName) as FullName, Purchased_Tickets.Purchase_Date,
                                            Purchased_Tickets.Fees, 
                        CASE Purchased_Tickets.Payment_Gateway
                        WHEN 1 THEN 'DebtCard'
                        WHEN 2 THEN 'MobyCash'
                        WHEN 3 THEN 'Saddad'
                        WHEN 4 THEN 'Tadawul'
                        WHEN 5 THEN 'Edfali'
                        ELSE 'Unknown Payment Method'
                        END AS PaymentMethod,

	                    case  Purchased_Tickets.Status
		                    when  1 then 'Purchased'
		                    when  0 then 'Canceled'
	                    end as Status,
                        Purchased_Tickets.TicketType
                         FROM Purchased_Tickets INNER JOIN
                             Customer ON Purchased_Tickets.Customer_ID = Customer.Customer_ID INNER JOIN
                             Events ON Purchased_Tickets.Event_ID = Events.Event_ID INNER JOIN
                             Person ON Customer.Person_ID = Person.Person_ID
                             	 where Purchased_Tickets.Customer_ID = @CostumerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CostumerID", Customer_ID);


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
