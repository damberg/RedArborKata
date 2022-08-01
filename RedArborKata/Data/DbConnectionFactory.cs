using System.Data;
using System.Data.Common;

namespace RedArbor.Data
{
    public class DbConnectionFactory : IConnectionFactory
    {
        private readonly DbProviderFactory _provider;
        private readonly string _connectionString;
        private readonly string _name;

        public DbConnectionFactory(string connectionName)
        {
            if (connectionName == null) throw new ArgumentNullException("connectionName");  
            _name = "localhost";
            _provider = DbProviderFactories.GetFactory("System.Data.SqlClient");
            _connectionString = @"Data Source=DESKTOP-51TPT4Q\SQLEXPRESS;Initial Catalog=RedArbor;Integrated Security=True";
        }

        public IDbConnection Create()
        {
            var connection = _provider.CreateConnection();
            if (connection == null)
                throw new Exception("Failed to create a connection");

            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
