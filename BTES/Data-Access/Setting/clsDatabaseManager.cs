using BTES.Data_Access.Setting;
using System.Data.SqlClient;

public sealed class clsDatabaseManager
{
    private static SqlConnection instance;
    private static readonly object lockObject = new object();

    private clsDatabaseManager() { }

    public static SqlConnection GetInstance()
    {
        lock (lockObject)
        {
            if (instance == null)
            {
                instance = clsDatabaseManager.GetInstance();
            }
            return instance;
        }
    }
}
