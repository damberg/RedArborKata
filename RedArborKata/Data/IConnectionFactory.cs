using System.Data;

namespace RedArbor.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
