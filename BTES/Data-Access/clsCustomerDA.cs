﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace BTES.Data_Access
{
    public static class clsCustomerDA
    {
        public static bool GetCustomer_Info_By_In_Customer(int Customer_ID, ref int Person_ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email, ref string Address, ref int Age, ref string Password, ref string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "select Customer.Customer_ID, Person.* from Customer inner join Person on Customer.Person_ID = Person.Person_ID where Customer_ID = @Customer_ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    Person_ID = int.Parse(reader["Person_ID"].ToString());
                    FirstName = reader["FirstName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    Address = reader["Address"].ToString();
                    Age = int.Parse(reader["Age"].ToString());
                    Password = reader["Password"].ToString();
                    UserName = reader["UserName"].ToString();

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