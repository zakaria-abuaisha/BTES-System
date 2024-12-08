using BTES.Data_Access.Setting;
using System.Data.SqlClient;

public sealed class clsDatabaseManager
{
    private static SqlConnection instance;
    private static readonly object lockObject = new object();

    private clsDatabaseManager() { }

    public static SqlConnection GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new SqlConnection(ClsSettings.ConnectionString);
                }
            }
        }
        return instance;
    }
    
}
