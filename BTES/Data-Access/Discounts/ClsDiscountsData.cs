using BTES.Data_Access.Setting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access.Discounts
{
    public static class ClsDiscountsData
    {
        public static int AddNewDiscount_Orders(int Customer_ID, string Proof_Of_Identity,int DiscountType, bool Status)
        {




            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);



            string query = $@"INSERT INTO Discount_Orders(Customer_ID,Proof_Of_Identity,DiscountType,Status)
                                VALUES ( @Customer_ID, @Proof_Of_Identity, @Status);
                                SELECT SCOPE_IDENTITY();";

            //SEND THE QUERY AND THE CONNECTION TO (COMMAND) TO EXCUTE THE QUERY
            SqlCommand command = new SqlCommand(query, connection);

            //SEND THE PARAMETERS
            command.Parameters.AddWithValue("@Customer_ID ", Customer_ID);
            command.Parameters.AddWithValue("@Proof_Of_Identity ", Proof_Of_Identity);
            command.Parameters.AddWithValue("@DiscountType ", DiscountType);
            command.Parameters.AddWithValue("@Status ", Status);



            //IF THE INSERTING OPERATION FINISHED SUCCESSFULLY --->(command.ExecuteScalar()) WHILL RETURN THE AUTO NUMBER THAT THE TABLES GAVE IT TO OUR NEW RECORD
            try
            {

                connection.Open();

                object result = command.ExecuteScalar();

                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    return insertedID;
                else
                    return -1;

            }

            catch (Exception)
            {

            }

            //IF THE INERTING OPERATION FAILD WE WILL RETURN (-1) AS A FLAG FOR WHOEVER CALLING THIS METHOD, WHICH MEANS THAT THE INSERTION IS FAILD :-((((
            return -1;



        }

        public static bool IsDiscountExist(int Customer_ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Discount_Orders WHERE Customer_ID = @Customer_ID and Status = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
 
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

        public static bool GetDiscount_By_CustomerID(int Customer_ID, ref int DiscountOrder_ID, ref string Proof_Of_Identity, ref int DiscountType, ref bool Status)
        {
            bool isFound = false;
            
            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);
            string query = "SELECT * FROM Discount_Orders WHERE Customer_ID = @Customer_ID and Status = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    DiscountOrder_ID = int.Parse(reader["DiscountOrder_ID"].ToString());
                    Proof_Of_Identity = (string)reader["Proof_Of_Identity"];
                    DiscountType = int.Parse(reader["DiscountType"].ToString());
                    Status = bool.Parse(reader["Status"].ToString());

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
