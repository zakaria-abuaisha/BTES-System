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

        //this function will return the new contact id if succeeded and -1 if not.
        public static int InsertRecord(int Event_ID, int Customer_ID, DateTime JoinDate, int Payment_Method, int Account_ID, string Password)
        {

            int RecordID = -1;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"INSERT INTO Waiting_List  (Event_ID, Customer_ID, JoinDate, Payment_Method, Account_ID, Password)
                             VALUES (@Event_ID, @Customer_ID, @JoinDate, @Payment_Method, @Account_ID, @Password);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            command.Parameters.AddWithValue("@JoinDate", JoinDate);
            command.Parameters.AddWithValue("@Payment_Method", Payment_Method);
            command.Parameters.AddWithValue("@Account_ID", Account_ID);
            command.Parameters.AddWithValue("@Password", Password);




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
        public static bool UpdateRecord(int WaitingList_ID, int Event_ID, int Customer_ID, DateTime JoinDate, int Payment_Method, int Account_ID, string Password)
        {
            int rowsAffected = 0;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"Update Waiting_List
                              set WaitingList_ID = @WaitingList_ID , 
                    Event_ID = @Event_ID , 
                    Customer_ID = @Customer_ID , 
                    JoinDate = @JoinDate , 
                    Payment_Method = @Payment_Method , 
                    Account_ID = @Account_ID , 
                    Password = @Password 
                              where WaitingList_ID = @WaitingList_ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@WaitingList_ID", WaitingList_ID);
            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            command.Parameters.AddWithValue("@JoinDate", JoinDate);
            command.Parameters.AddWithValue("@Payment_Method", Payment_Method);
            command.Parameters.AddWithValue("@Account_ID", Account_ID);
            command.Parameters.AddWithValue("@Password", Password);


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
        public static bool FindByID(int WaitingList_ID, ref int Event_ID, ref int Customer_ID, ref DateTime JoinDate, ref int Payment_Method, ref int Account_ID, ref string Password)
        {
            bool isFound = false;

            SqlConnection connection = clsDatabaseManager.GetInstance();

            string query = @"SELECT * FROM Waiting_List 
                             WHERE WaitingList_ID = @WaitingList_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@WaitingList_ID", WaitingList_ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    WaitingList_ID = (int)reader["WaitingList_ID"];
                    Event_ID = (int)reader["Event_ID"];
                    Customer_ID = (int)reader["Customer_ID"];
                    JoinDate = (DateTime)reader["JoinDate"];
                    Payment_Method = (int)reader["Payment_Method"];
                    Account_ID = (int)reader["Account_ID"];
                    Password = (string)reader["Password"];


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
