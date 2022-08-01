using RedArbor.Data;

namespace RedArbor.Services
{
    public static class ConnectionHelperService
    {
        public static IConnectionFactory GetConnection()
        {
            return new DbConnectionFactory("ConnectionString");
        }
    }
}
