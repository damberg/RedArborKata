using RedArborKata.Data;

namespace RedArborKata.Services
{
    public static class ConnectionHelperService
    {
        public static IConnectionFactory GetConnection()
        {
            return new DbConnectionFactory("ConnectionString");
        }
    }
}
