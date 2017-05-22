using System.Data.SqlClient;

namespace UsageInspector.Managers
{
    public interface IConnectionManager
    {
        SqlConnection GetOpenConnection();
    }
}