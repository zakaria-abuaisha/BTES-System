﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTES.Data_Access.Setting;

namespace BTES.Data_Access.Event_Management
{
    public class clsEventRateData
    {

        //this function will return the new contact id if succeeded and -1 if not.
        public static int InsertRecord(int Event_ID, int Customer_ID, int Rate, string Comment)
        {

            int RecordID = -1;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"INSERT INTO Event_Rate  (Event_ID, Customer_ID, Rate, Comment)
                             VALUES (@Event_ID, @Customer_ID, @Rate, @Comment);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            command.Parameters.AddWithValue("@Rate", Rate);
            command.Parameters.AddWithValue("@Comment", Comment);




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
        public static bool FindByEventRate_ID(int EventRate_ID, ref int Event_ID, ref int Customer_ID, ref int Rate, ref string Comment)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"SELECT * FROM Event_Rate 
                             WHERE  EventRate_ID = @EventRate_ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventRate_ID", EventRate_ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Event_ID = (int)reader["Event_ID"];
                    Customer_ID = (int)reader["Customer_ID"];
                    Rate = (int)reader["Rate"];
                    Comment = (string)reader["Comment"];


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



        public static bool UpdateRecord(int EventRate_ID, int Event_ID, int Customer_ID, int Rate, string Comment)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"Update Event_Rate
                              set EventRate_ID = @EventRate_ID , 
                                Event_ID = @Event_ID , 
                                Customer_ID = @Customer_ID , 
                                Rate = @Rate , 
                                Comment = @Comment 
                              where EventRate_ID = @EventRate_ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventRate_ID", EventRate_ID);
            command.Parameters.AddWithValue("@Event_ID", Event_ID);
            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            command.Parameters.AddWithValue("@Rate", Rate);
            command.Parameters.AddWithValue("@Comment", Comment);


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



        public static bool DeleteRecord(int EventRate_ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = @"Delete Event_Rate 
                                        where EventRate_ID = @EventRate_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EventRate_ID", EventRate_ID);

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
            SqlConnection connection = new SqlConnection(ClsSettings.ConnectionString);

            string query = "SELECT * FROM Event_Rate;";

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