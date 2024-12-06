using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access.Tickets
{
    public class clsWaitingListData
    {
        public static int InsertRecord(int Event_ID, int Customer_ID, DateTime JoinDate, int Payment_Method, string Account_ID, string Password, string TicketType)
        {
            int RecordID = -1;
            SqlConnection connection = clsDatabaseManager.GetInstance();
            string query = @"INSERT INTO Waiting_List  (Event_ID, Customer_ID, JoinDate, Payment_Method, Account_ID, Password, TicketType)
                           VALUES (@Event_ID, @Customer_ID, @JoinDate, @Payment_Method, @Account_ID, @Password, @TicketType);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            command.Parameters.AddWithValue("@JoinDate", JoinDate);
            command.Parameters.AddWithValue("@Payment_Method", Payment_Method);
            command.Parameters.AddWithValue("@Account_ID", Account_ID);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@TicketType", TicketType);

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

        public static bool UpdateRecord(int WaitingList_ID, int Event_ID, int Customer_ID, DateTime JoinDate, int Payment_Method, string Account_ID, string Password, string TicketType)
        {
            int rowsAffected = 0;
            SqlConnection connection = clsDatabaseManager.GetInstance();
            string query = @"Update Waiting_List
                           set Event_ID = @Event_ID,
                               Customer_ID = @Customer_ID,
                               JoinDate = @JoinDate,
                               Payment_Method = @Payment_Method,
                               Account_ID = @Account_ID,
                               Password = @Password,
                               TicketType = @TicketType
                           where WaitingList_ID = @WaitingList_ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@WaitingList_ID", WaitingList_ID);
            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            command.Parameters.AddWithValue("@JoinDate", JoinDate);
            command.Parameters.AddWithValue("@Payment_Method", Payment_Method);
            command.Parameters.AddWithValue("@Account_ID", Account_ID);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@TicketType", TicketType);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool GetFirstRecordBy(ref int WaitingList_ID, int Event_ID, ref int Customer_ID, ref DateTime JoinDate, ref int Payment_Method, ref string Account_ID, ref string Password, string TicketType)
        {
            bool isFound = false;
            SqlConnection connection = clsDatabaseManager.GetInstance();
            string query = @"SELECT TOP 1 *
                            FROM Waiting_List
                            WHERE Event_ID = @Event_ID
                              AND TicketType = @TicketType
                            ORDER BY WaitingList_ID ASC";
                           

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@TicketType", TicketType);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    WaitingList_ID = Convert.ToInt32(reader["WaitingList_ID"]);
                    Event_ID = Convert.ToInt32(reader["Event_ID"]);
                    Customer_ID = Convert.ToInt32(reader["Customer_ID"]);
                    JoinDate = (DateTime)reader["JoinDate"];
                    Payment_Method = Convert.ToInt32(reader["Payment_Method"]);
                    Account_ID = (string)reader["Account_ID"];
                    Password = (string)reader["Password"];
                    TicketType = (string)reader["TicketType"];
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool DeleteRecord(int WaitingList_ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = clsDatabaseManager.GetInstance();
            string query = @"Delete Waiting_List 
                           where WaitingList_ID = @WaitingList_ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@WaitingList_ID", WaitingList_ID);

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
