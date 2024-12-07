using BTES.Data_Access.Setting;
using System;
using System.Data.SqlClient;

public sealed class clsDatabaseManager : IDisposable
{
    private static volatile SqlConnection instance;
    private static readonly object lockObject = new object();
    private static bool disposed = false;

    private clsDatabaseManager() { }

    public static SqlConnection GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    try
                    {
                        instance = new SqlConnection(ClsSettings.ConnectionString);
                    }
                    catch (SqlException ex)
                    {
                        throw new ApplicationException("Failed to create database connection.", ex);
                    }
                }
            }
        }

        // Check connection state and reopen if closed
        if (instance.State != System.Data.ConnectionState.Open)
        {
            try
            {
                instance.ConnectionString = ClsSettings.ConnectionString;
                instance.Open();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Failed to open database connection.", ex);
            }
        }

        return instance;
    }

    public static void CloseConnection()
    {
        if (instance != null && instance.State == System.Data.ConnectionState.Open)
        {
            instance.Close();
        }
    }
}
